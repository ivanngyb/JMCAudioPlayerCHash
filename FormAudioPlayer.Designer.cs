
namespace JMCAudioPlayer
{
    partial class FormAudioPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAudioPlayer));
            this.WindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.ListBoxSongs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelCurrentSong = new System.Windows.Forms.Label();
            this.ButtonLoadSong = new System.Windows.Forms.Button();
            this.ButtonWriteSongs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // WindowsMediaPlayer
            // 
            this.WindowsMediaPlayer.Enabled = true;
            this.WindowsMediaPlayer.Location = new System.Drawing.Point(11, 384);
            this.WindowsMediaPlayer.Name = "WindowsMediaPlayer";
            this.WindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMediaPlayer.OcxState")));
            this.WindowsMediaPlayer.Size = new System.Drawing.Size(218, 34);
            this.WindowsMediaPlayer.TabIndex = 0;
            // 
            // ListBoxSongs
            // 
            this.ListBoxSongs.FormattingEnabled = true;
            this.ListBoxSongs.Location = new System.Drawing.Point(12, 41);
            this.ListBoxSongs.Name = "ListBoxSongs";
            this.ListBoxSongs.Size = new System.Drawing.Size(384, 303);
            this.ListBoxSongs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(9, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Now Playing:";
            // 
            // LabelCurrentSong
            // 
            this.LabelCurrentSong.AutoSize = true;
            this.LabelCurrentSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LabelCurrentSong.Location = new System.Drawing.Point(104, 356);
            this.LabelCurrentSong.Name = "LabelCurrentSong";
            this.LabelCurrentSong.Size = new System.Drawing.Size(69, 17);
            this.LabelCurrentSong.TabIndex = 2;
            this.LabelCurrentSong.Text = "Nothing...";
            // 
            // ButtonLoadSong
            // 
            this.ButtonLoadSong.Location = new System.Drawing.Point(315, 360);
            this.ButtonLoadSong.Name = "ButtonLoadSong";
            this.ButtonLoadSong.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoadSong.TabIndex = 3;
            this.ButtonLoadSong.Text = "Load Songs";
            this.ButtonLoadSong.UseVisualStyleBackColor = true;
            // 
            // ButtonWriteSongs
            // 
            this.ButtonWriteSongs.Location = new System.Drawing.Point(267, 395);
            this.ButtonWriteSongs.Name = "ButtonWriteSongs";
            this.ButtonWriteSongs.Size = new System.Drawing.Size(123, 23);
            this.ButtonWriteSongs.TabIndex = 4;
            this.ButtonWriteSongs.Text = "Write Song List to CSV";
            this.ButtonWriteSongs.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Song List";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(408, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(296, 12);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.TextBoxSearch.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search Title:";
            // 
            // FormAudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxSearch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonWriteSongs);
            this.Controls.Add(this.ButtonLoadSong);
            this.Controls.Add(this.LabelCurrentSong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBoxSongs);
            this.Controls.Add(this.WindowsMediaPlayer);
            this.Enabled = false;
            this.Name = "FormAudioPlayer";
            this.Text = "FormAudioPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer WindowsMediaPlayer;
        private System.Windows.Forms.ListBox ListBoxSongs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelCurrentSong;
        private System.Windows.Forms.Button ButtonLoadSong;
        private System.Windows.Forms.Button ButtonWriteSongs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Label label3;
    }
}