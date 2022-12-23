using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsAppYoloV7
{
	public partial class VideoForm : Form
	{
        bool isVideoRunning = false;
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        bool Threadbusy = false;
        YoloRecorder yoloRecord;
        string fileName = "";
        Boolean useGPU;

        public VideoForm(Boolean useGPU)
        {
            InitializeComponent();
            this.useGPU = useGPU;
        }
        private void VideoForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.BackColor = Color.Transparent;
            frame = new Mat();
            yoloRecord = new YoloRecorder(frame);            
        }

        private void StartVideo()
        {
            openFileDialog1.Filter =
            "Videos (*.mp4;*.avi) | *.mp4; *.avi";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                DisposeVideoResources();

                isVideoRunning = true;
                btnRecord.Text = "Stop";

                capture = new VideoCapture(fileName);
                capture.Open(fileName);
            }            
        }
        
        private void StopVideo()
        {
            isVideoRunning = false;
            btnRecord.Text = "Start";

            recordingTimer.Stop();
            recordingTimer.Enabled = false;

            DisposeCaptureResources();
        }

        private void DisposeVideoResources()
        {
            if (frame != null)
            {
                frame.Dispose();
            }

            if (image != null)
            {
                image.Dispose();
            }
        }

        private void DisposeCaptureResources()
        {
            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
            }
        }

        private void YoloThreadMethod()
        {
            Threadbusy = true;
            Mat frame = new Mat();
            capture.Read(frame);
            yoloRecord.Start(frame);
            pictureBox2.Image = yoloRecord.bitmap;
            Threadbusy = false;
        }

        private void RecordingTimer_Tick(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened())
            {
                try
                {
                    Mat frame = new Mat();
                    capture.Read(frame);
                    if (!Threadbusy)
                    {
                        Thread t = new Thread(new ThreadStart(YoloThreadMethod));
                        t.Start();
                    }
                    if (frame != null)
                    {
                        if (frame.Empty())
                        {
                            frame.Dispose();
                            StopVideo();
                            lblStatus.Text = "Finished.";
                            pictureBox1.Image = null;
                            pictureBox2.Image = null;
                            pictureBox1.Update();
                            pictureBox2.Update();
                        }
                        else
                        {
                            image = BitmapConverter.ToBitmap(frame);
                            pictureBox1.Image = image;
                        }
                    }

                }
                catch (Exception)
                {
                    pictureBox1.Image = null;
                }

            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
           if (!isVideoRunning)
            {
                lblStatus.Text = "Starting...";
                StartVideo();
                recordingTimer.Enabled = true;
                lblStatus.Text = "Playing...";
            }
            else
            {
                StopVideo();
                lblStatus.Text = "Finished.";
            }
        }

		private void ButtonStop_Click(object sender, EventArgs e)
		{
            StopVideo();
		}

        private static Bitmap ByteArrayToImage(byte[] source)
        {
            using (var ms = new MemoryStream(source))
            {
                return new Bitmap(ms);
            }
        }
        
    }
}

