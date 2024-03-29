﻿namespace Tetris
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameWindow = new System.Windows.Forms.PictureBox();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.nextFigure = new System.Windows.Forms.PictureBox();
            this.countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextFigure)).BeginInit();
            this.SuspendLayout();
            // 
            // gameWindow
            // 
            this.gameWindow.Location = new System.Drawing.Point(26, 12);
            this.gameWindow.Name = "gameWindow";
            this.gameWindow.Size = new System.Drawing.Size(300, 600);
            this.gameWindow.TabIndex = 0;
            this.gameWindow.TabStop = false;
            // 
            // gametimer
            // 
            this.gametimer.Interval = 1000;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(401, 570);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(96, 42);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // nextFigure
            // 
            this.nextFigure.Location = new System.Drawing.Point(387, 97);
            this.nextFigure.Name = "nextFigure";
            this.nextFigure.Size = new System.Drawing.Size(120, 60);
            this.nextFigure.TabIndex = 2;
            this.nextFigure.TabStop = false;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countLabel.Location = new System.Drawing.Point(332, 199);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(134, 36);
            this.countLabel.TabIndex = 3;
            this.countLabel.Text = "Score: 0";
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(555, 647);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.nextFigure);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameWindow);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextFigure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameWindow;
        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox nextFigure;
        private System.Windows.Forms.Label countLabel;
    }
}

