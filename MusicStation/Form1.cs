using AxWMPLib;
using MusicStation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Net.Mime.MediaTypeNames;


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

            //SET INITIAL TRANSPERENCIES FOR IMAGES.
            pb_Volume.BackColor = Color.Transparent;
            pb_VolumeHover.BackColor = Color.Transparent;
            pb_CloseApp.BackColor = Color.Transparent;
            pb_Headphones_Playing.BackColor = Color.Transparent;
            pb_Headphones_Mute.BackColor = Color.Transparent;
            pb_PlayPause.BackColor = Color.Transparent;
            pb_Pause.BackColor = Color.Transparent;
            pb_NextSong.BackColor = Color.Transparent;
            pb_PrevSong.BackColor = Color.Transparent;
            pb_LoadGrooves.BackColor = Color.Transparent;
            pb_valvesPlaying.BackColor = Color.Transparent;
            pb_credits.BackColor = Color.Transparent;
            pb_creditsPicture.BackColor = Color.Transparent;

            //SET INITIAL HOVER-IMAGES TO HIDE
            pb_Pause.Visible = false;
            pb_NextSong.Visible = false;
            pb_PrevSong.Visible = false;
            pb_LoadGrooves.Visible = false;
            pb_Headphones_Playing.Visible = false;
            pb_Headphones_Mute.Visible = false;
            pb_VolumeHover.Visible = false;
            pb_valvesPlaying.Visible = false;
            pb_credits.Visible = false;
            pb_creditsPicture.Visible = false;
        }

        //IS THIS BINDINGSOURCE NEEDED??? (GUT SAYS NO)
        BindingSource tracksBindingSource = new BindingSource();

        AxWindowsMediaPlayer Station = new AxWindowsMediaPlayer();
        List<Playlist> playlist = new List<Playlist>();
        private string selectedSong;
        private int volume = 0;
        private int volumeHandler = 0;
        private bool isDragging;
        private Point lastLocation;


        private void pb_LoadGrooves_Click(object sender, EventArgs e)
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
                if (lb_Songs.SelectedValue != null)
                {
                    selectedSong = lb_Songs.SelectedValue.ToString();
                }
            }
        }

        private void lb_Songs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update the global selection.
            selectedSong = lb_Songs.SelectedValue.ToString();

            //TO DO - ERROR HANDLNIG (When user hits prev button on track 1)
        }

        void PlayTrack()
        {
            if (selectedSong != null)
            {
                Player.Ctlcontrols.play();
                pb_Pause.Visible = true;
                pb_PlayPause.Visible = false;
                pb_Headphones_Playing.Visible = true;
                pb_valvesPlaying.Visible = true;
                pb_ValvesOff.Visible = false;
                //RunValves();
            }
            else
            {
                return;
            }
        }

