using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace barleyBreak.View
{
    public partial class CellUI : UserControl
    {
        private readonly Cell cell;
        public CellUI(Cell cell)
        {
            this.cell = cell;
            InitializeComponent();
            InitCell(cell);
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            cell.Move();
        }

        public void SetPosition(int x, int y)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                Grid.SetRow(this, x);
                Grid.SetColumn(this, y);
            }));
           
            
        }

        private void InitCell(Cell cell)
        {
            if (cell.IsEmpty)
            {
                BtnMain.Background = GetImageBrush(Properties.Resources.empty);
                BtnMain.IsEnabled = false;
            }
            else
            {
                LblValue.Content = cell.Value;
                BtnMain.Background = GetImageBrush(Properties.Resources.cell);
            }
            cell.AddPositionChangedListner(SetPosition);
        }

        private ImageBrush GetImageBrush(Bitmap bitmap)
        {
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
            );
            bitmap.Dispose();
            return new ImageBrush(bitmapSource);
        }

      
    }
}
