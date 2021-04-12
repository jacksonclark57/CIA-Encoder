
namespace CIA_Encoder
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
            this.UserIMG = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHiddenMessage = new System.Windows.Forms.TextBox();
            this.EncodeBTN = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.imgProgress = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.EncodedIMG = new System.Windows.Forms.PictureBox();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.Errormsg = new System.Windows.Forms.Label();
            this.encodedStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserIMG)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncodedIMG)).BeginInit();
            this.SuspendLayout();
            // 
            // UserIMG
            // 
            this.UserIMG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.UserIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserIMG.Location = new System.Drawing.Point(56, 66);
            this.UserIMG.Name = "UserIMG";
            this.UserIMG.Size = new System.Drawing.Size(219, 289);
            this.UserIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserIMG.TabIndex = 1;
            this.UserIMG.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chosen Image";
            // 
            // txtHiddenMessage
            // 
            this.txtHiddenMessage.Location = new System.Drawing.Point(317, 318);
            this.txtHiddenMessage.MaxLength = 256;
            this.txtHiddenMessage.Multiline = true;
            this.txtHiddenMessage.Name = "txtHiddenMessage";
            this.txtHiddenMessage.Size = new System.Drawing.Size(200, 68);
            this.txtHiddenMessage.TabIndex = 4;
            // 
            // EncodeBTN
            // 
            this.EncodeBTN.Enabled = false;
            this.EncodeBTN.Location = new System.Drawing.Point(317, 66);
            this.EncodeBTN.Name = "EncodeBTN";
            this.EncodeBTN.Size = new System.Drawing.Size(200, 47);
            this.EncodeBTN.TabIndex = 5;
            this.EncodeBTN.Text = "Encode";
            this.EncodeBTN.UseVisualStyleBackColor = true;
            this.EncodeBTN.Click += new System.EventHandler(this.encode_Click);
            // 
            // saveBTN
            // 
            this.saveBTN.Enabled = false;
            this.saveBTN.Location = new System.Drawing.Point(317, 133);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(200, 41);
            this.saveBTN.TabIndex = 6;
            this.saveBTN.Text = "SaveIMG";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.openToolStripMenuItem.Text = "Open ";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.fileToolStripMenuItem.Text = "ppm";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            this.OpenFile.Filter = "PPM Files|*.ppm";
            // 
            // imgProgress
            // 
            this.imgProgress.AutoSize = true;
            this.imgProgress.Location = new System.Drawing.Point(91, 398);
            this.imgProgress.Name = "imgProgress";
            this.imgProgress.Size = new System.Drawing.Size(0, 13);
            this.imgProgress.TabIndex = 9;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(541, 370);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(213, 20);
            this.progressBar2.TabIndex = 10;
            // 
            // EncodedIMG
            // 
            this.EncodedIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncodedIMG.Location = new System.Drawing.Point(541, 66);
            this.EncodedIMG.Name = "EncodedIMG";
            this.EncodedIMG.Size = new System.Drawing.Size(213, 296);
            this.EncodedIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EncodedIMG.TabIndex = 11;
            this.EncodedIMG.TabStop = false;
            // 
            // saveFile
            // 
            this.saveFile.Filter = "PPM Files|*.ppm";
            // 
            // Errormsg
            // 
            this.Errormsg.AutoSize = true;
            this.Errormsg.Location = new System.Drawing.Point(335, 398);
            this.Errormsg.Name = "Errormsg";
            this.Errormsg.Size = new System.Drawing.Size(0, 13);
            this.Errormsg.TabIndex = 12;
            // 
            // EncodedStatus
            // 
            this.encodedStatus.AutoSize = true;
            this.encodedStatus.Location = new System.Drawing.Point(541, 393);
            this.encodedStatus.Name = "EncodedStatus";
            this.encodedStatus.Size = new System.Drawing.Size(0, 13);
            this.encodedStatus.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Enter message here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.encodedStatus);
            this.Controls.Add(this.Errormsg);
            this.Controls.Add(this.EncodedIMG);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.imgProgress);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.EncodeBTN);
            this.Controls.Add(this.txtHiddenMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserIMG);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UserIMG)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncodedIMG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox UserIMG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHiddenMessage;
        private System.Windows.Forms.Button EncodeBTN;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.Label imgProgress;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.PictureBox EncodedIMG;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Label Errormsg;
        private System.Windows.Forms.Label encodedStatus;
        private System.Windows.Forms.Label label2;
    }
}

