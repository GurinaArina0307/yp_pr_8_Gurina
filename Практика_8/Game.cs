using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_8
{
    internal class Game
    {
        Random rand = new Random();

        int size;
        int[,] map;
        int spase_x, spase_y;

        public Game (int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;

            this.size = size;

            map = new int[size, size];
        }
        // функцию для исключения выхода за границы
        private int coords_to_position (int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }
            else if (y > size - 1)
            {
                y = size - 1;
            }
            else
            {
                if (x > size - 1)
                {
                    x = size - 1;
                }
                if (y < 0)
                {
                    y = 0;
                }
            }

             return y * size + x;
        }

        private void position_to_coords (int position, out int x, out int y)
        {
            x = position % size;
            y = position / size;
        }

        // функцию, готовящую поле к игре
        public void start()
        {
            for (int x = 0; x < size; x++) 
                for (int y = 0; y < size; y++)
                    map[x, y] = coords_to_position(x, y) + 1;
            spase_x = size - 1;
            spase_y = size - 1;
            map[spase_x, spase_y] = 0;

        }

        // Добавим метод позволяющий по тегу (позиции) возвращать надпись на кнопке, в зависимости от ее положения в массиве 
        public int get_number (int position)
        {
            int x, y;

            position_to_coords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }
        public void shift(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            map[spase_x, spase_y] = map[x, y];
            if (Math.Abs(spase_x - x) + Math.Abs(spase_y - y) != 1)
                return;
          //  map[x, y] = 0;

            map[spase_x, spase_y] = map[x, y];
            map[x, y] = 0;
            spase_x = x;
            spase_y = y;
        }

        public void shift_random()
        {
            int a = rand.Next(0, 4);
            int x = spase_x;
            int y = spase_y;

            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }

            shift(coords_to_position(x, y));
        }


    }
}
