
namespace WinFormsAppYoloV7
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonLoadImage = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonYoloV7 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonYoloV5 = new System.Windows.Forms.Button();
			this.checkBoxUseGPU = new System.Windows.Forms.CheckBox();
			this.buttonOpenVideo = new System.Windows.Forms.Button();
			this.buttonWebCam = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonLoadImage
			// 
			this.buttonLoadImage.Location = new System.Drawing.Point(53, 488);
			this.buttonLoadImage.Name = "buttonLoadImage";
			this.buttonLoadImage.Size = new System.Drawing.Size(122, 23);
			this.buttonLoadImage.TabIndex = 0;
			this.buttonLoadImage.Text = "Carregar Imagem";
			this.buttonLoadImage.UseVisualStyleBackColor = true;
			this.buttonLoadImage.Click += new System.EventHandler(this.ButtonLoadImage_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(53, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(801, 445);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// buttonYoloV7
			// 
			this.buttonYoloV7.Location = new System.Drawing.Point(292, 472);
			this.buttonYoloV7.Name = "buttonYoloV7";
			this.buttonYoloV7.Size = new System.Drawing.Size(75, 23);
			this.buttonYoloV7.TabIndex = 2;
			this.buttonYoloV7.Text = "YoloV7";
			this.buttonYoloV7.UseVisualStyleBackColor = true;
			this.buttonYoloV7.Click += new System.EventHandler(this.ButtonYoloV7_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// buttonYoloV5
			// 
			this.buttonYoloV5.Location = new System.Drawing.Point(292, 513);
			this.buttonYoloV5.Name = "buttonYoloV5";
			this.buttonYoloV5.Size = new System.Drawing.Size(75, 23);
			this.buttonYoloV5.TabIndex = 3;
			this.buttonYoloV5.Text = "YoloV5";
			this.buttonYoloV5.UseVisualStyleBackColor = true;
			this.buttonYoloV5.Click += new System.EventHandler(this.ButtonYoloV5_Click);
			// 
			// checkBoxUseGPU
			// 
			this.checkBoxUseGPU.AutoSize = true;
			this.checkBoxUseGPU.Location = new System.Drawing.Point(211, 488);
			this.checkBoxUseGPU.Name = "checkBoxUseGPU";
			this.checkBoxUseGPU.Size = new System.Drawing.Size(49, 19);
			this.checkBoxUseGPU.TabIndex = 4;
			this.checkBoxUseGPU.Text = "GPU";
			this.checkBoxUseGPU.UseVisualStyleBackColor = true;
			// 
			// buttonOpenVideo
			// 
			this.buttonOpenVideo.Location = new System.Drawing.Point(651, 484);
			this.buttonOpenVideo.Name = "buttonOpenVideo";
			this.buttonOpenVideo.Size = new System.Drawing.Size(122, 23);
			this.buttonOpenVideo.TabIndex = 5;
			this.buttonOpenVideo.Text = "Video";
			this.buttonOpenVideo.UseVisualStyleBackColor = true;
			this.buttonOpenVideo.Click += new System.EventHandler(this.ButtonOpenVideo_Click);
			// 
			// buttonWebCam
			// 
			this.buttonWebCam.Location = new System.Drawing.Point(497, 485);
			this.buttonWebCam.Name = "buttonWebCam";
			this.buttonWebCam.Size = new System.Drawing.Size(122, 23);
			this.buttonWebCam.TabIndex = 6;
			this.buttonWebCam.Text = "WebCam";
			this.buttonWebCam.UseVisualStyleBackColor = true;
			this.buttonWebCam.Click += new System.EventHandler(this.ButtonWebCam_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 548);
			this.Controls.Add(this.buttonWebCam);
			this.Controls.Add(this.buttonOpenVideo);
			this.Controls.Add(this.checkBoxUseGPU);
			this.Controls.Add(this.buttonYoloV5);
			this.Controls.Add(this.buttonYoloV7);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.buttonLoadImage);
			this.Name = "MainForm";
			this.Text = "YoloV7";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonWebCam;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonYoloV7;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button buttonYoloV5;
		private System.Windows.Forms.CheckBox checkBoxUseGPU;
		private System.Windows.Forms.Button buttonOpenVideo;
		private System.Windows.Forms.Button buttonLoadImage;
	}
}

