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
        bool isbegin = false;
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

                if (gameSpace.isLocked())
                {
                    timer.Stop();
                    gametimer.Stop();
                    startButton.Enabled = true;
                }
                else
                {                    
                    gameSpace.unfreeze();
                }
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
                    gameSpace.check();
                    isrepeat = true;
                }
            }

            
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timer.Stop();
                gametimer.Stop();
                startButton.Enabled = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                timer.Start();
                isbegin = true;
                isrepeat = false;
                gametimer.Start();
                startButton.Enabled = false;
            }

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
                gametimer.Stop();
                gameSpace.moveDown();
                gametimer.Start();
            }
            
            if (e.KeyCode == Keys.Up && gameSpace.isRotated())
            {
                gameSpace.rotation();
            }
        }
        

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isbegin && !gameSpace.isFreezed())
            {
                gameSpace.buildFigure();
                gameSpace.buildGrid();
            }
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            timer.Start();
            isbegin = true;
            isrepeat = false;
            gametimer.Start();
            startButton.Enabled = false;
        }
    }
}
