
namespace JMCAudioPlayer
{
    partial class FormReconnect
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
            this.label1 = new System.Windows.Forms.Label();
            this.LabelCountdown = new System.Windows.Forms.Label();
            this.ButtonQuit = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection Lost...Attempting to reconnect in";
            // 
            // LabelCountdown
            // 
            this.LabelCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCountdown.Location = new System.Drawing.Point(-2, 65);
            this.LabelCountdown.Name = "LabelCountdown";
            this.LabelCountdown.Size = new System.Drawing.Size(647, 45);
            this.LabelCountdown.TabIndex = 1;
            this.LabelCountdown.Text = "5";
            this.LabelCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonQuit
            // 
            this.ButtonQuit.Location = new System.Drawing.Point(279, 113);
            this.ButtonQuit.Name = "ButtonQuit";
            this.ButtonQuit.Size = new System.Drawing.Size(84, 32);
            this.ButtonQuit.TabIndex = 2;
            this.ButtonQuit.Text = "Quit";
            this.ButtonQuit.UseVisualStyleBackColor = true;
            this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormReconnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 165);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonQuit);
            this.Controls.Add(this.LabelCountdown);
            this.Controls.Add(this.label1);
            this.Name = "FormReconnect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelCountdown;
        private System.Windows.Forms.Button ButtonQuit;
        private System.Windows.Forms.Timer Timer1;
    }
}