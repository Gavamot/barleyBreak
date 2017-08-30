using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace barleyBreak.View
{
    public partial class GameMapUI : UserControl, IPage
    {
        public GameMap GameMap { get; private set; }
        public Game game { get; private set; }
        public GameMapUI()
        {
            InitializeComponent();
        }

        public void Init(Game game)
        {
            this.game = game;
            GameMap = game.Map;
            game.Map.gameMapUI = this;
            CreateGrid(GameMap.size);
            AddCells(GameMap.size);

           
        }

        private void CreateGrid(int size)
        {
            for (int i = 0; i < size; i++)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                MainGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void AddCells(int size)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var cellUI = new CellUI(GameMap[x, y]);
                    MainGrid.Children.Add(cellUI);
                    cellUI.SetPosition(x, y);
                }
            }
        }
        
        public void Win()
        {
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();
            MainGrid.Children.Clear();
            var webImage = new BitmapImage(new Uri("pack://application:,,,/img/win.png"));
            var imageControl = new Image { Source = webImage };
            MainGrid.Children.Add(imageControl);
        }
    }
}
