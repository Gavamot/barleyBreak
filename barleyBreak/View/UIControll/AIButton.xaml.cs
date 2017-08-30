using System;
using System.Collections.Generic;
using System.Linq;
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

namespace barleyBreak.View.UIControll
{
    public partial class AIButton : UserControl
    {
        public AIButton()
        {
            InitializeComponent();
            IsOn = false;
        }

        Action on, off;
        public void SetOnOff(Action on, Action off)
        {
            this.on = on;
            this.off = off;
        }

        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                Off.Visibility = isOn ? Visibility.Hidden : Visibility.Visible;
                if (IsOn)
                {
                    if (on != null) on();
                }
                else
                {
                    if (off != null) off();
                }
            }
        }

        private void AI_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsOn = !IsOn;
        }
    }
}
