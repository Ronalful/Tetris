using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class NextFigure
    {
        private Figure figure;
        private int figureNum;
        private int width, length, interval;
        private Graphics window;
        private int[,] grid = new int[2, 4] 
            {
                {0, 0, 0, 0 },
                {0, 0, 0, 0 }
            };

        public NextFigure(Graphics g, int awidth)
        {
            window = g;
            width = awidth;
            length = width * 2;
            interval = width / 10;            
            this.init();
        }
        public void init()
        {
            for (int j = 0; j < 2; j++)
                for (int i = 0; i < 4; i++)
                    grid[j, i] = 0;

            window.Clear(Color.Gray);

            Pen line = new Pen(Color.Black, 1);

            for (int i = interval; i <= width; i += interval)
            {
                window.DrawLine(line, i, 0, i, length);
            }

            for (int i = interval; i <= length; i += interval)
            {
                window.DrawLine(line, 0, i, width, i);
            }

        }
        public void buildFigure()
        {
            int[,] shape = figure.getShape();
            for (int i = 0; i < figure.getSizeX(); i++)
                for (int j = 0; j < figure.getSizeY(); j++)                    
                    grid[j, i] = shape[j, i];
        }
        public void clearFigure()
        {
            int[,] shape = figure.getShape();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 2; j++)                    
                        grid[j, i] = 0;
        }
        public void setFigure(int i)
        {
            figureNum = i;
            if (i == 1)
                figure = new Figure1();
            if (i == 2)
                figure = new Figure2();
            if (i == 3)
                figure = new Figure3();
            if (i == 4)
                figure = new Figure4();
            if (i == 5)
                figure = new Figure5();
            if (i == 6)
                figure = new Figure6();
            if (i == 7)
                figure = new Figure7();
        }
        public void buildGrid()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        window.FillRectangle(Brushes.Gray, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 1)
                    {
                        window.FillRectangle(Brushes.Blue, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 2)
                    {
                        window.FillRectangle(Brushes.Green, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 3)
                    {
                        window.FillRectangle(Brushes.Orange, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 4)
                    {
                        window.FillRectangle(Brushes.Purple, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 5)
                    {
                        window.FillRectangle(Brushes.Yellow, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 6)
                    {
                        window.FillRectangle(Brushes.Red, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }

                    if (grid[i, j] == 7)
                    {
                        window.FillRectangle(Brushes.LightBlue, j * interval + 1, i * interval + 1, interval - 1, interval - 1);
                        continue;
                    }
                }

        }

        public int num()
        {
            return figureNum;
        }
    }
}
