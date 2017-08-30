using barleyBreak.service;
using barleyBreak.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barleyBreak
{
    public class Game
    {
        public GameMapUI GameMapUI { get; set; }
        public GameStatistic GameStatUI { get; set; }
        public readonly AI AI;

        public Game(GameStatistic statUI, GameMapUI mapUI)
        {
            GameMapUI = mapUI;
            GameStatUI = statUI;
            var settings = service.SettingsService.Instance;
            settings.Load();
            UserName = settings.Name;
            Difficult = settings.Difficult;
            Map = new GameMap((GameMap.Size)settings.MapSize, this);
            AI = new RandomAI(Map);

            GameStatUI.AddBtnAI(
            () =>
            {
                AI.Start();
                MediaPlayerService.Instance.Play(MediaPlayerService.ImperiaSound, true);
            },
            () =>
            {
                AI.Stop();
                MediaPlayerService.Instance.Play(MediaPlayerService.TetrisSound, true);
            });

        }

        public string UserName { get; set; }
        public string Difficult { get; set; }
        public GameMap Map { get; set; }

        public int steps;
        public int Steps { get { return steps; } }

        public void IncrementSteps()
        {
            GameStatUI.UpdateSteps(++steps);
        }
    }
}
