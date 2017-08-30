using barleyBreak.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barleyBreak
{
    public class GameMap 
    {
        /// <summary>
        /// Размеры игрового поля
        /// </summary>
        public enum Size
        {
            Small = 3,
            Middle = 4,
            Big = 5
        }

        private Cell[,] map;
        public GameMapUI gameMapUI { get; set; }
        
        public readonly int size;
        public readonly Game game;

        public GameMap(Size size, Game game)
        {
            this.game = game;
            this.size = (int)size;
            GenetateMap();
            Shuffle();
        }

        /// <summary>
        /// Генерирует игровое поле
        /// </summary>
        public void GenetateMap()
        {
            int max = size * size;
            int val = 1;
            this.map = new Cell[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (val == max) val = 0;
                    map[x, y] = new Cell(x, y, val++, this);
                }
            }
            
        }

        private const int SHUFFLE_COUNT = 500;

        /// <summary>
        /// Перемешивает ячейки
        /// </summary>
        private void Shuffle()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            do
            {
                for (int i = 0; i < SHUFFLE_COUNT; i++)
                {
                    int x = EmptyCell.X, y = EmptyCell.Y;

                    int mult = rnd.Next(0, 2) == 0 ? 1 : -1;
                    int dx = rnd.Next(0, 2) * mult;
                    int dy = rnd.Next(0, 2) * mult;

                    int newX = x + dx, newY = y + dy;
                    if(!Swap(x, y, newX, newY))
                        i--;
                }
            } while (IsWinner());

        }

        private bool Swap(int emptyX, int emptyY, int cellX, int cellY)
        {
            int dx = cellX - emptyX;
            int dy = cellY - emptyY;
            if (Math.Abs(dx + dy) == 1)
            {
                if (cellX >= 0 && cellX < size && cellY >= 0 && cellY < size)
                {
                    Cell tmp = map[emptyX, emptyY];
                    map[emptyX, emptyY] = map[cellX, cellY];
                    map[emptyX, emptyY].SetPosition(emptyX, emptyY);
                    map[cellX, cellY] = tmp;
                    map[cellX, cellY].SetPosition(cellX, cellY);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Меняет местами ячейку с пустой ячейкой
        /// </summary>
        /// <param name="x">Ячейка для замены</param>
        /// <returns>true - если обмен удолся и false в случаи неудачи</returns>
        public bool Swap(Cell cell)
        {
            Cell emptyCell = EmptyCell;
            
            if (Swap(emptyCell.X, emptyCell.Y, cell.X, cell.Y))
            {
                game.IncrementSteps();
                if (IsWinner())
                {
                    gameMapUI.Win();
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// Определяет победил ли игрок
        /// </summary>
        /// <returns>true - если победил. false - не победил</returns>
        public bool IsWinner()
        {
            int max = size * size;
            int val = 1;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (val == max)
                    {
                        val = Cell.EMPTY_VALUE;
                    }

                    if (map[x, y].Value != val)
                    {
                        return false;
                    }
                   
                    val++;
                }
            }
            return true;
        }

        /// <summary>
        /// Ищет пустую ячейку 
        /// </summary>
        public Cell EmptyCell
        {
            get
            {
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if (map[x, y].IsEmpty) return map[x, y];
                    }
                }
                throw new Exception("Пустая ячейка не обнаружена в коллекции");
            }
        }

        /// <summary>
        /// Получить ячейку по координатам
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell this[int x, int y]
        {
            get { return map[x, y]; }
        }

    }
}
