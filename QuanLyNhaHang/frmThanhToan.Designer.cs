namespace QuanLyNhaHang
{
    partial class frmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Panel();
            this.btn_tratien = new Guna.UI.WinForms.GunaButton();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_inhoadon = new Guna.UI.WinForms.GunaButton();
            this.dgv_voucher = new System.Windows.Forms.DataGridView();
            this.btn_addvoucher = new Guna.UI.WinForms.GunaButton();
            this.txt_voucher = new Guna.UI.WinForms.GunaTextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_tienmat = new Guna.UI.WinForms.GunaTileButton();
            this.btn_chuyenkhoan = new Guna.UI.WinForms.GunaTileButton();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_tongtien = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_magiamgia = new Guna.UI.WinForms.GunaTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_giamtien = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_giamphantram = new Guna.UI.WinForms.GunaTextBox();
            this.txt_tamtinh = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.btn_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_voucher)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 68);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(50, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thanh toán";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(615, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2, 780);
            this.label8.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tạm tính";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_back.Controls.Add(this.btn_tratien);
            this.btn_back.Controls.Add(this.label13);
            this.btn_back.Controls.Add(this.btn_inhoadon);
            this.btn_back.Controls.Add(this.dgv_voucher);
            this.btn_back.Controls.Add(this.btn_addvoucher);
            this.btn_back.Controls.Add(this.txt_voucher);
            this.btn_back.Controls.Add(this.panel7);
            this.btn_back.Controls.Add(this.panel6);
            this.btn_back.Controls.Add(this.panel3);
            this.btn_back.Controls.Add(this.txt_tamtinh);
            this.btn_back.Controls.Add(this.label2);
            this.btn_back.Location = new System.Drawing.Point(0, 66);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(1170, 428);
            this.btn_back.TabIndex = 16;
            this.btn_back.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_back_Paint);
            // 
            // btn_tratien
            // 
            this.btn_tratien.AnimationHoverSpeed = 0.07F;
            this.btn_tratien.AnimationSpeed = 0.03F;
            this.btn_tratien.BackColor = System.Drawing.Color.Transparent;
            this.btn_tratien.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_tratien.BorderColor = System.Drawing.Color.Black;
            this.btn_tratien.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_tratien.FocusedColor = System.Drawing.Color.Empty;
            this.btn_tratien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_tratien.ForeColor = System.Drawing.Color.White;
            this.btn_tratien.Image = null;
            this.btn_tratien.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_tratien.Location = new System.Drawing.Point(823, 356);
            this.btn_tratien.Name = "btn_tratien";
            this.btn_tratien.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_tratien.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_tratien.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_tratien.OnHoverImage = null;
            this.btn_tratien.OnPressedColor = System.Drawing.Color.Black;
            this.btn_tratien.Radius = 20;
            this.btn_tratien.Size = new System.Drawing.Size(160, 42);
            this.btn_tratien.TabIndex = 32;
            this.btn_tratien.Text = "Trả tiền";
            this.btn_tratien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_tratien.Click += new System.EventHandler(this.btn_tratien_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(640, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 23;
            this.label13.Text = "Mã voucher";
            // 
            // btn_inhoadon
            // 
            this.btn_inhoadon.AnimationHoverSpeed = 0.07F;
            this.btn_inhoadon.AnimationSpeed = 0.03F;
            this.btn_inhoadon.BackColor = System.Drawing.Color.Transparent;
            this.btn_inhoadon.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_inhoadon.BorderColor = System.Drawing.Color.Black;
            this.btn_inhoadon.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_inhoadon.FocusedColor = System.Drawing.Color.Empty;
            this.btn_inhoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_inhoadon.ForeColor = System.Drawing.Color.White;
            this.btn_inhoadon.Image = null;
            this.btn_inhoadon.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_inhoadon.Location = new System.Drawing.Point(999, 356);
            this.btn_inhoadon.Name = "btn_inhoadon";
            this.btn_inhoadon.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_inhoadon.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_inhoadon.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_inhoadon.OnHoverImage = null;
            this.btn_inhoadon.OnPressedColor = System.Drawing.Color.Black;
            this.btn_inhoadon.Radius = 20;
            this.btn_inhoadon.Size = new System.Drawing.Size(160, 42);
            this.btn_inhoadon.TabIndex = 25;
            this.btn_inhoadon.Text = "In hóa đơn";
            this.btn_inhoadon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_inhoadon.Click += new System.EventHandler(this.btn_inhoadon_Click);
            // 
            // dgv_voucher
            // 
            this.dgv_voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_voucher.Location = new System.Drawing.Point(637, 160);
            this.dgv_voucher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_voucher.Name = "dgv_voucher";
            this.dgv_voucher.RowTemplate.Height = 28;
            this.dgv_voucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_voucher.Size = new System.Drawing.Size(522, 168);
            this.dgv_voucher.TabIndex = 31;
            this.dgv_voucher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_voucher_CellClick);
            // 
            // btn_addvoucher
            // 
            this.btn_addvoucher.AnimationHoverSpeed = 0.07F;
            this.btn_addvoucher.AnimationSpeed = 0.03F;
            this.btn_addvoucher.BackColor = System.Drawing.Color.Transparent;
            this.btn_addvoucher.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_addvoucher.BorderColor = System.Drawing.Color.Black;
            this.btn_addvoucher.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_addvoucher.FocusedColor = System.Drawing.Color.Empty;
            this.btn_addvoucher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_addvoucher.ForeColor = System.Drawing.Color.White;
            this.btn_addvoucher.Image = null;
            this.btn_addvoucher.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_addvoucher.Location = new System.Drawing.Point(999, 106);
            this.btn_addvoucher.Name = "btn_addvoucher";
            this.btn_addvoucher.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_addvoucher.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_addvoucher.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_addvoucher.OnHoverImage = null;
            this.btn_addvoucher.OnPressedColor = System.Drawing.Color.Black;
            this.btn_addvoucher.Radius = 20;
            this.btn_addvoucher.Size = new System.Drawing.Size(160, 42);
            this.btn_addvoucher.TabIndex = 24;
            this.btn_addvoucher.Text = "Xác nhận";
            this.btn_addvoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_addvoucher.Click += new System.EventHandler(this.btn_addvoucher_Click);
            // 
            // txt_voucher
            // 
            this.txt_voucher.BackColor = System.Drawing.Color.Transparent;
            this.txt_voucher.BaseColor = System.Drawing.Color.White;
            this.txt_voucher.BorderColor = System.Drawing.Color.Silver;
            this.txt_voucher.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_voucher.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_voucher.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_voucher.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_voucher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_voucher.Location = new System.Drawing.Point(756, 58);
            this.txt_voucher.Name = "txt_voucher";
            this.txt_voucher.PasswordChar = '\0';
            this.txt_voucher.Radius = 10;
            this.txt_voucher.SelectedText = "";
            this.txt_voucher.Size = new System.Drawing.Size(402, 34);
            this.txt_voucher.TabIndex = 30;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel7.Controls.Add(this.btn_tienmat);
            this.panel7.Controls.Add(this.btn_chuyenkhoan);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Location = new System.Drawing.Point(3, 160);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(614, 168);
            this.panel7.TabIndex = 29;
            // 
            // btn_tienmat
            // 
            this.btn_tienmat.AnimationHoverSpeed = 0.07F;
            this.btn_tienmat.AnimationSpeed = 0.03F;
            this.btn_tienmat.BackColor = System.Drawing.Color.Transparent;
            this.btn_tienmat.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_tienmat.BorderColor = System.Drawing.Color.Black;
            this.btn_tienmat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_tienmat.FocusedColor = System.Drawing.Color.Empty;
            this.btn_tienmat.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_tienmat.ForeColor = System.Drawing.Color.White;
            this.btn_tienmat.Image = ((System.Drawing.Image)(resources.GetObject("btn_tienmat.Image")));
            this.btn_tienmat.ImageSize = new System.Drawing.Size(52, 52);
            this.btn_tienmat.Location = new System.Drawing.Point(168, 46);
            this.btn_tienmat.Name = "btn_tienmat";
            this.btn_tienmat.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_tienmat.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_tienmat.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_tienmat.OnHoverImage = null;
            this.btn_tienmat.OnPressedColor = System.Drawing.Color.Black;
            this.btn_tienmat.Radius = 10;
            this.btn_tienmat.Size = new System.Drawing.Size(116, 97);
            this.btn_tienmat.TabIndex = 30;
            this.btn_tienmat.Text = "Tiền mặt";
            this.btn_tienmat.Click += new System.EventHandler(this.btn_tienmat_Click);
            // 
            // btn_chuyenkhoan
            // 
            this.btn_chuyenkhoan.AnimationHoverSpeed = 0.07F;
            this.btn_chuyenkhoan.AnimationSpeed = 0.03F;
            this.btn_chuyenkhoan.BackColor = System.Drawing.Color.Transparent;
            this.btn_chuyenkhoan.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_chuyenkhoan.BorderColor = System.Drawing.Color.Black;
            this.btn_chuyenkhoan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_chuyenkhoan.FocusedColor = System.Drawing.Color.Empty;
            this.btn_chuyenkhoan.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chuyenkhoan.ForeColor = System.Drawing.Color.White;
            this.btn_chuyenkhoan.Image = ((System.Drawing.Image)(resources.GetObject("btn_chuyenkhoan.Image")));
            this.btn_chuyenkhoan.ImageSize = new System.Drawing.Size(52, 52);
            this.btn_chuyenkhoan.Location = new System.Drawing.Point(13, 47);
            this.btn_chuyenkhoan.Name = "btn_chuyenkhoan";
            this.btn_chuyenkhoan.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_chuyenkhoan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_chuyenkhoan.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_chuyenkhoan.OnHoverImage = null;
            this.btn_chuyenkhoan.OnPressedColor = System.Drawing.Color.Black;
            this.btn_chuyenkhoan.Radius = 10;
            this.btn_chuyenkhoan.Size = new System.Drawing.Size(116, 97);
            this.btn_chuyenkhoan.TabIndex = 29;
            this.btn_chuyenkhoan.Text = "Chuyển khoản";
            this.btn_chuyenkhoan.Click += new System.EventHandler(this.btn_chuyenkhoan_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(6, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Hình thức thanh toán";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel6.Controls.Add(this.txt_tongtien);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(0, 341);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(617, 57);
            this.panel6.TabIndex = 27;
            // 
            // txt_tongtien
            // 
            this.txt_tongtien.AutoSize = true;
            this.txt_tongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_tongtien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_tongtien.Location = new System.Drawing.Point(514, 21);
            this.txt_tongtien.Name = "txt_tongtien";
            this.txt_tongtien.Size = new System.Drawing.Size(84, 29);
            this.txt_tongtien.TabIndex = 25;
            this.txt_tongtien.Text = "25 000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(3, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 29);
            this.label10.TabIndex = 24;
            this.label10.Text = "Tổng tiền";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_magiamgia);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_giamtien);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_giamphantram);
            this.panel3.Location = new System.Drawing.Point(3, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(614, 100);
            this.panel3.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Mã giảm giá";
            // 
            // txt_magiamgia
            // 
            this.txt_magiamgia.BackColor = System.Drawing.Color.Transparent;
            this.txt_magiamgia.BaseColor = System.Drawing.Color.White;
            this.txt_magiamgia.BorderColor = System.Drawing.Color.Silver;
            this.txt_magiamgia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_magiamgia.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_magiamgia.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_magiamgia.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_magiamgia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_magiamgia.Location = new System.Drawing.Point(144, 11);
            this.txt_magiamgia.Name = "txt_magiamgia";
            this.txt_magiamgia.PasswordChar = '\0';
            this.txt_magiamgia.Radius = 10;
            this.txt_magiamgia.SelectedText = "";
            this.txt_magiamgia.Size = new System.Drawing.Size(424, 34);
            this.txt_magiamgia.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(573, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "đ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(340, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "%";
            // 
            // txt_giamtien
            // 
            this.txt_giamtien.BackColor = System.Drawing.Color.Transparent;
            this.txt_giamtien.BaseColor = System.Drawing.Color.White;
            this.txt_giamtien.BorderColor = System.Drawing.Color.Silver;
            this.txt_giamtien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giamtien.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_giamtien.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_giamtien.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_giamtien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_giamtien.Location = new System.Drawing.Point(378, 55);
            this.txt_giamtien.Name = "txt_giamtien";
            this.txt_giamtien.PasswordChar = '\0';
            this.txt_giamtien.Radius = 10;
            this.txt_giamtien.SelectedText = "";
            this.txt_giamtien.Size = new System.Drawing.Size(190, 34);
            this.txt_giamtien.TabIndex = 22;
            this.txt_giamtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Giảm giá";
            // 
            // txt_giamphantram
            // 
            this.txt_giamphantram.BackColor = System.Drawing.Color.Transparent;
            this.txt_giamphantram.BaseColor = System.Drawing.Color.White;
            this.txt_giamphantram.BorderColor = System.Drawing.Color.Silver;
            this.txt_giamphantram.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giamphantram.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_giamphantram.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_giamphantram.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_giamphantram.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_giamphantram.Location = new System.Drawing.Point(144, 54);
            this.txt_giamphantram.Name = "txt_giamphantram";
            this.txt_giamphantram.PasswordChar = '\0';
            this.txt_giamphantram.Radius = 10;
            this.txt_giamphantram.SelectedText = "";
            this.txt_giamphantram.Size = new System.Drawing.Size(190, 34);
            this.txt_giamphantram.TabIndex = 0;
            this.txt_giamphantram.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_tamtinh
            // 
            this.txt_tamtinh.AutoSize = true;
            this.txt_tamtinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_tamtinh.Location = new System.Drawing.Point(535, 15);
            this.txt_tamtinh.Name = "txt_tamtinh";
            this.txt_tamtinh.Size = new System.Drawing.Size(58, 20);
            this.txt_tamtinh.TabIndex = 16;
            this.txt_tamtinh.Text = "35,000";
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 492);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThanhToan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.btn_back.ResumeLayout(false);
            this.btn_back.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_voucher)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel btn_back;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txt_tamtinh;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaTextBox txt_giamphantram;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label txt_tongtien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private Guna.UI.WinForms.GunaTileButton btn_tienmat;
        private Guna.UI.WinForms.GunaTileButton btn_chuyenkhoan;
        private System.Windows.Forms.Label label13;
        private Guna.UI.WinForms.GunaButton btn_addvoucher;
        private Guna.UI.WinForms.GunaButton btn_inhoadon;
        private System.Windows.Forms.DataGridView dgv_voucher;
        private Guna.UI.WinForms.GunaTextBox txt_voucher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaTextBox txt_giamtien;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaTextBox txt_magiamgia;
        private Guna.UI.WinForms.GunaButton btn_tratien;
    }
}