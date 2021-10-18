
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
            this.ListBoxSongs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelCurrentSong = new System.Windows.Forms.Label();
            this.ButtonLoadSong = new System.Windows.Forms.Button();
            this.ButtonWriteSongs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.circularButton1 = new JMCAudioPlayer.CircularButton();
            this.ButtonNext = new JMCAudioPlayer.CircularButton();
            this.ButtonPlay = new JMCAudioPlayer.CircularButton();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxSongs
            // 
            this.ListBoxSongs.FormattingEnabled = true;
            this.ListBoxSongs.Location = new System.Drawing.Point(12, 38);
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
            this.LabelCurrentSong.Location = new System.Drawing.Point(95, 356);
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
            this.ButtonLoadSong.Click += new System.EventHandler(this.ButtonLoadSong_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
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
            // WindowsMediaPlayer
            // 
            this.WindowsMediaPlayer.Enabled = true;
            this.WindowsMediaPlayer.Location = new System.Drawing.Point(172, 355);
            this.WindowsMediaPlayer.Name = "WindowsMediaPlayer";
            this.WindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMediaPlayer.OcxState")));
            this.WindowsMediaPlayer.Size = new System.Drawing.Size(218, 34);
            this.WindowsMediaPlayer.TabIndex = 0;
            this.WindowsMediaPlayer.Visible = false;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            this.OpenFileDialog.Multiselect = true;
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.circularButton1.FlatAppearance.BorderSize = 0;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Font = new System.Drawing.Font("Webdings", 25F);
            this.circularButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.circularButton1.Location = new System.Drawing.Point(11, 383);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(45, 45);
            this.circularButton1.TabIndex = 9;
            this.circularButton1.Text = "7";
            this.circularButton1.UseVisualStyleBackColor = false;
            // 
            // ButtonNext
            // 
            this.ButtonNext.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ButtonNext.FlatAppearance.BorderSize = 0;
            this.ButtonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonNext.Font = new System.Drawing.Font("Webdings", 25F);
            this.ButtonNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonNext.Location = new System.Drawing.Point(128, 383);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(45, 45);
            this.ButtonNext.TabIndex = 9;
            this.ButtonNext.Text = "8";
            this.ButtonNext.UseVisualStyleBackColor = false;
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ButtonPlay.FlatAppearance.BorderSize = 0;
            this.ButtonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonPlay.Font = new System.Drawing.Font("Webdings", 30F);
            this.ButtonPlay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonPlay.Location = new System.Drawing.Point(67, 380);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(50, 50);
            this.ButtonPlay.TabIndex = 9;
            this.ButtonPlay.Text = "4";
            this.ButtonPlay.UseVisualStyleBackColor = false;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // FormAudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 463);
            this.Controls.Add(this.circularButton1);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonPlay);
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
            this.Name = "FormAudioPlayer";
            this.Text = "FormAudioPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAudioPlayer_FormClosing);
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
        private CircularButton ButtonPlay;
        private CircularButton ButtonNext;
        private CircularButton circularButton1;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}