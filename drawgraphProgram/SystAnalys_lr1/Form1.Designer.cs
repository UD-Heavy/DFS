namespace SystAnalys_lr1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chainButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.enterNumTextBox = new System.Windows.Forms.TextBox();
            this.enterNumbLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1483, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chainButton
            // 
            this.chainButton.Image = global::SystAnalys_lr1.Properties.Resources.chain;
            this.chainButton.Location = new System.Drawing.Point(1314, 294);
            this.chainButton.Margin = new System.Windows.Forms.Padding(4);
            this.chainButton.Name = "chainButton";
            this.chainButton.Size = new System.Drawing.Size(157, 55);
            this.chainButton.TabIndex = 10;
            this.chainButton.UseVisualStyleBackColor = true;
            this.chainButton.Click += new System.EventHandler(this.chainButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Image = global::SystAnalys_lr1.Properties.Resources.cursor;
            this.selectButton.Location = new System.Drawing.Point(1337, 159);
            this.selectButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(59, 59);
            this.selectButton.TabIndex = 9;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Image = global::SystAnalys_lr1.Properties.Resources.deleteAll;
            this.deleteALLButton.Location = new System.Drawing.Point(1397, 420);
            this.deleteALLButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(74, 55);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::SystAnalys_lr1.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(1314, 420);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 55);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Image = global::SystAnalys_lr1.Properties.Resources.edge;
            this.drawEdgeButton.Location = new System.Drawing.Point(1314, 357);
            this.drawEdgeButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(75, 55);
            this.drawEdgeButton.TabIndex = 2;
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Image = global::SystAnalys_lr1.Properties.Resources.vertex;
            this.drawVertexButton.Location = new System.Drawing.Point(1397, 357);
            this.drawVertexButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(75, 55);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(13, 13);
            this.sheet.Margin = new System.Windows.Forms.Padding(4);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(1288, 677);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1314, 123);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(157, 164);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // enterNumTextBox
            // 
            this.enterNumTextBox.Location = new System.Drawing.Point(1314, 95);
            this.enterNumTextBox.Name = "enterNumTextBox";
            this.enterNumTextBox.Size = new System.Drawing.Size(157, 22);
            this.enterNumTextBox.TabIndex = 14;
            this.enterNumTextBox.TextChanged += new System.EventHandler(this.enterNumTextBox_TextChanged);
            // 
            // enterNumbLabel
            // 
            this.enterNumbLabel.AutoSize = true;
            this.enterNumbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterNumbLabel.Location = new System.Drawing.Point(1308, 24);
            this.enterNumbLabel.Name = "enterNumbLabel";
            this.enterNumbLabel.Size = new System.Drawing.Size(138, 64);
            this.enterNumbLabel.TabIndex = 15;
            this.enterNumbLabel.Text = "Ведите\r\nвершину:";
            this.enterNumbLabel.Click += new System.EventHandler(this.enterNumbLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 703);
            this.Controls.Add(this.enterNumbLabel);
            this.Controls.Add(this.enterNumTextBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.chainButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Lab №5";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button chainButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox enterNumTextBox;
        private System.Windows.Forms.Label enterNumbLabel;
    }
}

