using barleyBreak.service;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace barleyBreak.View
{
    public static class ViewManager
    { 
        public static MainWindow Window;
        public static void ToMenu()
        {
            SetPage(new MenuPage());
            MediaPlayerService.Instance.Play(MediaPlayerService.TetrisSound, true);
        }

        private static void SetUpPage(UserControl page, int row, int col)
        {
            Window.MainGrid.Children.Add(page);
            Grid.SetRow(page, row);
            Grid.SetColumn(page, col);
        }

        public static void ToGame()
        {
          
            DeletePages();
            var statPage = new GameStatistic();
            var mapPage = new GameMapUI();
            Game game = new Game(statPage, mapPage);
            mapPage.Init(game);
            SetUpPage(statPage, 1, 0);
            SetUpPage(mapPage, 1, 1);
        }

        private static void DeletePages()
        {
            var deleted = new List<UIElement>();

            foreach (UIElement item in Window.MainGrid.Children)
            {
                if (item is IPage)
                {
                    deleted.Add(item);
                }
            }

            for (int i = 0; i < deleted.Count; i++)
            {
                Window.MainGrid.Children.Remove(deleted[i]);
            }
        }

        public static void SetPage(UserControl page)
        {
            DeletePages();
            SetUpPage(page, 1, 1);
        }
    }
}
