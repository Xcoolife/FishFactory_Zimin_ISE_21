namespace FishFactoryView
{
    partial class FormImplementer
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelWorkingTime = new System.Windows.Forms.Label();
            this.labelPauseTime = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.textBoxWorkingTime = new System.Windows.Forms.TextBox();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(14, 28);
            this.labelFIO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(37, 13);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО:";
            // 
            // labelWorkingTime
            // 
            this.labelWorkingTime.AutoSize = true;
            this.labelWorkingTime.Location = new System.Drawing.Point(14, 61);
            this.labelWorkingTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWorkingTime.Name = "labelWorkingTime";
            this.labelWorkingTime.Size = new System.Drawing.Size(95, 13);
            this.labelWorkingTime.TabIndex = 1;
            this.labelWorkingTime.Text = "Время на работу:";
            // 
            // labelPauseTime
            // 
            this.labelPauseTime.AutoSize = true;
            this.labelPauseTime.Location = new System.Drawing.Point(14, 95);
            this.labelPauseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPauseTime.Name = "labelPauseTime";
            this.labelPauseTime.Size = new System.Drawing.Size(105, 13);
            this.labelPauseTime.TabIndex = 2;
            this.labelPauseTime.Text = "Время на перерыв:";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(116, 28);
            this.textBoxFIO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFIO.Multiline = true;
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(218, 19);
            this.textBoxFIO.TabIndex = 3;
            // 
            // textBoxWorkingTime
            // 
            this.textBoxWorkingTime.Location = new System.Drawing.Point(116, 58);
            this.textBoxWorkingTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxWorkingTime.Name = "textBoxWorkingTime";
            this.textBoxWorkingTime.Size = new System.Drawing.Size(218, 20);
            this.textBoxWorkingTime.TabIndex = 4;
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(116, 95);
            this.textBoxPauseTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(218, 20);
            this.textBoxPauseTime.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(90, 125);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(111, 27);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(216, 125);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 27);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 171);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxPauseTime);
            this.Controls.Add(this.textBoxWorkingTime);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelPauseTime);
            this.Controls.Add(this.labelWorkingTime);
            this.Controls.Add(this.labelFIO);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelWorkingTime;
        private System.Windows.Forms.Label labelPauseTime;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.TextBox textBoxWorkingTime;
        private System.Windows.Forms.TextBox textBoxPauseTime;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}