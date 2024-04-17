namespace CustomControlThongKe
{
    partial class cardChiTietThucAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cardChiTietThucAn));
            this.txt_soluong = new System.Windows.Forms.Label();
            this.txt_tenmon = new System.Windows.Forms.Label();
            this.btn_del = new Guna.UI.WinForms.GunaPictureBox();
            this.txt_giaban = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_soluong
            // 
            this.txt_soluong.AutoSize = true;
            this.txt_soluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_soluong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_soluong.Location = new System.Drawing.Point(0, 10);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(35, 25);
            this.txt_soluong.TabIndex = 0;
            this.txt_soluong.Text = "x1";
            // 
            // txt_tenmon
            // 
            this.txt_tenmon.AutoSize = true;
            this.txt_tenmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_tenmon.Location = new System.Drawing.Point(32, 10);
            this.txt_tenmon.Name = "txt_tenmon";
            this.txt_tenmon.Size = new System.Drawing.Size(235, 25);
            this.txt_tenmon.TabIndex = 1;
            this.txt_tenmon.Text = "Hamberger ăn zo là mê";
            // 
            // btn_del
            // 
            this.btn_del.BaseColor = System.Drawing.Color.White;
            this.btn_del.Image = ((System.Drawing.Image)(resources.GetObject("btn_del.Image")));
            this.btn_del.Location = new System.Drawing.Point(339, 0);
            this.btn_del.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(32, 44);
            this.btn_del.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_del.TabIndex = 2;
            this.btn_del.TabStop = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // txt_giaban
            // 
            this.txt_giaban.AutoSize = true;
            this.txt_giaban.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_giaban.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_giaban.Location = new System.Drawing.Point(264, 12);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(64, 20);
            this.txt_giaban.TabIndex = 3;
            this.txt_giaban.Text = "12.000";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(3, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(369, 2);
            this.label7.TabIndex = 11;
            this.label7.Text = "label7";
            // 
            // cardChiTietThucAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_giaban);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.txt_tenmon);
            this.Controls.Add(this.txt_soluong);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "cardChiTietThucAn";
            this.Size = new System.Drawing.Size(464, 65);
            ((System.ComponentModel.ISupportInitialize)(this.btn_del)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_soluong;
        private System.Windows.Forms.Label txt_tenmon;
        private Guna.UI.WinForms.GunaPictureBox btn_del;
        private System.Windows.Forms.Label txt_giaban;
        private System.Windows.Forms.Label label7;
    }
}
