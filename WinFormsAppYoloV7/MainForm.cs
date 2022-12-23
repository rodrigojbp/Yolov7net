using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yolov7net;

namespace WinFormsAppYoloV7
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private string fileName = "Assets/demo.jpg";
		private void ButtonLoadImage_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = openFileDialog1.FileName;
			}
			pictureBox1.Image = Image.FromFile(fileName);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			MessageBox.Show("Clique no botão Yolo V7/V5");
		}

		private void ButtonYoloV7_Click(object sender, EventArgs e)
		{
			// init Yolov7 with onnx (include nms results)file path
			using var yolo = new Yolov7("Assets/yolov7-tiny.onnx", checkBoxUseGPU.Checked);
			// setup labels of onnx model 
			yolo.SetupYoloDefaultLabels();   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
			DrawRectangle(yolo);

			MessageBox.Show("Finished v7.");
		}

		private void ButtonYoloV5_Click(object sender, EventArgs e)
		{
			// init Yolov7 with onnx (include nms results)file path
			using var yolo = new Yolov7("Assets/yolov7-tiny_640x640.onnx", checkBoxUseGPU.Checked);
			// setup labels of onnx model 
			yolo.SetupYoloDefaultLabels();   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
			DrawRectangle(yolo);
			MessageBox.Show("Finish v5.");
		}

		private void DrawRectangle(Yolov7 yolo)
		{
			Image image = Image.FromFile(fileName);
			var predictions = yolo.Predict(image);
			Graphics graphics = Graphics.FromImage(image);
			foreach (var prediction in predictions) // iterate predictions to draw results
			{
				double score = Math.Round(prediction.Score, 2);
				graphics.DrawRectangles(new Pen(prediction.Label.Color, 1), new[] { prediction.Rectangle });
				var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);
				graphics.DrawString($"{prediction.Label.Name} ({score})",
								new Font("Arial", 32, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
								new PointF(x, y));
			}
			pictureBox1.Image = image;
			pictureBox1.Refresh();
		}

		private void ButtonOpenVideo_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = openFileDialog1.FileName;
			}
			/*pictureBox1.Image = Image.FromFile(fileName);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;*/


			// init Yolov7 with onnx (include nms results)file path
			using var yolo = new Yolov7("Assets/yolov7-tiny.onnx", checkBoxUseGPU.Checked);
			// setup labels of onnx model 
			yolo.SetupYoloDefaultLabels();   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)			

			int yoloWidth = 608, yoloHeight = 608;
			
			// OpenCV & WPF setting
			VideoCapture videocapture;
			Mat image = new Mat();

			byte[] imageInBytes = new byte[(int)(yoloWidth * yoloHeight * image.Channels())];

			// Read a video file and run object detection over it!
			using (videocapture = new VideoCapture(fileName))
			{				
				using (Mat imageOriginal = new Mat())
				{
					// read a single frame and convert the frame into a byte array					

					while (videocapture.Read(imageOriginal)) {						
						image = imageOriginal.Resize(new OpenCvSharp.Size(yoloWidth, yoloHeight));
						imageInBytes = image.ToBytes();
						Bitmap bitmap = ByteArrayToImage(imageInBytes);
						var predictions = yolo.Predict(bitmap);
						Graphics graphics = Graphics.FromImage(bitmap);
						foreach (var prediction in predictions) // iterate predictions to draw results
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

					MessageBox.Show("Clique no botão Yolo V7/V5");
		}

		private void ButtonWebCam_Click(object sender, EventArgs e)
		{
			WebCamForm videoForm = new WebCamForm();
			videoForm.Show();
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
