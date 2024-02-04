using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figure
    {
        protected int x, y;
        protected int[] sizeX, sizeY;
        protected int gridScale;
        protected int rotationStates;
        protected int rotation;
        protected int[,] shape;
        protected int[,,] storage;
        protected int c; //color

        public int getX() { return x; }
        public int getY() { return y; }
        public int getSizeX() { return sizeX[rotation]; }
        public int getSizeY() { return sizeY[rotation]; }
        public int[,] getShape() { return shape; }
        public void setX(int x) { this.x = x; }
        public void setY(int y) { this.y = y; }

        public bool checkDown(int[,] grid)
        {
            int j;
            for (int i = 0; i < sizeX[rotation]; i++)
            {
                j = sizeY[rotation] - 1;
                while (j >= 0)
                {

                    if (shape[j, i] > 0)
                    {
                        if (grid[y + j + 1, x + i] > 0)
                            return false;
                        else
                            break;
                    }
                    j--;
                }
            }
            return true;
        }
        public bool checkLeft(int[,] grid)
        {
            int i;
            for (int j = 0; j < sizeY[rotation]; j++)
            {
                i = 0;
                while (i < sizeX[rotation])
                {

                    if (shape[j, i] > 0)
                    {
                        if (grid[y + j, x + i - 1] > 0)
                            return false;
                        else
                            break;
                    }
                    i++;
                }
            }
            return true;
        }
        public bool checkRight(int[,] grid)
        {
            int i;
            for (int j = 0; j < sizeY[rotation]; j++)
            {
                i = sizeX[rotation] - 1;
                while (i >= 0)
                {

                    if (shape[j, i] > 0)
                    {
                        if (grid[y + j, x + i + 1] > 0)
                            return false;
                        else
                            break;
                    }
                    i--;
                }
            }
            return true;
        }
        public bool checkRotation(int[,] grid)
        {
            int next_rotation = getRotatedState();

            if (x + sizeX[next_rotation] > 10 || y + sizeY[next_rotation] > 20)
                return false;
           
            for (int j = 0; j < sizeY[next_rotation]; j++)
            {
                for (int i = 0; i < sizeX[next_rotation]; i++)                    
                {
                    if (storage[next_rotation, j, i] > 0)
                    {
                        if (shape[j, i] == 0 && grid[y + j, x + i] > 0)
                            return false;
                    }
                    
                }
            }
            return true;            
        }
        public void rotate() 
        {
            rotation = getRotatedState();
            setShape(rotation);
        }
        public void setShape(int r) 
        {
            shape = new int[gridScale, gridScale];
            for (int i = 0; i < gridScale; i++)
                for (int j = 0; j < gridScale; j++)
                    shape[i, j] = storage[r, i, j];
        }
        public int getRotatedState()
        {
            if (rotation + 1 > rotationStates - 1) return 0;
            else return rotation + 1;
        }
    }

    class Figure1 : Figure
    {       
    public Figure1()
        {
            x = 4; 
            y = 0;

            c = 6;

            sizeX = new int[] {3, 2};
            sizeY = new int[] { 2, 3 };
            rotationStates = 2;
            gridScale = 3;
            rotation = 0;
            storage = new int[,,] {                
                {                   
                    { c, c, 0 },
                    { 0, c, c },
                    { 0, 0, 0 },
                },
                {
                    { 0, c, 0 },
                    { c, c, 0 },
                    { c, 0, 0 }
                }
            };

            setShape(rotation);
        }     
    }    
    class Figure2 : Figure
    {
        public Figure2()
        {
            x = 4;
            y = 0;

            c = 4;

            sizeX = new int[] {3, 2, 3, 2 };
            sizeY = new int[] {2, 3, 2, 3 };
            rotationStates = 4;
            gridScale = 3;
            rotation = 0;
            storage = new int[,,] {                
                {
                    { 0, c, 0 },
                    { c, c, c },
                    { 0, 0, 0 },
                },
                {
                    { c, 0, 0 },
                    { c, c, 0 },
                    { c, 0, 0 },
                },
                {
                    { c, c, c },
                    { 0, c, 0 },
                    { 0, 0, 0 },
                },
                {
                    { 0, c, 0 },
                    { c, c, 0 },
                    { 0, c, 0 },
                },

            };
            setShape(rotation);

        }
    }
    class Figure3 : Figure
    {
        public Figure3()
        {
            x = 4;
            y = 0;

            c = 1;

            sizeX = new int[] { 3, 2, 3, 2 };
            sizeY = new int[] { 2, 3, 2, 3 };
            rotationStates = 4;
            gridScale = 3;
            rotation = 0;
            storage = new int[,,] {
                {
                    { c, 0, 0 },
                    { c, c, c },
                    { 0, 0, 0 },
                },
                {
                    { c, c, 0 },
                    { c, 0, 0 },
                    { c, 0, 0 }
                },
                {
                    { c, c, c },
                    { 0, 0, c },
                    { 0, 0, 0 },
                },
                {
                    { 0, c, 0 },
                    { 0, c, 0 },
                    { c, c, 0 }
                }
            };

            setShape(rotation);
        }
    }
    class Figure4 : Figure
    {
        public Figure4()
        {
            x = 4;
            y = 0;

            c = 2;

            sizeX = new int[] { 3, 2};
            sizeY = new int[] { 2, 3};
            rotationStates = 2;
            gridScale = 3;
            rotation = 0;
            storage = new int[,,] {
                {
                    { 0, c, c },
                    { c, c, 0 },
                    { 0, 0, 0 },
                },
                {
                    { c, 0, 0 },
                    { c, c, 0 },
                    { 0, c, 0 }
                }
            };

            setShape(rotation);
        }
    }
    class Figure5 : Figure
    {
        public Figure5()
        {
            x = 4;
            y = 0;

            c = 3;

            sizeX = new int[] { 3, 2, 3, 2 };
            sizeY = new int[] { 2, 3, 2, 3 };
            rotationStates = 4;
            gridScale = 3;
            rotation = 0;
            storage = new int[,,] {
                {
                    { 0, 0, c },
                    { c, c, c },
                    { 0, 0, 0 },
                },
                {
                    { c, 0, 0 },
                    { c, 0, 0 },
                    { c, c, 0 }
                },
                {
                    { c, c, c },
                    { c, 0, 0 },
                    { 0, 0, 0 },
                },
                {
                    { c, c, 0 },
                    { 0, c, 0 },
                    { 0, c, 0 }
                }
            };

            setShape(rotation);
        }
    }
    class Figure6 : Figure
    {
        public Figure6()
        {
            x = 4;
            y = 0;

            c = 5;

            sizeX = new int[] { 2 };
            sizeY = new int[] { 2 };
            rotationStates = 1;
            gridScale = 2;
            rotation = 0;
            storage = new int[,,] {
                {
                    { c, c},
                    { c, c}                    
                }                
            };

            setShape(rotation);
        }
    }
    class Figure7 : Figure
    {
        public Figure7()
        {
            x = 4;
            y = 0;

            c = 7;

            sizeX = new int[] { 4, 1 };
            sizeY = new int[] { 1, 4 };
            rotationStates = 2;
            gridScale = 4;
            rotation = 0;
            storage = new int[,,] {
                {
                    { c, c, c, c },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { c, 0, 0, 0 },
                    { c, 0, 0, 0 },
                    { c, 0, 0, 0 },
                    { c, 0, 0, 0 }
                }
            };

            setShape(rotation);
        }
    }
}
