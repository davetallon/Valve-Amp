namespace MusicStation
{
    partial class GrooveStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrooveStation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_trackPositionTimer = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.L_PlayStateLabel = new System.Windows.Forms.Label();
            this.tb_Volume = new System.Windows.Forms.TrackBar();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Mover = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Ttitle = new System.Windows.Forms.Label();
            this.lb_Songs = new System.Windows.Forms.ListBox();
            this.pb_SongProgress = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.lb_Runtime = new System.Windows.Forms.ListBox();
            this.lbl_Tracks = new System.Windows.Forms.Label();
            this.lbl_Runtime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Volume)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.l_trackPositionTimer);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.L_PlayStateLabel);
            this.panel1.Controls.Add(this.tb_Volume);
            this.panel1.Controls.Add(this.btn_Previous);
            this.panel1.Controls.Add(this.btn_Next);
            this.panel1.Controls.Add(this.btn_Load);
            this.panel1.Controls.Add(this.btn_Play);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 604);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1581, 108);
            this.panel1.TabIndex = 1;
            // 
            // l_trackPositionTimer
            // 
            this.l_trackPositionTimer.AutoSize = true;
            this.l_trackPositionTimer.Location = new System.Drawing.Point(500, 44);
            this.l_trackPositionTimer.Name = "l_trackPositionTimer";
            this.l_trackPositionTimer.Size = new System.Drawing.Size(35, 13);
            this.l_trackPositionTimer.TabIndex = 6;
            this.l_trackPositionTimer.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MusicStation.Properties.Resources.icons8_mute_unmute_48;
            this.pictureBox2.Location = new System.Drawing.Point(27, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // L_PlayStateLabel
            // 
            this.L_PlayStateLabel.AutoSize = true;
            this.L_PlayStateLabel.Location = new System.Drawing.Point(1004, 44);
            this.L_PlayStateLabel.Name = "L_PlayStateLabel";
            this.L_PlayStateLabel.Size = new System.Drawing.Size(35, 13);
            this.L_PlayStateLabel.TabIndex = 4;
            this.L_PlayStateLabel.Text = "label1";
            // 
            // tb_Volume
            // 
            this.tb_Volume.Location = new System.Drawing.Point(82, 44);
            this.tb_Volume.Maximum = 100;
            this.tb_Volume.Name = "tb_Volume";
            this.tb_Volume.Size = new System.Drawing.Size(332, 45);
            this.tb_Volume.TabIndex = 2;
            this.tb_Volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_Volume.Value = 100;
            this.tb_Volume.ValueChanged += new System.EventHandler(this.tb_Volume_ValueChanged);
            // 
            // btn_Previous
            // 
            this.btn_Previous.Location = new System.Drawing.Point(632, 33);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(75, 37);
            this.btn_Previous.TabIndex = 2;
            this.btn_Previous.Text = "Previous";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(844, 33);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 37);
            this.btn_Next.TabIndex = 1;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(1414, 14);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(126, 74);
            this.btn_Load.TabIndex = 3;
            this.btn_Load.Text = "Load Grooves";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(731, 14);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(93, 74);
            this.btn_Play.TabIndex = 0;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btn_Mover);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbl_Ttitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1581, 102);
            this.panel2.TabIndex = 5;
            // 
            // btn_Mover
            // 
            this.btn_Mover.BackColor = System.Drawing.SystemColors.InfoText;
            this.btn_Mover.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Mover.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btn_Mover.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_Mover.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Mover.Location = new System.Drawing.Point(235, 3);
            this.btn_Mover.Name = "btn_Mover";
            this.btn_Mover.Size = new System.Drawing.Size(1222, 21);
            this.btn_Mover.TabIndex = 12;
            this.btn_Mover.Text = "Position";
            this.btn_Mover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Mover.UseVisualStyleBackColor = false;
            this.btn_Mover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Mover_MouseDown);
            this.btn_Mover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_Mover_MouseMove);
            this.btn_Mover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Mover_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MusicStation.Properties.Resources.icons8_close_window_100;
            this.pictureBox1.InitialImage = global::MusicStation.Properties.Resources.icons8_close_window_100;
            this.pictureBox1.Location = new System.Drawing.Point(1481, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbl_Ttitle
            // 
            this.lbl_Ttitle.AutoSize = true;
            this.lbl_Ttitle.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ttitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Ttitle.Location = new System.Drawing.Point(30, 9);
            this.lbl_Ttitle.Name = "lbl_Ttitle";
            this.lbl_Ttitle.Size = new System.Drawing.Size(298, 81);
            this.lbl_Ttitle.TabIndex = 0;
            this.lbl_Ttitle.Text = "GROOVE BOX";
            // 
            // lb_Songs
            // 
            this.lb_Songs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_Songs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Songs.FormattingEnabled = true;
            this.lb_Songs.ItemHeight = 20;
            this.lb_Songs.Location = new System.Drawing.Point(976, 164);
            this.lb_Songs.Name = "lb_Songs";
            this.lb_Songs.Size = new System.Drawing.Size(331, 380);
            this.lb_Songs.TabIndex = 6;
            this.lb_Songs.SelectedIndexChanged += new System.EventHandler(this.lb_Songs_SelectedIndexChanged);
            this.lb_Songs.DoubleClick += new System.EventHandler(this.lb_Songs_DoubleClick);
            // 
            // pb_SongProgress
            // 
            this.pb_SongProgress.Location = new System.Drawing.Point(12, 564);
            this.pb_SongProgress.Name = "pb_SongProgress";
            this.pb_SongProgress.Size = new System.Drawing.Size(1557, 23);
            this.pb_SongProgress.TabIndex = 7;
            this.pb_SongProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_SongProgress_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Player
            // 
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(44, 474);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(442, 70);
            this.Player.TabIndex = 0;
            this.Player.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.Player_MediaError);
            // 
            // lb_Runtime
            // 
            this.lb_Runtime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_Runtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_Runtime.FormattingEnabled = true;
            this.lb_Runtime.ItemHeight = 20;
            this.lb_Runtime.Location = new System.Drawing.Point(1304, 164);
            this.lb_Runtime.Name = "lb_Runtime";
            this.lb_Runtime.Size = new System.Drawing.Size(100, 380);
            this.lb_Runtime.TabIndex = 8;
            // 
            // lbl_Tracks
            // 
            this.lbl_Tracks.AutoSize = true;
            this.lbl_Tracks.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Tracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_Tracks.Location = new System.Drawing.Point(3, 8);
            this.lbl_Tracks.Name = "lbl_Tracks";
            this.lbl_Tracks.Size = new System.Drawing.Size(66, 24);
            this.lbl_Tracks.TabIndex = 9;
            this.lbl_Tracks.Text = "Tracks";
            // 
            // lbl_Runtime
            // 
            this.lbl_Runtime.AutoSize = true;
            this.lbl_Runtime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Runtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_Runtime.Location = new System.Drawing.Point(333, 8);
            this.lbl_Runtime.Name = "lbl_Runtime";
            this.lbl_Runtime.Size = new System.Drawing.Size(80, 24);
            this.lbl_Runtime.TabIndex = 10;
            this.lbl_Runtime.Text = "Runtime";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.lbl_Tracks);
            this.panel3.Controls.Add(this.lbl_Runtime);
            this.panel3.Location = new System.Drawing.Point(976, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 38);
            this.panel3.TabIndex = 11;
            // 
            // GrooveStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1581, 712);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lb_Runtime);
            this.Controls.Add(this.pb_SongProgress);
            this.Controls.Add(this.lb_Songs);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GrooveStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GrooveStation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Volume)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer Player;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Ttitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lb_Songs;
        private System.Windows.Forms.ProgressBar pb_SongProgress;
        private System.Windows.Forms.Label L_PlayStateLabel;
        private System.Windows.Forms.TrackBar tb_Volume;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lb_Runtime;
        private System.Windows.Forms.Label lbl_Tracks;
        private System.Windows.Forms.Label lbl_Runtime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label l_trackPositionTimer;
        private System.Windows.Forms.Button btn_Mover;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

