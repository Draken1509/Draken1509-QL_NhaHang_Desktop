namespace CustomControlThongKe
{
    partial class cardThucAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cardThucAn));
            this.pic_food = new Guna.UI.WinForms.GunaPictureBox();
            this.txt_tenmon = new System.Windows.Forms.Label();
            this.txt_giaban = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_food)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_food
            // 
            this.pic_food.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_food.BackColor = System.Drawing.Color.Transparent;
            this.pic_food.BaseColor = System.Drawing.Color.White;
            this.pic_food.Image = ((System.Drawing.Image)(resources.GetObject("pic_food.Image")));
            this.pic_food.Location = new System.Drawing.Point(4, 3);
            this.pic_food.Name = "pic_food";
            this.pic_food.Radius = 10;
            this.pic_food.Size = new System.Drawing.Size(164, 106);
            this.pic_food.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_food.TabIndex = 0;
            this.pic_food.TabStop = false;
            // 
            // txt_tenmon
            // 
            this.txt_tenmon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tenmon.AutoSize = true;
            this.txt_tenmon.BackColor = System.Drawing.Color.Transparent;
            this.txt_tenmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_tenmon.Location = new System.Drawing.Point(32, 112);
            this.txt_tenmon.Name = "txt_tenmon";
            this.txt_tenmon.Size = new System.Drawing.Size(153, 20);
            this.txt_tenmon.TabIndex = 1;
            this.txt_tenmon.Text = "Bánh số 1 ăn mê ly";
            this.txt_tenmon.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txt_giaban
            // 
            this.txt_giaban.AutoSize = true;
            this.txt_giaban.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_giaban.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_giaban.Location = new System.Drawing.Point(55, 159);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(58, 17);
            this.txt_giaban.TabIndex = 2;
            this.txt_giaban.Text = "18,000";
            this.txt_giaban.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardThucAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.txt_giaban);
            this.Controls.Add(this.txt_tenmon);
            this.Controls.Add(this.pic_food);
            this.Name = "cardThucAn";
            this.Size = new System.Drawing.Size(171, 186);
            ((System.ComponentModel.ISupportInitialize)(this.pic_food)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox pic_food;
        private System.Windows.Forms.Label txt_tenmon;
        private System.Windows.Forms.Label txt_giaban;
    }
}
