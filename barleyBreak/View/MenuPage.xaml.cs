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

namespace barleyBreak.View
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class MenuPage : UserControl, IPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            ViewManager.ToGame();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.SetPage(new SettingsPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
