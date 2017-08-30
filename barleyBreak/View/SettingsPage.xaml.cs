using barleyBreak.service;
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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl, IPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            tbName.Text = SettingsService.Instance.Name;
            btnDifficult.Content = SettingsService.Instance.Difficult;
        }

        private void btnDifficult_Click(object sender, RoutedEventArgs e)
        {
            btnDifficult.Content = SettingsService.Instance.GetNextDifficul();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var settings = SettingsService.Instance;
            settings.Name = tbName.Text;
            settings.Difficult = btnDifficult.Content.ToString();
            settings.Save();
            ViewManager.ToMenu();
        }
    }
}
