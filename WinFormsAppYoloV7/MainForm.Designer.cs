
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.buttonWebCam = new System.Windows.Forms.Button();
			this.buttonOpenVideo = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBoxUseGPU = new System.Windows.Forms.CheckBox();
			this.buttonYoloV5 = new System.Windows.Forms.Button();
			this.buttonYoloV7 = new System.Windows.Forms.Button();
			this.buttonLoadImage = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPage2.Controls.Add(this.buttonWebCam);
			this.tabPage2.Controls.Add(this.buttonOpenVideo);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(885, 510);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Cam/Video";
			// 
			// buttonWebCam
			// 
			this.buttonWebCam.BackColor = System.Drawing.Color.CadetBlue;
			this.buttonWebCam.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.buttonWebCam.Location = new System.Drawing.Point(484, 156);
			this.buttonWebCam.Name = "buttonWebCam";
			this.buttonWebCam.Size = new System.Drawing.Size(321, 201);
			this.buttonWebCam.TabIndex = 21;
			this.buttonWebCam.Text = "WebCam";
			this.buttonWebCam.UseVisualStyleBackColor = false;
			this.buttonWebCam.Click += new System.EventHandler(this.ButtonWebCam_Click);
			// 
			// buttonOpenVideo
			// 
			this.buttonOpenVideo.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.buttonOpenVideo.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.buttonOpenVideo.Location = new System.Drawing.Point(53, 156);
			this.buttonOpenVideo.Name = "buttonOpenVideo";
			this.buttonOpenVideo.Size = new System.Drawing.Size(311, 201);
			this.buttonOpenVideo.TabIndex = 20;
			this.buttonOpenVideo.Text = "Video";
			this.buttonOpenVideo.UseVisualStyleBackColor = false;
			this.buttonOpenVideo.Click += new System.EventHandler(this.ButtonOpenVideo_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPage1.Controls.Add(this.pictureBox1);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.checkBoxUseGPU);
			this.tabPage1.Controls.Add(this.buttonYoloV5);
			this.tabPage1.Controls.Add(this.buttonYoloV7);
			this.tabPage1.Controls.Add(this.buttonLoadImage);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(885, 510);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Imagem";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(6, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(873, 409);
			this.pictureBox1.TabIndex = 20;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(469, 422);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 86);
			this.label3.TabIndex = 18;
			this.label3.Text = "2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(21, 422);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 86);
			this.label2.TabIndex = 17;
			this.label2.Text = "1";
			// 
			// checkBoxUseGPU
			// 
			this.checkBoxUseGPU.AutoSize = true;
			this.checkBoxUseGPU.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.checkBoxUseGPU.Location = new System.Drawing.Point(299, 450);
			this.checkBoxUseGPU.Name = "checkBoxUseGPU";
			this.checkBoxUseGPU.Size = new System.Drawing.Size(96, 45);
			this.checkBoxUseGPU.TabIndex = 14;
			this.checkBoxUseGPU.Text = "GPU";
			this.checkBoxUseGPU.UseVisualStyleBackColor = true;
			// 
			// buttonYoloV5
			// 
			this.buttonYoloV5.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.buttonYoloV5.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonYoloV5.Location = new System.Drawing.Point(707, 444);
			this.buttonYoloV5.Name = "buttonYoloV5";
			this.buttonYoloV5.Size = new System.Drawing.Size(132, 48);
			this.buttonYoloV5.TabIndex = 13;
			this.buttonYoloV5.Text = "YoloV5";
			this.buttonYoloV5.UseVisualStyleBackColor = false;
			this.buttonYoloV5.Click += new System.EventHandler(this.ButtonYoloV5_Click);
			// 
			// buttonYoloV7
			// 
			this.buttonYoloV7.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.buttonYoloV7.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonYoloV7.Location = new System.Drawing.Point(547, 444);
			this.buttonYoloV7.Name = "buttonYoloV7";
			this.buttonYoloV7.Size = new System.Drawing.Size(137, 48);
			this.buttonYoloV7.TabIndex = 12;
			this.buttonYoloV7.Text = "YoloV7";
			this.buttonYoloV7.UseVisualStyleBackColor = false;
			this.buttonYoloV7.Click += new System.EventHandler(this.ButtonYoloV7_Click);
			// 
			// buttonLoadImage
			// 
			this.buttonLoadImage.BackColor = System.Drawing.Color.AliceBlue;
			this.buttonLoadImage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonLoadImage.Location = new System.Drawing.Point(91, 445);
			this.buttonLoadImage.Name = "buttonLoadImage";
			this.buttonLoadImage.Size = new System.Drawing.Size(202, 52);
			this.buttonLoadImage.TabIndex = 11;
			this.buttonLoadImage.Text = "Carregar Imagem";
			this.buttonLoadImage.UseVisualStyleBackColor = false;
			this.buttonLoadImage.Click += new System.EventHandler(this.ButtonLoadImage_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(893, 538);
			this.tabControl1.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 548);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "YoloV7";
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonWebCam;
		private System.Windows.Forms.Button buttonOpenVideo;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBoxUseGPU;
		private System.Windows.Forms.Button buttonYoloV5;
		private System.Windows.Forms.Button buttonYoloV7;
		private System.Windows.Forms.Button buttonLoadImage;
		private System.Windows.Forms.TabControl tabControl1;
	}
}

