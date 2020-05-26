namespace Strategy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mapPreview = new System.Windows.Forms.PictureBox();
            this.PlayTimer = new System.Windows.Forms.Timer(this.components);
            this.tBoard1 = new Strategy.TBoard();
            this.turnButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.turnButton);
            this.panel1.Controls.Add(this.mapPreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(900, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 743);
            this.panel1.TabIndex = 0;
            // 
            // mapPreview
            // 
            this.mapPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPreview.BackColor = System.Drawing.Color.Beige;
            this.mapPreview.Location = new System.Drawing.Point(15, 12);
            this.mapPreview.Name = "mapPreview";
            this.mapPreview.Size = new System.Drawing.Size(287, 155);
            this.mapPreview.TabIndex = 0;
            this.mapPreview.TabStop = false;
            this.mapPreview.Click += new System.EventHandler(this.mapPreview_Click);
            this.mapPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPreview_Paint);
            this.mapPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPreview_MouseDown);
            this.mapPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPreview_MouseMove);
            // 
            // PlayTimer
            // 
            this.PlayTimer.Tick += new System.EventHandler(this.PlayTimer_Tick);
            // 
            // tBoard1
            // 
            this.tBoard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoard1.Location = new System.Drawing.Point(0, 0);
            this.tBoard1.Margin = new System.Windows.Forms.Padding(2);
            this.tBoard1.Name = "tBoard1";
            this.tBoard1.ScrollPos = ((System.Drawing.PointF)(resources.GetObject("tBoard1.ScrollPos")));
            this.tBoard1.Size = new System.Drawing.Size(900, 743);
            this.tBoard1.TabIndex = 1;
            this.tBoard1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tBoard1_MouseDown);
            // 
            // turnButton
            // 
            this.turnButton.Location = new System.Drawing.Point(95, 549);
            this.turnButton.Name = "turnButton";
            this.turnButton.Size = new System.Drawing.Size(138, 37);
            this.turnButton.TabIndex = 1;
            this.turnButton.Text = "End Turn";
            this.turnButton.UseVisualStyleBackColor = true;
            this.turnButton.Click += new System.EventHandler(this.turnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 743);
            this.Controls.Add(this.tBoard1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private TBoard tBoard1;
        private System.Windows.Forms.Timer PlayTimer;
        private System.Windows.Forms.PictureBox mapPreview;
        private System.Windows.Forms.Button turnButton;
    }
}

