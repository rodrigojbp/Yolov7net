using DirectShowLib;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Yolov7net;

namespace WinFormsAppYoloV7
{
	public partial class VideoForm : Form
	{
        bool isCameraRunning = false;
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        bool Threadbusy = false;
        YoloRecorder yoloRecord;
        private string fileName = "";
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
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }

            DisposeCameraResources();

            isCameraRunning = true;
            btnRecord.Text = "Stop";
            
            capture = new VideoCapture(fileName);
            capture.Open(fileName);
        }

        private void StopVideo()
        {
            isCameraRunning = false;
            btnRecord.Text = "Start";

            recordingTimer.Stop();
            recordingTimer.Enabled = false;

            DisposeCaptureResources();
        }
        private void DisposeCameraResources()
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
            if (capture.IsOpened())
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

                        image = BitmapConverter.ToBitmap(frame);
                        pictureBox1.Image = image;
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

           if (!isCameraRunning)
            {
                lblStatus.Text = "Starting recording...";
                StartVideo();
                recordingTimer.Enabled = true;
                lblStatus.Text = "Recording...";
            }
            else
            {
                StopVideo();
                lblStatus.Text = "Recording ended.";

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

        private void OpenVideo()
        {
            openFileDialog1.Filter = "MP4|*.mp4";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }
            
            using var yolo = new Yolov7("Assets/yolov7-tiny.onnx", useGPU);
            yolo.SetupYoloDefaultLabels();
            int yoloWidth = 608, yoloHeight = 608;
            VideoCapture videocapture;
            Mat image = new Mat();

            byte[] imageInBytes = new byte[(int)(yoloWidth * yoloHeight * image.Channels())];

            using (videocapture = new VideoCapture(fileName))
            {
                using (Mat imageOriginal = new Mat())
                {
                    while (videocapture.IsOpened())
                    {
                        videocapture.Read(imageOriginal);
                        image = imageOriginal.Resize(new OpenCvSharp.Size(yoloWidth, yoloHeight));
                        imageInBytes = image.ToBytes();
                        Bitmap bitmap = ByteArrayToImage(imageInBytes);
                        var predictions = yolo.Predict(bitmap);
                        Graphics graphics = Graphics.FromImage(bitmap);
                        foreach (var prediction in predictions)
                        {
                            double score = Math.Round(prediction.Score, 2);
                            graphics.DrawRectangles(new Pen(prediction.Label.Color, 1), new[] { prediction.Rectangle });
                            var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);
                            graphics.DrawString($"{prediction.Label.Name} ({score})",
                                            new Font("Arial", 32, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
                                            new PointF(x, y));
                        }
                        pictureBox1.Image = bitmap;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();
                    }

                }                
            }

            // conduct object detection and display the result
            /*var items = yolowrapper.Detect(imageInBytes);
			foreach (var item in items)
			{
				var x = item.X;
				var y = item.Y;
				var width = item.Width;
				var height = item.Height;
				var type = item.Type;  // class name of the object

				// draw a bounding box for the detected object
				// you can set different colors for different classes
				Cv2.Rectangle(image, new OpenCvSharp.Rect(x, y, width, height), Scalar.Green, 3);
			}*/

            MessageBox.Show("End");
        }
    }
}

