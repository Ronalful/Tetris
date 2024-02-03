using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainWindow : Form
    {
        bool isbegin = true;
        bool isrepeat = false;
        GameSpace gameSpace;
        Random rnd;
        public MainWindow()
        {
            InitializeComponent();
            gameSpace = new GameSpace(gameWindow.CreateGraphics(), 300);
            gameWindow.Refresh();
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            if (isbegin)
            {
                gameSpace.init();
                isbegin = false;  
                rnd = new Random();
                gameSpace.setFigure(rnd.Next(1, 8));
                gameSpace.unfreeze();
            }
            
            if (isrepeat)
            {
                isrepeat = false;
                gameSpace.setFigure(rnd.Next(1, 8));
                gameSpace.unfreeze();
            }
            else
            {
                if (!gameSpace.isGround())
                {
                    gameSpace.moveDown();                    
                }
                else
                {
                    gameSpace.freeze();
                    isrepeat = true;
                }
            }

            
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Left && !gameSpace.isLeftWall())
            {
                gameSpace.moveLeft();
            }

            if (e.KeyCode == Keys.Right && !gameSpace.isRightWall())
            {
                gameSpace.moveRight();
            }

            if (e.KeyCode == Keys.Down && !gameSpace.isGround())
            {
                gameSpace.moveDown();
            }
            
            if (e.KeyCode == Keys.Up && gameSpace.isRotated())
            {
                gameSpace.rotation();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isbegin)
            {
                gameSpace.buildFigure();
                gameSpace.buildGrid();
            }
        }
    }
}
