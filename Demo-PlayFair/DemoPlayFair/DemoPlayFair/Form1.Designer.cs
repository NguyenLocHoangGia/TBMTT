namespace DemoPlayFair
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRandomKhoa = new System.Windows.Forms.Button();
			this.txtNhapMaTran = new System.Windows.Forms.TextBox();
			this.txtMaTran = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.lblLoi = new System.Windows.Forms.Label();
			this.lblSokyTu = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDuyChuyen = new System.Windows.Forms.Button();
			this.btnGiaiMa = new System.Windows.Forms.Button();
			this.btnMaHoa = new System.Windows.Forms.Button();
			this.txtXuatVanBan = new System.Windows.Forms.TextBox();
			this.txtNhapVanBan = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.btnRandomKhoa);
			this.groupBox1.Controls.Add(this.txtNhapMaTran);
			this.groupBox1.Controls.Add(this.txtMaTran);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.groupBox1.Location = new System.Drawing.Point(29, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(531, 247);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Khóa";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(282, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Nhập ma trận:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(6, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Ma trận:";
			// 
			// btnRandomKhoa
			// 
			this.btnRandomKhoa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRandomKhoa.ForeColor = System.Drawing.Color.Black;
			this.btnRandomKhoa.Location = new System.Drawing.Point(285, 82);
			this.btnRandomKhoa.Name = "btnRandomKhoa";
			this.btnRandomKhoa.Size = new System.Drawing.Size(240, 33);
			this.btnRandomKhoa.TabIndex = 4;
			this.btnRandomKhoa.Text = "Khóa ngẫu nhiên";
			this.btnRandomKhoa.UseVisualStyleBackColor = true;
			this.btnRandomKhoa.Click += new System.EventHandler(this.btnRandomKhoa_Click);
			// 
			// txtNhapMaTran
			// 
			this.txtNhapMaTran.Location = new System.Drawing.Point(285, 56);
			this.txtNhapMaTran.Name = "txtNhapMaTran";
			this.txtNhapMaTran.Size = new System.Drawing.Size(240, 22);
			this.txtNhapMaTran.TabIndex = 3;
			this.txtNhapMaTran.TextChanged += new System.EventHandler(this.txtNhapMaTran_TextChanged);
			// 
			// txtMaTran
			// 
			this.txtMaTran.Enabled = false;
			this.txtMaTran.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaTran.Location = new System.Drawing.Point(6, 56);
			this.txtMaTran.Multiline = true;
			this.txtMaTran.Name = "txtMaTran";
			this.txtMaTran.Size = new System.Drawing.Size(255, 154);
			this.txtMaTran.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pictureBox2);
			this.groupBox2.Controls.Add(this.lblLoi);
			this.groupBox2.Controls.Add(this.lblSokyTu);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.btnDuyChuyen);
			this.groupBox2.Controls.Add(this.btnGiaiMa);
			this.groupBox2.Controls.Add(this.btnMaHoa);
			this.groupBox2.Controls.Add(this.txtXuatVanBan);
			this.groupBox2.Controls.Add(this.txtNhapVanBan);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.groupBox2.Location = new System.Drawing.Point(29, 291);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(531, 181);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mã hóa, Giải mã";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(379, 118);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(60, 60);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 10;
			this.pictureBox2.TabStop = false;
			// 
			// lblLoi
			// 
			this.lblLoi.AutoSize = true;
			this.lblLoi.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoi.ForeColor = System.Drawing.Color.Red;
			this.lblLoi.Location = new System.Drawing.Point(6, 161);
			this.lblLoi.Name = "lblLoi";
			this.lblLoi.Size = new System.Drawing.Size(377, 17);
			this.lblLoi.TabIndex = 9;
			this.lblLoi.Text = "Văn bản đầu vào phải là chữ thường viết liền không dấu!!!";
			// 
			// lblSokyTu
			// 
			this.lblSokyTu.AutoSize = true;
			this.lblSokyTu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblSokyTu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSokyTu.ForeColor = System.Drawing.Color.Black;
			this.lblSokyTu.Location = new System.Drawing.Point(178, 131);
			this.lblSokyTu.Name = "lblSokyTu";
			this.lblSokyTu.Size = new System.Drawing.Size(31, 13);
			this.lblSokyTu.TabIndex = 7;
			this.lblSokyTu.Text = "(199)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(321, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Văn bản đầu ra:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(6, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Văn bản đầu vào:";
			// 
			// btnDuyChuyen
			// 
			this.btnDuyChuyen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDuyChuyen.ForeColor = System.Drawing.Color.Black;
			this.btnDuyChuyen.Location = new System.Drawing.Point(229, 108);
			this.btnDuyChuyen.Name = "btnDuyChuyen";
			this.btnDuyChuyen.Size = new System.Drawing.Size(75, 23);
			this.btnDuyChuyen.TabIndex = 6;
			this.btnDuyChuyen.Text = "<<";
			this.btnDuyChuyen.UseVisualStyleBackColor = true;
			this.btnDuyChuyen.Click += new System.EventHandler(this.btnDuyChuyen_Click);
			// 
			// btnGiaiMa
			// 
			this.btnGiaiMa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGiaiMa.ForeColor = System.Drawing.Color.Black;
			this.btnGiaiMa.Location = new System.Drawing.Point(229, 79);
			this.btnGiaiMa.Name = "btnGiaiMa";
			this.btnGiaiMa.Size = new System.Drawing.Size(75, 23);
			this.btnGiaiMa.TabIndex = 5;
			this.btnGiaiMa.Text = "Giải mã";
			this.btnGiaiMa.UseVisualStyleBackColor = true;
			this.btnGiaiMa.Click += new System.EventHandler(this.btnGiaiMa_Click);
			// 
			// btnMaHoa
			// 
			this.btnMaHoa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMaHoa.ForeColor = System.Drawing.Color.Black;
			this.btnMaHoa.Location = new System.Drawing.Point(229, 50);
			this.btnMaHoa.Name = "btnMaHoa";
			this.btnMaHoa.Size = new System.Drawing.Size(75, 23);
			this.btnMaHoa.TabIndex = 4;
			this.btnMaHoa.Text = "Mã hóa";
			this.btnMaHoa.UseVisualStyleBackColor = true;
			this.btnMaHoa.Click += new System.EventHandler(this.btnMaHoa_Click);
			// 
			// txtXuatVanBan
			// 
			this.txtXuatVanBan.Location = new System.Drawing.Point(320, 52);
			this.txtXuatVanBan.Multiline = true;
			this.txtXuatVanBan.Name = "txtXuatVanBan";
			this.txtXuatVanBan.Size = new System.Drawing.Size(205, 99);
			this.txtXuatVanBan.TabIndex = 3;
			// 
			// txtNhapVanBan
			// 
			this.txtNhapVanBan.Location = new System.Drawing.Point(6, 50);
			this.txtNhapVanBan.Multiline = true;
			this.txtNhapVanBan.Name = "txtNhapVanBan";
			this.txtNhapVanBan.Size = new System.Drawing.Size(205, 99);
			this.txtNhapVanBan.TabIndex = 1;
			this.txtNhapVanBan.TextChanged += new System.EventHandler(this.txtNhapVanBan_TextChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(550, 458);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(37, 27);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Navy;
			this.label3.Location = new System.Drawing.Point(45, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(509, 25);
			this.label3.TabIndex = 3;
			this.label3.Text = "Mô phỏng Mã Hóa và Giải Mã theo phương pháp PlayFair";
			// 
			// timer1
			// 
			this.timer1.Interval = 3000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AcceptButton = this.btnMaHoa;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(587, 484);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Mã hóa PlayFair";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRandomKhoa;
		private System.Windows.Forms.TextBox txtNhapMaTran;
		private System.Windows.Forms.TextBox txtMaTran;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblSokyTu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDuyChuyen;
		private System.Windows.Forms.Button btnGiaiMa;
		private System.Windows.Forms.Button btnMaHoa;
		private System.Windows.Forms.TextBox txtXuatVanBan;
		private System.Windows.Forms.TextBox txtNhapVanBan;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lblLoi;
		private System.Windows.Forms.Timer timer1;
	}
}

