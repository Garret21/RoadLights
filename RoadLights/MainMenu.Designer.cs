namespace RoadLights
{
    partial class MainMenu
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
            this.ExitBtn = new System.Windows.Forms.Button();
            this.EditorBtn = new System.Windows.Forms.Button();
            this.GameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitBtn.Location = new System.Drawing.Point(12, 124);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(150, 50);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // EditorBtn
            // 
            this.EditorBtn.BackColor = System.Drawing.Color.Yellow;
            this.EditorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditorBtn.Location = new System.Drawing.Point(12, 68);
            this.EditorBtn.Name = "EditorBtn";
            this.EditorBtn.Size = new System.Drawing.Size(150, 50);
            this.EditorBtn.TabIndex = 2;
            this.EditorBtn.Text = "Editor";
            this.EditorBtn.UseVisualStyleBackColor = false;
            this.EditorBtn.Click += new System.EventHandler(this.EditorBtn_Click);
            // 
            // GameBtn
            // 
            this.GameBtn.BackColor = System.Drawing.Color.Red;
            this.GameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameBtn.Location = new System.Drawing.Point(12, 12);
            this.GameBtn.Name = "GameBtn";
            this.GameBtn.Size = new System.Drawing.Size(150, 50);
            this.GameBtn.TabIndex = 1;
            this.GameBtn.Text = "New Game";
            this.GameBtn.UseVisualStyleBackColor = false;
            this.GameBtn.Click += new System.EventHandler(this.GameBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(176, 192);
            this.ControlBox = false;
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.EditorBtn);
            this.Controls.Add(this.GameBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button EditorBtn;
        private System.Windows.Forms.Button GameBtn;

    }
}