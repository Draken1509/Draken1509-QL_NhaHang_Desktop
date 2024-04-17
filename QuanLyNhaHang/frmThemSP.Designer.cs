namespace QuanLyNhaHang
{
    partial class frmThemSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemSP));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_idmon = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_ThongtinSP = new Guna.UI.WinForms.GunaButton();
            this.line_thongtinsanpham = new Guna.UI.WinForms.GunaGradient2Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.line_thnahphan = new Guna.UI.WinForms.GunaGradient2Panel();
            this.btn_thanhPhan = new Guna.UI.WinForms.GunaButton();
            this.painMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.panel1.Controls.Add(this.lbl_idmon);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 74);
            this.panel1.TabIndex = 0;
            // 
            // lbl_idmon
            // 
            this.lbl_idmon.AutoSize = true;
            this.lbl_idmon.Location = new System.Drawing.Point(716, 20);
            this.lbl_idmon.Name = "lbl_idmon";
            this.lbl_idmon.Size = new System.Drawing.Size(46, 17);
            this.lbl_idmon.TabIndex = 5;
            this.lbl_idmon.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(78, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm sản phẩm mới";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1367, 72);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1367, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_ThongtinSP);
            this.panel3.Controls.Add(this.line_thongtinsanpham);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(677, 66);
            this.panel3.TabIndex = 0;
            // 
            // btn_ThongtinSP
            // 
            this.btn_ThongtinSP.AnimationHoverSpeed = 0.07F;
            this.btn_ThongtinSP.AnimationSpeed = 0.03F;
            this.btn_ThongtinSP.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThongtinSP.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_ThongtinSP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_ThongtinSP.BorderSize = 1;
            this.btn_ThongtinSP.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_ThongtinSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ThongtinSP.FocusedColor = System.Drawing.Color.Empty;
            this.btn_ThongtinSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongtinSP.ForeColor = System.Drawing.Color.White;
            this.btn_ThongtinSP.Image = null;
            this.btn_ThongtinSP.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_ThongtinSP.Location = new System.Drawing.Point(0, 0);
            this.btn_ThongtinSP.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_ThongtinSP.Name = "btn_ThongtinSP";
            this.btn_ThongtinSP.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_ThongtinSP.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_ThongtinSP.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ThongtinSP.OnHoverImage = null;
            this.btn_ThongtinSP.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ThongtinSP.Radius = 5;
            this.btn_ThongtinSP.Size = new System.Drawing.Size(677, 62);
            this.btn_ThongtinSP.TabIndex = 5;
            this.btn_ThongtinSP.Text = "Thông tin sản phẩm";
            this.btn_ThongtinSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_ThongtinSP.Click += new System.EventHandler(this.btn_ThongtinSP_Click);
            // 
            // line_thongtinsanpham
            // 
            this.line_thongtinsanpham.BackColor = System.Drawing.Color.Transparent;
            this.line_thongtinsanpham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line_thongtinsanpham.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.line_thongtinsanpham.GradientColor1 = System.Drawing.Color.RoyalBlue;
            this.line_thongtinsanpham.GradientColor2 = System.Drawing.Color.RoyalBlue;
            this.line_thongtinsanpham.Location = new System.Drawing.Point(0, 62);
            this.line_thongtinsanpham.Name = "line_thongtinsanpham";
            this.line_thongtinsanpham.Size = new System.Drawing.Size(677, 4);
            this.line_thongtinsanpham.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.line_thnahphan);
            this.panel4.Controls.Add(this.btn_thanhPhan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(686, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(678, 66);
            this.panel4.TabIndex = 1;
            // 
            // line_thnahphan
            // 
            this.line_thnahphan.BackColor = System.Drawing.Color.Transparent;
            this.line_thnahphan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line_thnahphan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.line_thnahphan.GradientColor1 = System.Drawing.Color.RoyalBlue;
            this.line_thnahphan.GradientColor2 = System.Drawing.Color.RoyalBlue;
            this.line_thnahphan.Location = new System.Drawing.Point(0, 62);
            this.line_thnahphan.Name = "line_thnahphan";
            this.line_thnahphan.Size = new System.Drawing.Size(678, 4);
            this.line_thnahphan.TabIndex = 12;
            // 
            // btn_thanhPhan
            // 
            this.btn_thanhPhan.AnimationHoverSpeed = 0.07F;
            this.btn_thanhPhan.AnimationSpeed = 0.03F;
            this.btn_thanhPhan.BackColor = System.Drawing.Color.Transparent;
            this.btn_thanhPhan.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_thanhPhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_thanhPhan.BorderSize = 1;
            this.btn_thanhPhan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_thanhPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_thanhPhan.FocusedColor = System.Drawing.Color.Empty;
            this.btn_thanhPhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thanhPhan.ForeColor = System.Drawing.Color.White;
            this.btn_thanhPhan.Image = null;
            this.btn_thanhPhan.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_thanhPhan.Location = new System.Drawing.Point(0, 0);
            this.btn_thanhPhan.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_thanhPhan.Name = "btn_thanhPhan";
            this.btn_thanhPhan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_thanhPhan.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_thanhPhan.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_thanhPhan.OnHoverImage = null;
            this.btn_thanhPhan.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_thanhPhan.Radius = 5;
            this.btn_thanhPhan.Size = new System.Drawing.Size(678, 66);
            this.btn_thanhPhan.TabIndex = 6;
            this.btn_thanhPhan.Text = "Thành phần";
            this.btn_thanhPhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_thanhPhan.Click += new System.EventHandler(this.btn_thanhPhan_Click);
            // 
            // painMain
            // 
            this.painMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painMain.Location = new System.Drawing.Point(0, 146);
            this.painMain.Name = "painMain";
            this.painMain.Size = new System.Drawing.Size(1367, 536);
            this.painMain.TabIndex = 2;
            // 
            // frmThemSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 682);
            this.Controls.Add(this.painMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmThemSP";
            this.Text = "frmThemSP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThemSP_FormClosed);
            this.Load += new System.EventHandler(this.frmThemSP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI.WinForms.GunaButton btn_thanhPhan;
        private Guna.UI.WinForms.GunaButton btn_ThongtinSP;
        private Guna.UI.WinForms.GunaGradient2Panel line_thongtinsanpham;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaGradient2Panel line_thnahphan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_idmon;
        private System.Windows.Forms.Panel painMain;
    }
}