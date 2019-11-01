namespace StallusApp
{
    partial class Main_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GraphicQRCode_PB = new System.Windows.Forms.PictureBox();
            this.GenerateQRCode_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicQRCode_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GenerateQRCode_Button);
            this.groupBox1.Controls.Add(this.GraphicQRCode_PB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 669);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "I got the bike";
            // 
            // GraphicQRCode_PB
            // 
            this.GraphicQRCode_PB.Location = new System.Drawing.Point(9, 24);
            this.GraphicQRCode_PB.Name = "GraphicQRCode_PB";
            this.GraphicQRCode_PB.Padding = new System.Windows.Forms.Padding(13, 20, 0, 0);
            this.GraphicQRCode_PB.Size = new System.Drawing.Size(300, 300);
            this.GraphicQRCode_PB.TabIndex = 1;
            this.GraphicQRCode_PB.TabStop = false;
            // 
            // GenerateQRCode_Button
            // 
            this.GenerateQRCode_Button.Location = new System.Drawing.Point(9, 330);
            this.GenerateQRCode_Button.Name = "GenerateQRCode_Button";
            this.GenerateQRCode_Button.Size = new System.Drawing.Size(300, 52);
            this.GenerateQRCode_Button.TabIndex = 2;
            this.GenerateQRCode_Button.Text = "Generate QR Code";
            this.GenerateQRCode_Button.UseVisualStyleBackColor = true;
            this.GenerateQRCode_Button.Click += new System.EventHandler(this.GenerateQRCode_Button_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 693);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicQRCode_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox GraphicQRCode_PB;
        private System.Windows.Forms.Button GenerateQRCode_Button;
    }
}