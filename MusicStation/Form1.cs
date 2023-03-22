using AxWMPLib;
using MusicStation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


// ICONS FOUND @  https://icons8.com/ 


namespace MusicStation
{
    public partial class GrooveStation : Form
    {
        public GrooveStation()
        {
            InitializeComponent();
            Player.uiMode = "invisible";
            Player.Visible = false;
            Player.settings.autoStart = false;
            L_PlayStateLabel.Text = "";
        }

        //IS THIS BINDINGSOURCE NEEDED??? (GUT SAYS NO)
        BindingSource tracksBindingSource = new BindingSource();

        AxWindowsMediaPlayer Station = new AxWindowsMediaPlayer();
        List<Playlist> playlist = new List<Playlist>();
        private string selectedSong;
        private int volume = 100;
        private bool isDragging;
        private Point lastLocation;



        private void btn_Load_Click(object sender, EventArgs e)
        {
            //Using keyword ensures disposal of data when complete.
            using (OpenFileDialog open = new OpenFileDialog())
            {
                string[] filePath;
                string[] fileContent;
                open.InitialDirectory = @"C:\";
                open.Title = "Load Grooves...";
                open.Multiselect = true;
                open.ShowDialog();
                filePath = open.FileNames;
                fileContent = open.FileNames;

                //Loop through the opened files and use the Playlist class to unpack the data.
                for (int i = 0; i < fileContent.Length; i++)
                {
                    Playlist trackToAdd = new Playlist();
                    trackToAdd.PlaylistID = i;
                    trackToAdd.TrackTitle = fileContent[i].Substring(fileContent[i].LastIndexOf("\\") + 1);
                    trackToAdd.TrackAddress = fileContent[i];
                    trackToAdd.Runtime = Player.newMedia(fileContent[i]).durationString;
                    playlist.Add(trackToAdd);
                }

                //Update the TRACKS UI listbox.
                lb_Songs.DataSource = playlist;
                lb_Songs.DisplayMember = "TrackTitle";
                lb_Songs.ValueMember = "TrackAddress";

                //Update the RUNTIME UI listbox.
                lb_Runtime.DataSource = playlist;
                lb_Runtime.DisplayMember = "Runtime";
                lb_Runtime.ValueMember = "Runtime";

                //Ensure that the first item on the playlist is assigned as globally 'selected' so that user can press 'Play' button immediately.
                selectedSong = lb_Songs.SelectedValue.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_Songs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update the global selection.
            selectedSong = lb_Songs.SelectedValue.ToString();

            //TO DO - ERROR HANDLNIG (When user hits prev button on track 1)
        }


        private void btn_Play_Click(object sender, EventArgs e)
        {
            if ((Player.playState == WMPPlayState.wmppsUndefined || Player.playState == WMPPlayState.wmppsReady) || (Player.playState == WMPPlayState.wmppsPaused && selectedSong != Player.URL))
            {
                Player.URL = selectedSong;
                PlayTrack();
            }
            else if (Player.playState == WMPPlayState.wmppsPlaying)
            {
                PauseTrack();
            } 
            else if(Player.playState == WMPPlayState.wmppsPaused)
            {
                PlayTrack();
            }
        }

        void PlayTrack()
        {
            Player.Ctlcontrols.play();
            btn_Play.Text = "Pause";
            L_PlayStateLabel.Text = "Media is playing";
        }

        void PauseTrack()
        {
            Player.Ctlcontrols.pause();
            btn_Play.Text = "Play";
            L_PlayStateLabel.Text = "Quiet time..";
        }

        private void lb_Songs_DoubleClick(object sender, EventArgs e)
        {
            Player.URL = selectedSong;
            PlayTrack();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            lb_Songs.SelectedIndex = lb_Songs.SelectedIndex + 1;
            Player.URL = lb_Songs.SelectedValue.ToString();
            Player.Ctlcontrols.next();
            PlayTrack();
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            lb_Songs.SelectedIndex = lb_Songs.SelectedIndex - 1;
            Player.URL = lb_Songs.SelectedValue.ToString();
            Player.Ctlcontrols.previous();
            PlayTrack();
        }

        //Error handling in case app encounters error such as invalid URL for track.
        private void Player_MediaError(object sender, _WMPOCXEvents_MediaErrorEvent e)
        {
            try
            // If the Player encounters a corrupt or missing file, 
            // show the hexadecimal error code and URL.
            {
                IWMPMedia2 errSource = e.pMediaObject as IWMPMedia2;
                IWMPErrorItem errorItem = errSource.Error;
                MessageBox.Show("Error " + errorItem.errorCode.ToString("X")
                                + " in " + errSource.sourceURL);
            }
            catch (InvalidCastException)
            // In case pMediaObject is not an IWMPMedia item.
            {
                MessageBox.Show("Error.");
            }

        }

        private void tb_Volume_ValueChanged(object sender, EventArgs e)
        {
            //Player.settings.volume.Equals(tb_Volume.Value);
            volume = tb_Volume.Value;
            Player.settings.volume = volume;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Player.settings.mute = !Player.settings.mute;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player.playState == WMPPlayState.wmppsPlaying)
            {
                pb_SongProgress.Maximum = (int)Player.Ctlcontrols.currentItem.duration;
                pb_SongProgress.Value = (int) Player.Ctlcontrols.currentPosition;
            }
        }

        private void pb_SongProgress_MouseDown(object sender, MouseEventArgs e)
        {
            Player.Ctlcontrols.currentPosition = Player.currentMedia.duration * e.X / pb_SongProgress.Width;
            l_trackPositionTimer.Text = Player.Ctlcontrols.currentPosition.ToString();
        }
        


        // IMPLEMENT ABILITY TO DRAG APP AROUND SCREEN.
        private void btn_Mover_MouseDown(object sender, MouseEventArgs e)
        {
            //Location = new Point(e.Location.X, e.Location.Y);
            isDragging = true;
            lastLocation = e.Location;
        }
        private void btn_Mover_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void btn_Mover_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}