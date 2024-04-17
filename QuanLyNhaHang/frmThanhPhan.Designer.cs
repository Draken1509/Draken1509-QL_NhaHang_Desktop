namespace QuanLyNhaHang
{
    partial class frmThanhPhan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_them = new Guna.UI.WinForms.GunaCircleButton();
            this.textBoxSearch = new Guna.UI.WinForms.GunaTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gunaImageButton1 = new Guna.UI.WinForms.GunaImageButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.dtgv_nguyenlieu = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_nguyenlieu)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_them
            // 
            this.btn_them.AnimationHoverSpeed = 0.07F;
            this.btn_them.AnimationSpeed = 0.03F;
            this.btn_them.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_them.BorderColor = System.Drawing.Color.Black;
            this.btn_them.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_them.FocusedColor = System.Drawing.Color.Empty;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Image = null;
            this.btn_them.ImageSize = new System.Drawing.Size(52, 52);
            this.btn_them.Location = new System.Drawing.Point(38, 0);
            this.btn_them.Margin = new System.Windows.Forms.Padding(10);
            this.btn_them.Name = "btn_them";
            this.btn_them.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_them.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_them.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_them.OnHoverImage = null;
            this.btn_them.OnPressedColor = System.Drawing.Color.Black;
            this.btn_them.Padding = new System.Windows.Forms.Padding(3);
            this.btn_them.Size = new System.Drawing.Size(70, 69);
            this.btn_them.TabIndex = 3;
            this.btn_them.Text = "+";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
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
            this.textBoxSearch.Size = new System.Drawing.Size(851, 67);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "Nhập tên để tìm kiếm nguyên liệu";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.gunaImageButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1009, 67);
            this.panel3.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBoxSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(63, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(851, 67);
            this.panel5.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(914, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(95, 67);
            this.panel4.TabIndex = 9;
            // 
            // gunaImageButton1
            // 
            this.gunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaImageButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaImageButton1.Image = global::QuanLyNhaHang.Properties.Resources.icons8_search_501;
            this.gunaImageButton1.ImageSize = new System.Drawing.Size(34, 34);
            this.gunaImageButton1.Location = new System.Drawing.Point(0, 0);
            this.gunaImageButton1.Name = "gunaImageButton1";
            this.gunaImageButton1.OnHoverImage = null;
            this.gunaImageButton1.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            this.gunaImageButton1.Size = new System.Drawing.Size(63, 67);
            this.gunaImageButton1.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 133);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1009, 793);
            this.panel7.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 718);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1009, 75);
            this.panel9.TabIndex = 12;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btn_them);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(838, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(121, 75);
            this.panel11.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(959, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(50, 75);
            this.panel10.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbl_msg);
            this.panel8.Controls.Add(this.dtgv_nguyenlieu);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1009, 793);
            this.panel8.TabIndex = 11;
            // 
            // lbl_msg
            // 
            this.lbl_msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_msg.Location = new System.Drawing.Point(414, 300);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(70, 22);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "Dữ liệu";
            // 
            // dtgv_nguyenlieu
            // 
            this.dtgv_nguyenlieu.AllowUserToResizeRows = false;
            this.dtgv_nguyenlieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_nguyenlieu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgv_nguyenlieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_nguyenlieu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_nguyenlieu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(300, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_nguyenlieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_nguyenlieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_nguyenlieu.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(500, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_nguyenlieu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_nguyenlieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_nguyenlieu.GridColor = System.Drawing.Color.LightGray;
            this.dtgv_nguyenlieu.Location = new System.Drawing.Point(0, 0);
            this.dtgv_nguyenlieu.Name = "dtgv_nguyenlieu";
            this.dtgv_nguyenlieu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_nguyenlieu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_nguyenlieu.RowHeadersVisible = false;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(400, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtgv_nguyenlieu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv_nguyenlieu.RowTemplate.Height = 50;
            this.dtgv_nguyenlieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_nguyenlieu.Size = new System.Drawing.Size(1009, 793);
            this.dtgv_nguyenlieu.TabIndex = 1;
            this.dtgv_nguyenlieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_nguyenlieu_CellClick);
            this.dtgv_nguyenlieu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgv_nguyenlieu_CellFormatting);
            this.dtgv_nguyenlieu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgv_nguyenlieu_RowPostPaint);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 89);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1009, 44);
            this.panel6.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 22);
            this.panel2.TabIndex = 7;
            // 
            // frmThanhPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 926);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "frmThanhPhan";
            this.Text = "frmThanhPhan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThanhPhan_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_nguyenlieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaCircleButton btn_them;
        private Guna.UI.WinForms.GunaImageButton gunaImageButton1;
        private Guna.UI.WinForms.GunaTextBox textBoxSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dtgv_nguyenlieu;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_msg;
    }
}