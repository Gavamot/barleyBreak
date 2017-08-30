using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace barleyBreak.service
{
    class MediaPlayerService
    {
        public static readonly string SoundFolder = AppDomain.CurrentDomain.BaseDirectory + @"sound\";
        public static readonly string TetrisSound = SoundFolder + "tetris.mp3";
        public static readonly string ImperiaSound = SoundFolder + "imperia.mp3";

        private static readonly MediaPlayerService instance = new MediaPlayerService();
        private readonly WindowsMediaPlayer player;
        public static string currentSound  = TetrisSound;
        private bool paused = false;

        MediaPlayerService()
        {
            player = new WindowsMediaPlayer();
            Volume = 20;
        }

        public static MediaPlayerService Instance => instance;

        private int volume;
        public const int MIN_VOLUME = 0;
        public const int MAX_VOLUME = 100;

        public int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                if (value > MAX_VOLUME) value = MAX_VOLUME;
                else if (value < MIN_VOLUME) value = MIN_VOLUME;
                volume = value;
                player.settings.volume = value;
            }
        }

        public void Play(string path, bool loop)
        {
            if (currentSound == path) return;
            currentSound = path;
            (this.player.settings as WMPLib.IWMPSettings).setMode("loop", loop);
            if (!paused)
            {
                player.URL = path;
                player.controls.play();
            }
        }

        public void Pause()
        {
            player.controls.pause();
            paused = true;
        }

        public void Resume()
        {
            paused = false;
            if(player.URL != currentSound)
            {
                player.URL = currentSound;
            }
            player.controls.play();
        }

        public void Stop()
        {
            player.controls.stop();
        }
    }
}
