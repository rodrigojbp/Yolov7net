using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yolov7net;

namespace WinFormsAppYoloV7
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private string fileName = "Assets/demo.jpg";
		private void Button1_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				fileName = openFileDialog1.FileName;
			}
			pictureBox1.Image = Image.FromFile(fileName);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			// init Yolov7 with onnx (include nms results)file path
			using var yolo = new Yolov7("Assets/yolov7-tiny.onnx", false);
			// setup labels of onnx model 
			yolo.SetupYoloDefaultLabels();   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
			using var image = Image.FromFile(fileName);
			var predictions = yolo.Predict(image);

			// draw box
			using var graphics = Graphics.FromImage(image);
			foreach (var prediction in predictions) // iterate predictions to draw results
			{
				double score = Math.Round(prediction.Score, 2);
				graphics.DrawRectangles(new Pen(prediction.Label.Color, 1), new[] { prediction.Rectangle });
				var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);
				graphics.DrawString($"{prediction.Label.Name} ({score})",
								new Font("Consolas", 32, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
								new PointF(x, y));
			}

			pictureBox1.Image = image;
			pictureBox1.Refresh();

			MessageBox.Show("Predição finalizada.");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// init Yolov7 with onnx (include nms results)file path

			//using var yolo = new Yolov5(@"E:\dev\yolo\dotnet\Yolov7net\WinFormsAppYoloV7\Assets\yolov7-tiny_640x640.onnx", false);
			using var yolo = new Yolov7("Assets/yolov7-tiny_640x640.onnx", false);
			// setup labels of onnx model 
			yolo.SetupYoloDefaultLabels();   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
			using var image = Image.FromFile(fileName);
			var predictions = yolo.Predict(image);

			// draw box
			using var graphics = Graphics.FromImage(image);
			foreach (var prediction in predictions) // iterate predictions to draw results
			{
				double score = Math.Round(prediction.Score, 2);
				graphics.DrawRectangles(new Pen(prediction.Label.Color, 1), new[] { prediction.Rectangle });
				var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);
				graphics.DrawString($"{prediction.Label.Name} ({score})",
								new Font("Consolas", 32, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
								new PointF(x, y));
			}
			pictureBox1.Image = image;
			pictureBox1.Refresh();
			

			MessageBox.Show("Predição finalizada.");
		}

	}
}
