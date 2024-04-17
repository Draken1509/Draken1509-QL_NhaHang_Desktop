namespace QuanLyNhaHang
{
    partial class frmSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbo_themnhom = new Guna.UI.WinForms.GunaComboBox();
            this.gunaImageButton2 = new Guna.UI.WinForms.GunaImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_tatCa = new Guna.UI.WinForms.GunaButton();
            this.btn_themSP = new Guna.UI.WinForms.GunaCircleButton();
            this.textBoxSearch = new Guna.UI.WinForms.GunaTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gunaImageButton1 = new Guna.UI.WinForms.GunaImageButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_drink = new Guna.UI.WinForms.GunaButton();
            this.btn_snack = new Guna.UI.WinForms.GunaButton();
            this.btn_Bento = new Guna.UI.WinForms.GunaButton();
            this.btn_spy = new Guna.UI.WinForms.GunaButton();
            this.btn_wwing = new Guna.UI.WinForms.GunaButton();
            this.btn_friedChicken = new Guna.UI.WinForms.GunaButton();
            this.btn_Burger = new Guna.UI.WinForms.GunaButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dtgv_sanpham = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_sanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.cbo_themnhom);
            this.panel1.Controls.Add(this.gunaImageButton2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 74);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cbo_themnhom
            // 
            this.cbo_themnhom.BackColor = System.Drawing.Color.Transparent;
            this.cbo_themnhom.BaseColor = System.Drawing.Color.White;
            this.cbo_themnhom.BorderColor = System.Drawing.Color.Silver;
            this.cbo_themnhom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_themnhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_themnhom.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_themnhom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_themnhom.ForeColor = System.Drawing.Color.Black;
            this.cbo_themnhom.FormattingEnabled = true;
            this.cbo_themnhom.Items.AddRange(new object[] {
            "Thêm nhóm",
            "Danh sách nhóm",
            "Nguyên vật liệu",
            "In mã vạch sản phẩm",
            "Sắp xếp món",
            "Sắp xếp danh mục"});
            this.cbo_themnhom.Location = new System.Drawing.Point(680, 22);
            this.cbo_themnhom.Name = "cbo_themnhom";
            this.cbo_themnhom.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_themnhom.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_themnhom.Size = new System.Drawing.Size(241, 31);
            this.cbo_themnhom.TabIndex = 2;
            // 
            // gunaImageButton2
            // 
            this.gunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("gunaImageButton2.Image")));
            this.gunaImageButton2.ImageSize = new System.Drawing.Size(34, 34);
            this.gunaImageButton2.Location = new System.Drawing.Point(1018, 3);
            this.gunaImageButton2.Name = "gunaImageButton2";
            this.gunaImageButton2.OnHoverImage = null;
            this.gunaImageButton2.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            this.gunaImageButton2.Size = new System.Drawing.Size(63, 65);
            this.gunaImageButton2.TabIndex = 1;
            this.gunaImageButton2.Click += new System.EventHandler(this.gunaImageButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(120, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách hàng hóa - dịch vụ";
            // 
            // btn_tatCa
            // 
            this.btn_tatCa.AnimationHoverSpeed = 0.07F;
            this.btn_tatCa.AnimationSpeed = 0.03F;
            this.btn_tatCa.BackColor = System.Drawing.Color.Transparent;
            this.btn_tatCa.BaseColor = System.Drawing.Color.White;
            this.btn_tatCa.BorderColor = System.Drawing.Color.Gray;
            this.btn_tatCa.BorderSize = 1;
            this.btn_tatCa.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_tatCa.FocusedColor = System.Drawing.Color.Empty;
            this.btn_tatCa.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tatCa.ForeColor = System.Drawing.Color.Gray;
            this.btn_tatCa.Image = null;
            this.btn_tatCa.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_tatCa.Location = new System.Drawing.Point(63, 19);
            this.btn_tatCa.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_tatCa.Name = "btn_tatCa";
            this.btn_tatCa.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_tatCa.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_tatCa.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_tatCa.OnHoverImage = null;
            this.btn_tatCa.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_tatCa.Radius = 5;
            this.btn_tatCa.Size = new System.Drawing.Size(76, 42);
            this.btn_tatCa.TabIndex = 4;
            this.btn_tatCa.Text = "Tất cả";
            this.btn_tatCa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_tatCa.Click += new System.EventHandler(this.btn_tatCa_Click);
            // 
            // btn_themSP
            // 
            this.btn_themSP.AnimationHoverSpeed = 0.07F;
            this.btn_themSP.AnimationSpeed = 0.03F;
            this.btn_themSP.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_themSP.BorderColor = System.Drawing.Color.Black;
            this.btn_themSP.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_themSP.FocusedColor = System.Drawing.Color.Empty;
            this.btn_themSP.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themSP.ForeColor = System.Drawing.Color.White;
            this.btn_themSP.Image = null;
            this.btn_themSP.ImageSize = new System.Drawing.Size(52, 52);
            this.btn_themSP.Location = new System.Drawing.Point(38, 10);
            this.btn_themSP.Margin = new System.Windows.Forms.Padding(10);
            this.btn_themSP.Name = "btn_themSP";
            this.btn_themSP.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_themSP.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_themSP.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_themSP.OnHoverImage = null;
            this.btn_themSP.OnPressedColor = System.Drawing.Color.Black;
            this.btn_themSP.Padding = new System.Windows.Forms.Padding(3);
            this.btn_themSP.Size = new System.Drawing.Size(57, 59);
            this.btn_themSP.TabIndex = 3;
            this.btn_themSP.Text = "+";
            this.btn_themSP.Click += new System.EventHandler(this.btn_themSP_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.textBoxSearch.BaseColor = System.Drawing.Color.White;
            this.textBoxSearch.BorderColor = System.Drawing.Color.Silver;
            this.textBoxSearch.BorderSize = 1;
            this.textBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearch.FocusedBaseColor = System.Drawing.Color.White;
            this.textBoxSearch.FocusedBorderColor = System.Drawing.Color.Gray;
            this.textBoxSearch.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PasswordChar = '\0';
            this.textBoxSearch.Radius = 5;
            this.textBoxSearch.SelectedText = "";
            this.textBoxSearch.Size = new System.Drawing.Size(1015, 67);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "Nhập tên để tìm kiếm";
            this.textBoxSearch.MouseEnter += new System.EventHandler(this.textBoxSearch_MouseEnter);
            this.textBoxSearch.MouseLeave += new System.EventHandler(this.textBoxSearch_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1173, 22);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.gunaImageButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1173, 67);
            this.panel3.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBoxSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(63, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1015, 67);
            this.panel5.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1078, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(95, 67);
            this.panel4.TabIndex = 9;
            // 
            // gunaImageButton1
            // 
            this.gunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaImageButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaImageButton1.Image")));
            this.gunaImageButton1.ImageSize = new System.Drawing.Size(34, 34);
            this.gunaImageButton1.Location = new System.Drawing.Point(0, 0);
            this.gunaImageButton1.Name = "gunaImageButton1";
            this.gunaImageButton1.OnHoverImage = null;
            this.gunaImageButton1.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            this.gunaImageButton1.Size = new System.Drawing.Size(63, 67);
            this.gunaImageButton1.TabIndex = 2;
            this.gunaImageButton1.Click += new System.EventHandler(this.gunaImageButton1_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_drink);
            this.panel6.Controls.Add(this.btn_snack);
            this.panel6.Controls.Add(this.btn_Bento);
            this.panel6.Controls.Add(this.btn_spy);
            this.panel6.Controls.Add(this.btn_wwing);
            this.panel6.Controls.Add(this.btn_friedChicken);
            this.panel6.Controls.Add(this.btn_Burger);
            this.panel6.Controls.Add(this.btn_tatCa);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 163);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1173, 91);
            this.panel6.TabIndex = 9;
            // 
            // btn_drink
            // 
            this.btn_drink.AnimationHoverSpeed = 0.07F;
            this.btn_drink.AnimationSpeed = 0.03F;
            this.btn_drink.BackColor = System.Drawing.Color.Transparent;
            this.btn_drink.BaseColor = System.Drawing.Color.White;
            this.btn_drink.BorderColor = System.Drawing.Color.Gray;
            this.btn_drink.BorderSize = 1;
            this.btn_drink.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_drink.FocusedColor = System.Drawing.Color.Empty;
            this.btn_drink.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_drink.ForeColor = System.Drawing.Color.Gray;
            this.btn_drink.Image = null;
            this.btn_drink.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_drink.Location = new System.Drawing.Point(1047, 19);
            this.btn_drink.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_drink.Name = "btn_drink";
            this.btn_drink.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_drink.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_drink.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_drink.OnHoverImage = null;
            this.btn_drink.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_drink.Radius = 5;
            this.btn_drink.Size = new System.Drawing.Size(76, 42);
            this.btn_drink.TabIndex = 11;
            this.btn_drink.Text = "Drinks";
            this.btn_drink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_drink.Click += new System.EventHandler(this.btn_drink_Click);
            // 
            // btn_snack
            // 
            this.btn_snack.AnimationHoverSpeed = 0.07F;
            this.btn_snack.AnimationSpeed = 0.03F;
            this.btn_snack.BackColor = System.Drawing.Color.Transparent;
            this.btn_snack.BaseColor = System.Drawing.Color.White;
            this.btn_snack.BorderColor = System.Drawing.Color.Gray;
            this.btn_snack.BorderSize = 1;
            this.btn_snack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_snack.FocusedColor = System.Drawing.Color.Empty;
            this.btn_snack.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_snack.ForeColor = System.Drawing.Color.Gray;
            this.btn_snack.Image = null;
            this.btn_snack.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_snack.Location = new System.Drawing.Point(951, 19);
            this.btn_snack.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_snack.Name = "btn_snack";
            this.btn_snack.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_snack.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_snack.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_snack.OnHoverImage = null;
            this.btn_snack.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_snack.Radius = 5;
            this.btn_snack.Size = new System.Drawing.Size(76, 42);
            this.btn_snack.TabIndex = 10;
            this.btn_snack.Text = "Snacks";
            this.btn_snack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_snack.Click += new System.EventHandler(this.btn_snack_Click);
            // 
            // btn_Bento
            // 
            this.btn_Bento.AnimationHoverSpeed = 0.07F;
            this.btn_Bento.AnimationSpeed = 0.03F;
            this.btn_Bento.BackColor = System.Drawing.Color.Transparent;
            this.btn_Bento.BaseColor = System.Drawing.Color.White;
            this.btn_Bento.BorderColor = System.Drawing.Color.Gray;
            this.btn_Bento.BorderSize = 1;
            this.btn_Bento.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Bento.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Bento.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bento.ForeColor = System.Drawing.Color.Gray;
            this.btn_Bento.Image = null;
            this.btn_Bento.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Bento.Location = new System.Drawing.Point(845, 19);
            this.btn_Bento.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_Bento.Name = "btn_Bento";
            this.btn_Bento.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_Bento.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Bento.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Bento.OnHoverImage = null;
            this.btn_Bento.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_Bento.Radius = 5;
            this.btn_Bento.Size = new System.Drawing.Size(76, 42);
            this.btn_Bento.TabIndex = 9;
            this.btn_Bento.Text = "Bento";
            this.btn_Bento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Bento.Click += new System.EventHandler(this.btn_Bento_Click);
            // 
            // btn_spy
            // 
            this.btn_spy.AnimationHoverSpeed = 0.07F;
            this.btn_spy.AnimationSpeed = 0.03F;
            this.btn_spy.BackColor = System.Drawing.Color.Transparent;
            this.btn_spy.BaseColor = System.Drawing.Color.White;
            this.btn_spy.BorderColor = System.Drawing.Color.Gray;
            this.btn_spy.BorderSize = 1;
            this.btn_spy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_spy.FocusedColor = System.Drawing.Color.Empty;
            this.btn_spy.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_spy.ForeColor = System.Drawing.Color.Gray;
            this.btn_spy.Image = null;
            this.btn_spy.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_spy.Location = new System.Drawing.Point(639, 19);
            this.btn_spy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_spy.Name = "btn_spy";
            this.btn_spy.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_spy.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_spy.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_spy.OnHoverImage = null;
            this.btn_spy.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_spy.Radius = 5;
            this.btn_spy.Size = new System.Drawing.Size(177, 42);
            this.btn_spy.TabIndex = 8;
            this.btn_spy.Text = "Spicy Fried Chicken";
            this.btn_spy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_spy.Click += new System.EventHandler(this.btn_spy_Click);
            // 
            // btn_wwing
            // 
            this.btn_wwing.AnimationHoverSpeed = 0.07F;
            this.btn_wwing.AnimationSpeed = 0.03F;
            this.btn_wwing.BackColor = System.Drawing.Color.Transparent;
            this.btn_wwing.BaseColor = System.Drawing.Color.White;
            this.btn_wwing.BorderColor = System.Drawing.Color.Gray;
            this.btn_wwing.BorderSize = 1;
            this.btn_wwing.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_wwing.FocusedColor = System.Drawing.Color.Empty;
            this.btn_wwing.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_wwing.ForeColor = System.Drawing.Color.Gray;
            this.btn_wwing.Image = null;
            this.btn_wwing.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_wwing.Location = new System.Drawing.Point(438, 19);
            this.btn_wwing.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_wwing.Name = "btn_wwing";
            this.btn_wwing.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_wwing.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_wwing.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_wwing.OnHoverImage = null;
            this.btn_wwing.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_wwing.Radius = 5;
            this.btn_wwing.Size = new System.Drawing.Size(177, 42);
            this.btn_wwing.TabIndex = 7;
            this.btn_wwing.Text = "Fried Chicken Wing";
            this.btn_wwing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_wwing.Click += new System.EventHandler(this.btn_wwing_Click);
            // 
            // btn_friedChicken
            // 
            this.btn_friedChicken.AnimationHoverSpeed = 0.07F;
            this.btn_friedChicken.AnimationSpeed = 0.03F;
            this.btn_friedChicken.BackColor = System.Drawing.Color.Transparent;
            this.btn_friedChicken.BaseColor = System.Drawing.Color.White;
            this.btn_friedChicken.BorderColor = System.Drawing.Color.Gray;
            this.btn_friedChicken.BorderSize = 1;
            this.btn_friedChicken.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_friedChicken.FocusedColor = System.Drawing.Color.Empty;
            this.btn_friedChicken.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_friedChicken.ForeColor = System.Drawing.Color.Gray;
            this.btn_friedChicken.Image = null;
            this.btn_friedChicken.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_friedChicken.Location = new System.Drawing.Point(269, 19);
            this.btn_friedChicken.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_friedChicken.Name = "btn_friedChicken";
            this.btn_friedChicken.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_friedChicken.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_friedChicken.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_friedChicken.OnHoverImage = null;
            this.btn_friedChicken.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_friedChicken.Radius = 5;
            this.btn_friedChicken.Size = new System.Drawing.Size(135, 42);
            this.btn_friedChicken.TabIndex = 6;
            this.btn_friedChicken.Text = "Fried Chicken";
            this.btn_friedChicken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_friedChicken.Click += new System.EventHandler(this.btn_friedChicken_Click);
            // 
            // btn_Burger
            // 
            this.btn_Burger.AnimationHoverSpeed = 0.07F;
            this.btn_Burger.AnimationSpeed = 0.03F;
            this.btn_Burger.BackColor = System.Drawing.Color.Transparent;
            this.btn_Burger.BaseColor = System.Drawing.Color.White;
            this.btn_Burger.BorderColor = System.Drawing.Color.Gray;
            this.btn_Burger.BorderSize = 1;
            this.btn_Burger.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Burger.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Burger.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Burger.ForeColor = System.Drawing.Color.Gray;
            this.btn_Burger.Image = null;
            this.btn_Burger.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Burger.Location = new System.Drawing.Point(163, 19);
            this.btn_Burger.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_Burger.Name = "btn_Burger";
            this.btn_Burger.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(3)))));
            this.btn_Burger.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Burger.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Burger.OnHoverImage = null;
            this.btn_Burger.OnPressedColor = System.Drawing.Color.Maroon;
            this.btn_Burger.Radius = 5;
            this.btn_Burger.Size = new System.Drawing.Size(76, 42);
            this.btn_Burger.TabIndex = 5;
            this.btn_Burger.Text = "Burger";
            this.btn_Burger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Burger.Click += new System.EventHandler(this.btn_Burger_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 254);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1173, 672);
            this.panel7.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 597);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1173, 75);
            this.panel9.TabIndex = 12;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btn_themSP);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(1002, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(121, 75);
            this.panel11.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(1123, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(50, 75);
            this.panel10.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dtgv_sanpham);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1173, 672);
            this.panel8.TabIndex = 11;
            // 
            // dtgv_sanpham
            // 
            this.dtgv_sanpham.AllowUserToResizeRows = false;
            this.dtgv_sanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_sanpham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgv_sanpham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_sanpham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_sanpham.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(300, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_sanpham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_sanpham.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_sanpham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_sanpham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_sanpham.GridColor = System.Drawing.Color.LightGray;
            this.dtgv_sanpham.Location = new System.Drawing.Point(0, 0);
            this.dtgv_sanpham.Name = "dtgv_sanpham";
            this.dtgv_sanpham.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_sanpham.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_sanpham.RowHeadersVisible = false;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(300, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtgv_sanpham.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv_sanpham.RowTemplate.Height = 50;
            this.dtgv_sanpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_sanpham.Size = new System.Drawing.Size(1173, 672);
            this.dtgv_sanpham.TabIndex = 1;
            this.dtgv_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_sanpham_CellClick);
            this.dtgv_sanpham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgv_sanpham_CellFormatting);
            this.dtgv_sanpham.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgv_sanpham_RowPostPaint);
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 926);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_sanpham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaImageButton gunaImageButton2;
        private Guna.UI.WinForms.GunaButton btn_tatCa;
        private Guna.UI.WinForms.GunaCircleButton btn_themSP;
        private Guna.UI.WinForms.GunaImageButton gunaImageButton1;
        private Guna.UI.WinForms.GunaTextBox textBoxSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private Guna.UI.WinForms.GunaComboBox cbo_themnhom;
        private Guna.UI.WinForms.GunaButton btn_drink;
        private Guna.UI.WinForms.GunaButton btn_snack;
        private Guna.UI.WinForms.GunaButton btn_Bento;
        private Guna.UI.WinForms.GunaButton btn_spy;
        private Guna.UI.WinForms.GunaButton btn_wwing;
        private Guna.UI.WinForms.GunaButton btn_friedChicken;
        private Guna.UI.WinForms.GunaButton btn_Burger;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtgv_sanpham;
    }
}