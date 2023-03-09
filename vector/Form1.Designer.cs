namespace vector
{
    partial class ransom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ransom));
            titleLabel = new Label();
            shieldPic = new PictureBox();
            pkLabel = new Label();
            timeLabel = new Label();
            tlLabel = new Label();
            timeLeftLabel = new Label();
            panel1 = new Panel();
            bitcoinPic = new PictureBox();
            mainLabel = new Label();
            shronkPic = new PictureBox();
            ransomzLabel = new Label();
            payButton = new Button();
            idLabel = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)shieldPic).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bitcoinPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shronkPic).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.White;
            titleLabel.Name = "titleLabel";
            // 
            // shieldPic
            // 
            resources.ApplyResources(shieldPic, "shieldPic");
            shieldPic.Name = "shieldPic";
            shieldPic.TabStop = false;
            // 
            // pkLabel
            // 
            resources.ApplyResources(pkLabel, "pkLabel");
            pkLabel.ForeColor = Color.White;
            pkLabel.Name = "pkLabel";
            // 
            // timeLabel
            // 
            resources.ApplyResources(timeLabel, "timeLabel");
            timeLabel.ForeColor = Color.White;
            timeLabel.Name = "timeLabel";
            // 
            // tlLabel
            // 
            resources.ApplyResources(tlLabel, "tlLabel");
            tlLabel.BackColor = Color.Transparent;
            tlLabel.ForeColor = Color.White;
            tlLabel.Name = "tlLabel";
            // 
            // timeLeftLabel
            // 
            resources.ApplyResources(timeLeftLabel, "timeLeftLabel");
            timeLeftLabel.BackColor = Color.Transparent;
            timeLeftLabel.ForeColor = Color.Yellow;
            timeLeftLabel.Name = "timeLeftLabel";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.White;
            panel1.Controls.Add(bitcoinPic);
            panel1.Controls.Add(mainLabel);
            panel1.Name = "panel1";
            // 
            // bitcoinPic
            // 
            resources.ApplyResources(bitcoinPic, "bitcoinPic");
            bitcoinPic.Image = Properties.Resources.bitcoin;
            bitcoinPic.Name = "bitcoinPic";
            bitcoinPic.TabStop = false;
            // 
            // mainLabel
            // 
            resources.ApplyResources(mainLabel, "mainLabel");
            mainLabel.Name = "mainLabel";
            // 
            // shronkPic
            // 
            resources.ApplyResources(shronkPic, "shronkPic");
            shronkPic.Name = "shronkPic";
            shronkPic.TabStop = false;
            // 
            // ransomzLabel
            // 
            resources.ApplyResources(ransomzLabel, "ransomzLabel");
            ransomzLabel.BackColor = Color.Transparent;
            ransomzLabel.ForeColor = Color.White;
            ransomzLabel.Name = "ransomzLabel";
            // 
            // payButton
            // 
            resources.ApplyResources(payButton, "payButton");
            payButton.BackColor = Color.Yellow;
            payButton.Name = "payButton";
            payButton.UseVisualStyleBackColor = false;
            payButton.Click += payButton_Click;
            // 
            // idLabel
            // 
            resources.ApplyResources(idLabel, "idLabel");
            idLabel.Name = "idLabel";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // ransom
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            Controls.Add(idLabel);
            Controls.Add(payButton);
            Controls.Add(ransomzLabel);
            Controls.Add(shronkPic);
            Controls.Add(panel1);
            Controls.Add(timeLeftLabel);
            Controls.Add(tlLabel);
            Controls.Add(timeLabel);
            Controls.Add(pkLabel);
            Controls.Add(shieldPic);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ransom";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)shieldPic).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bitcoinPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)shronkPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private PictureBox shieldPic;
        private Label pkLabel;
        private Label timeLabel;
        private Label tlLabel;
        private Label timeLeftLabel;
        private Panel panel1;
        private PictureBox shronkPic;
        private Label mainLabel;
        private PictureBox bitcoinPic;
        private TextBox idLabel;
        private Label ransomzLabel;
        private Button payButton;
        private System.Windows.Forms.Timer timer1;
    }
}