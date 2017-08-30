using barleyBreak.View.UIControll;
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
using System.Windows.Threading;

namespace barleyBreak.View
{
    /// <summary>
    /// Interaction logic for GameStatistic.xaml
    /// </summary>
    public partial class GameStatistic : UserControl, IPage
    {
        public GameStatistic()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.ToMenu();
        }

        public void UpdateSteps(int value)
        {
            lblSteps.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => lblSteps.Content = value));
        }

        public void AddBtnAI(Action on, Action off)
        {
            AIButton btn = new AIButton();
            btn.SetOnOff(on, off);
            Grid.SetColumn(btn, 1);
            Grid.SetRow(btn, 0);
            MainGrid.Children.Add(btn);

        }
    }
}
