namespace GameOfLife
{
    partial class GameForm
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
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Field = new System.Windows.Forms.PictureBox();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonEarly = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.AliveCountTextBox = new System.Windows.Forms.TextBox();
            this.LabelAliveCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.Ivory;
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(67, 65);
            this.Field.TabIndex = 4;
            this.Field.TabStop = false;
            this.Field.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Field_MouseMove);
            this.Field.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Field_MouseUp);
            // 
            // TimeBar
            // 
            this.TimeBar.LargeChange = 1;
            this.TimeBar.Location = new System.Drawing.Point(404, 242);
            this.TimeBar.Maximum = 40;
            this.TimeBar.Minimum = 2;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(100, 45);
            this.TimeBar.TabIndex = 6;
            this.TimeBar.Value = 20;
            this.TimeBar.ValueChanged += new System.EventHandler(this.TimeBar_ValueChanged);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ButtonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.ButtonClear.Location = new System.Drawing.Point(404, 177);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(100, 35);
            this.ButtonClear.TabIndex = 5;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonEarly
            // 
            this.ButtonEarly.Enabled = false;
            this.ButtonEarly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.ButtonEarly.Location = new System.Drawing.Point(404, 136);
            this.ButtonEarly.Name = "ButtonEarly";
            this.ButtonEarly.Size = new System.Drawing.Size(100, 35);
            this.ButtonEarly.TabIndex = 4;
            this.ButtonEarly.Text = "Early";
            this.ButtonEarly.UseVisualStyleBackColor = true;
            this.ButtonEarly.Click += new System.EventHandler(this.ButtonEarly_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNext.Location = new System.Drawing.Point(404, 94);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(100, 35);
            this.ButtonNext.TabIndex = 3;
            this.ButtonNext.Text = "Next";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPause
            // 
            this.ButtonPause.Enabled = false;
            this.ButtonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.ButtonPause.Location = new System.Drawing.Point(404, 53);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(100, 35);
            this.ButtonPause.TabIndex = 2;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStart.Location = new System.Drawing.Point(404, 12);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(100, 35);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // LabelSpeed
            // 
            this.LabelSpeed.AutoSize = true;
            this.LabelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSpeed.Location = new System.Drawing.Point(406, 214);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Size = new System.Drawing.Size(86, 25);
            this.LabelSpeed.TabIndex = 7;
            this.LabelSpeed.Text = "Speed:";
            // 
            // AliveCountTextBox
            // 
            this.AliveCountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.AliveCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AliveCountTextBox.Location = new System.Drawing.Point(404, 291);
            this.AliveCountTextBox.Name = "AliveCountTextBox";
            this.AliveCountTextBox.ReadOnly = true;
            this.AliveCountTextBox.Size = new System.Drawing.Size(100, 22);
            this.AliveCountTextBox.TabIndex = 8;
            this.AliveCountTextBox.Text = "0";
            // 
            // LabelAliveCount
            // 
            this.LabelAliveCount.AutoSize = true;
            this.LabelAliveCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAliveCount.Location = new System.Drawing.Point(407, 270);
            this.LabelAliveCount.Name = "LabelAliveCount";
            this.LabelAliveCount.Size = new System.Drawing.Size(98, 18);
            this.LabelAliveCount.TabIndex = 9;
            this.LabelAliveCount.Text = "Alive Count:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(516, 328);
            this.Controls.Add(this.LabelAliveCount);
            this.Controls.Add(this.AliveCountTextBox);
            this.Controls.Add(this.LabelSpeed);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.TimeBar);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonEarly);
            this.Controls.Add(this.ButtonPause);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Of Life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.TrackBar TimeBar;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonEarly;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.TextBox AliveCountTextBox;
        private System.Windows.Forms.Label LabelAliveCount;
    }
}