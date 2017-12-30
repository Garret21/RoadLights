namespace RoadLights
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartStopBtn = new System.Windows.Forms.Button();
            this.TurnTimer = new System.Windows.Forms.Timer(this.components);
            this.TimerCreator = new System.Windows.Forms.Timer(this.components);
            this.BackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartStopBtn
            // 
            this.StartStopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartStopBtn.Location = new System.Drawing.Point(216, 48);
            this.StartStopBtn.Name = "StartStopBtn";
            this.StartStopBtn.Size = new System.Drawing.Size(75, 50);
            this.StartStopBtn.TabIndex = 0;
            this.StartStopBtn.Text = "Start";
            this.StartStopBtn.UseVisualStyleBackColor = true;
            this.StartStopBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // TurnTimer
            // 
            this.TurnTimer.Interval = 300;
            this.TurnTimer.Tick += new System.EventHandler(this.TurnTimer_Tick);
            // 
            // TimerCreator
            // 
            this.TimerCreator.Interval = 900;
            this.TimerCreator.Tick += new System.EventHandler(this.TimerCreator_Tick);
            // 
            // BackBtn
            // 
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackBtn.Location = new System.Drawing.Point(216, 104);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 50);
            this.BackBtn.TabIndex = 1;
            this.BackBtn.Text = "Menu";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 222);
            this.ControlBox = false;
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.StartStopBtn);
            this.DoubleBuffered = true;
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartStopBtn;
        private System.Windows.Forms.Timer TurnTimer;
        private System.Windows.Forms.Timer TimerCreator;
        private System.Windows.Forms.Button BackBtn;


    }
}