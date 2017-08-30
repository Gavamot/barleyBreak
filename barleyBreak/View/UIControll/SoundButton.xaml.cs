using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using barleyBreak.service;

namespace barleyBreak.View.UIControll
{
    /// <summary>
    /// Логика взаимодействия для SoundButton.xaml
    /// </summary>
    public partial class SoundButton : UserControl
    {
        private bool isOn = false;
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                Off.Visibility = isOn ? Visibility.Hidden : Visibility.Visible;
                if (IsOn)
                {
                    MediaPlayerService.Instance.Resume();
                }
                else
                {
                    MediaPlayerService.Instance.Pause();
                }
            }
        }

        public SoundButton()
        {
            InitializeComponent();
            MediaPlayerService.Instance.Play(MediaPlayerService.TetrisSound, true);
            IsOn = true;

        }

        private void Sound_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsOn = !IsOn; 
        }
    }
}
