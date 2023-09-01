namespace Rheometer_Torque.View
{
    partial class FrmWelcome
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
            this.loadingCircle = new Utils.Utils.LoadingCircle();
            this.SuspendLayout();
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 20;
            this.loadingCircle.Location = new System.Drawing.Point(210, 131);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 40;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(111, 104);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = Utils.Utils.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 0;
            this.loadingCircle.Text = "loadingCircle1";
            // 
            // FrmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::Rheometer_Torque.Properties.Resources.Welcome;
            this.ClientSize = new System.Drawing.Size(564, 357);
            this.Controls.Add(this.loadingCircle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::Rheometer_Torque.Properties.Resources.App;
            this.Name = "FrmWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWelcome";
            this.Load += new System.EventHandler(this.FrmWelcome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.Utils.LoadingCircle loadingCircle;
    }
}