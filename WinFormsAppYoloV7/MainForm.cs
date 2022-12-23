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
			using var yolo = new Yolov7("Assets/yolov7-tiny.onnx", checkBoxUseGPU.Checked);
			yolo.SetupYoloDefaultLabels();   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
			GetPredictions(yolo);

			MessageBox.Show("Finished v7.");
		}

		private void ButtonYoloV5_Click(object sender, EventArgs e)
		{
			using var yolo = new Yolov5("Assets/yolov7-tiny_640x640.onnx", checkBoxUseGPU.Checked);
			yolo.SetupYoloDefaultLabels();
			GetPredictions(yolo);
			MessageBox.Show("Finish v5.");
		}

		private void GetPredictions(Yolov7 yolo)
		{
			Image image = Image.FromFile(fileName);
			var predictions = yolo.Predict(image);
			DrawRectangle(image, predictions);
		}

		private void GetPredictions(Yolov5 yolo)
		{
			Image image = Image.FromFile(fileName);
			var predictions = yolo.Predict(image);
			DrawRectangle(image, predictions);
		}

		private void DrawRectangle(Image image, List<YoloPrediction> predictions)
		{
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
			VideoForm videoForm = new VideoForm(checkBoxUseGPU.Checked);
			videoForm.Show();
		}

		private void ButtonWebCam_Click(object sender, EventArgs e)
		{
			WebCamForm videoForm = new WebCamForm();
			videoForm.Show();
		}

	}
}