/*        public Bitmap RunValves()
        {
            // Create a Bitmap object from an image file.
            Bitmap bm_runningValves = new Bitmap(MusicStation.Properties.Resources.ART_PLAYING_Valves);

            // Make the default transparent color transparent for myBitmap.
            //bm_runningValves.MakeTransparent();

            Graphics Gvalves = Graphics.FromImage(bm_runningValves);

            // Draw the transparent bitmap to the screen.
            Gvalves.DrawImage(bm_runningValves, bm_runningValves.Width, 0,
                bm_runningValves.Width, bm_runningValves.Height);

            return bm_runningValves;
        }*/
            
        void PauseTrack()
        {
            Player.Ctlcontrols.pause();
            pb_Pause.Visible = false;
            pb_PlayPause.Visible = true;
            pb_Headphones_Playing.Visible = false;
            pb_valvesPlaying.Visible = false;
            pb_ValvesOff.Visible = true;
        }

        private void lb_Songs_DoubleClick(object sender, EventArgs e)
        {
            Player.URL = selectedSong;
            PlayTrack();
        }

        private void pb_NextSong_Click(object sender, EventArgs e)
        {
            //ERROR-HANDLE MAXIMUM SONG BOUNDS
            if (lb_Songs.SelectedIndex == -1 || lb_Songs.SelectedIndex >= playlist.Count - 1) { return; }
            lb_Songs.SelectedIndex = lb_Songs.SelectedIndex + 1;
            Player.URL = lb_Songs.SelectedValue.ToString();
            Player.Ctlcontrols.next();
            PlayTrack();
        }

        private void pb_PrevSong_Click(object sender, EventArgs e)
        {
            //ERROR-HANDLE MINIMUM SONG BOUNDS
            if (lb_Songs.SelectedIndex == -1 || lb_Songs.SelectedIndex == 0) { return; }
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

        private void pb_Headphones_Playing_Click(object sender, EventArgs e)
        {
            Player.settings.mute = !Player.settings.mute;
            //DoubleBuffered = true;
            pb_Headphones_Mute.Visible = !pb_Headphones_Mute.Visible;
            pb_Headphones_Playing.Visible = !pb_Headphones_Playing.Visible;
        }
        private void pb_Headphones_Mute_Click(object sender, EventArgs e)
        {
            Player.settings.mute = !Player.settings.mute;
            //DoubleBuffered = true;
            pb_Headphones_Mute.Visible = !pb_Headphones_Mute.Visible;
            pb_Headphones_Playing.Visible = !pb_Headphones_Playing.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player.playState == WMPPlayState.wmppsPlaying)
            {
                pb_SongProgress.Maximum = (int)Player.Ctlcontrols.currentItem.duration;
                pb_SongProgress.Value = (int)Player.Ctlcontrols.currentPosition;
            }
        }

        private void pb_SongProgress_MouseDown(object sender, MouseEventArgs e)
        {
            Player.Ctlcontrols.currentPosition = Player.currentMedia.duration * e.X / pb_SongProgress.Width;
        }


        private void pb_CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrooveStation_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastLocation = e.Location;
        }

        private void GrooveStation_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void GrooveStation_MouseMove(object sender, MouseEventArgs e)
        {
            //MOVING THE APP LOCATION
            if (isDragging)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }


            //CLOSE APP HOVER
            if (pb_CloseApp.Bounds.Contains(e.Location) && !pb_CloseApp.Visible)
            {
                pb_CloseApp.Show();
            }
            else
            {
                //Double buffered helps prevent flicker.
                DoubleBuffered = true;
                pb_CloseApp.Hide();
            }

            //PLAY HOVER
            if ((pb_PlayPause.Bounds.Contains(e.Location) && !pb_PlayPause.Visible) && (Player.playState == WMPPlayState.wmppsUndefined || Player.playState == WMPPlayState.wmppsReady || Player.playState == WMPPlayState.wmppsPaused))
            {
                pb_PlayPause.Show();
            }
            else
            {
                DoubleBuffered = true;
                pb_PlayPause.Hide();
            }

            //NEXT SONG HOVER
            if (pb_NextSong.Bounds.Contains(e.Location) && !pb_NextSong.Visible)
            {
                pb_NextSong.Show();
            }
            else
            {
                pb_NextSong.Hide();
            }

            //PREV SONG HOVER
            if (pb_PrevSong.Bounds.Contains(e.Location) && !pb_PrevSong.Visible)
            {
                pb_PrevSong.Show();
            }
            else
            {
                pb_PrevSong.Hide();
            }

            //LOAD GROOVES HOVER
            if (pb_LoadGrooves.Bounds.Contains(e.Location) && !pb_LoadGrooves.Visible)
            {
                pb_LoadGrooves.Show();
            }
            else
            {
                pb_LoadGrooves.Hide();
            }

            //CREDITS HOVER
            if (pb_credits.Bounds.Contains(e.Location) && !pb_credits.Visible)
            {
                pb_credits.Show();
            }
            else
            {
                pb_credits.Hide();
            }
        }

        private void pb_PlayPause_Click(object sender, EventArgs e)
        {
            if ((Player.playState == WMPPlayState.wmppsUndefined || Player.playState == WMPPlayState.wmppsReady) || (Player.playState == WMPPlayState.wmppsPaused && selectedSong != Player.URL))
            {
                Player.URL = selectedSong;
                PlayTrack();
            }
            else if (Player.playState == WMPPlayState.wmppsPaused)
            {
                PlayTrack();
            }
        }

        private void pb_Pause_Click(object sender, EventArgs e)
        {
            if (Player.playState == WMPPlayState.wmppsPlaying)
            {
                PauseTrack();
            }
        }

        private void pb_CloseApp_MouseLeave(object sender, EventArgs e)
        {
            pb_CloseApp.Hide();
        }





        public Bitmap bm_volumeImageHover = MusicStation.Properties.Resources.ART_HOVER_Volume;
        public Bitmap bm_volumeImageStatic = MusicStation.Properties.Resources.ART_BASE_Volume_NOShadow;
        float Angle = 9f;
        PointF offsetHover = new PointF(109, 106);
        PointF offsetStatic = new PointF(104.8f, 103.5f);

        private void pb_Volume_Click(object sender, EventArgs e)
        {
            pb_VolumeHover.Visible = true;
            pb_Volume.Visible = false;
            pb_VolumeHover.Image = RotateImage(bm_volumeImageHover, offsetHover, Angle);
            pb_Volume.Image = RotateImage(bm_volumeImageStatic, offsetStatic, Angle);
        }

        public Bitmap RotateImage(System.Drawing.Image image, PointF offset, float angle)
        {
            //CREATE NEW EMPTY BITMAP TO HOLD ROTATED IMAGE.
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //MAKE A GRAPHICS OBJECT FROM THE EMPTY BITMAP
            Graphics g = Graphics.FromImage(rotatedBmp);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //PUT THE ROTATION POINT IN THE CENTER OF IMAGE
            g.TranslateTransform(offset.X, offset.Y);

            //ROTATE THE IMAGE
            g.RotateTransform(angle);

            //MOVE THE IMAGE BACK 
            g.TranslateTransform(-offset.X, -offset.Y);

            //DRAW PASSED IN IMAGE ONTO GRAPHICS OBJECT
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        private void pb_Volume_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Angle = -e.Y / 6;
                pb_Volume_Click(sender, e);

                if (e.Y > volumeHandler)
                {
                    volumeHandler = -e.Y;
                    tb_Volume.Value = volumeHandler;
                    volume = volumeHandler / 10;
                    Player.settings.volume = volume;
                }
                else
                {
                    volumeHandler = -e.Y;
                    tb_Volume.Value = volumeHandler;
                    volume = volumeHandler / 10;
                    Player.settings.volume = volume;
                }
            }
        }

        private void pb_Volume_MouseUp(object sender, MouseEventArgs e)
        {
            pb_VolumeHover.Visible = false;
            pb_Volume.Visible = true;
            bm_volumeImageStatic = (Bitmap)pb_Volume.Image;
            bm_volumeImageHover = (Bitmap)pb_VolumeHover.Image;
        }

        private void pb_credits_Click(object sender, EventArgs e)
        {
            pb_creditsPicture.Visible = true;
        }

        private void pb_creditsPicture_Click(object sender, EventArgs e)
        {
            pb_creditsPicture.Visible = !pb_creditsPicture.Visible;
        }
    }
}