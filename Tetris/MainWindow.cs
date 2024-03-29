﻿using System;
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
        NextFigure nextF;
        Counter counter;
        Random rnd;
        public MainWindow()
        {
            InitializeComponent();
            gameSpace = new GameSpace(gameWindow.CreateGraphics(), 300);
            nextF = new NextFigure(nextFigure.CreateGraphics(), 300);
            counter = new Counter();
            gameWindow.Refresh();
           
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            if (isbegin)
            {
                gameSpace.init();
                nextF.init();
                counter.reset();
                countLabel.Text = "Score: " + Convert.ToString(counter.get());
                isbegin = false;               
                rnd = new Random();
                gameSpace.setFigure(rnd.Next(1, 8));
                nextF.setFigure(rnd.Next(1, 8));

                nextF.clearFigure();
                nextF.buildFigure();
                nextF.buildGrid();

                gameSpace.unfreeze();
            }
            
            if (isrepeat)
            {
                isrepeat = false;
                gameSpace.setFigure(nextF.num());
                nextF.setFigure(rnd.Next(1, 8));

                if (gameSpace.isLocked())
                {
                    timer.Stop();
                    gametimer.Stop();
                    startButton.Enabled = true;
                }
                else
                {
                    nextF.clearFigure();
                    nextF.buildFigure();
                    nextF.buildGrid();

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
                    
                    for (int j = 19; j > 0; j--)
                    {
                        if (gameSpace.checkLine(j))                        
                        {
                            gameSpace.delete(j);
                            counter.add(100);                            
                            j++;
                        }
                    }

                    countLabel.Text = "Score: " + Convert.ToString(counter.get());
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
                counter.add(1);
                countLabel.Text = "Score: " + Convert.ToString(counter.get());
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
