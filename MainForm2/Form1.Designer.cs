
namespace MainForm2
{
    partial class Form1
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
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.showDatabaseButton = new System.Windows.Forms.Button();
            this.saveToDatabaseButton = new System.Windows.Forms.Button();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.ClearButton1 = new System.Windows.Forms.Button();
            this.saveToDatabaseButton1 = new System.Windows.Forms.Button();
            this.showDatabaseButton1 = new System.Windows.Forms.Button();
            this.saveToFileButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(64, 92);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxN.Multiline = true;
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(216, 24);
            this.textBoxN.TabIndex = 0;
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(655, 160);
            this.textBoxResults.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(542, 249);
            this.textBoxResults.TabIndex = 1;
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(63, 415);
            this.solveButton.Margin = new System.Windows.Forms.Padding(4);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(100, 28);
            this.solveButton.TabIndex = 2;
            this.solveButton.Text = "Решить";
            this.solveButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(2080, 613);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 28);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Сброс";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите количество уравнений";
            // 
            // showDatabaseButton
            // 
            this.showDatabaseButton.Location = new System.Drawing.Point(1331, 1023);
            this.showDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.showDatabaseButton.Name = "showDatabaseButton";
            this.showDatabaseButton.Size = new System.Drawing.Size(208, 28);
            this.showDatabaseButton.TabIndex = 5;
            this.showDatabaseButton.Text = "Показать базу данных";
            this.showDatabaseButton.UseVisualStyleBackColor = true;
            this.showDatabaseButton.Click += new System.EventHandler(this.showDatabaseButton_Click);
            // 
            // saveToDatabaseButton
            // 
            this.saveToDatabaseButton.Location = new System.Drawing.Point(1331, 987);
            this.saveToDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveToDatabaseButton.Name = "saveToDatabaseButton";
            this.saveToDatabaseButton.Size = new System.Drawing.Size(208, 28);
            this.saveToDatabaseButton.TabIndex = 6;
            this.saveToDatabaseButton.Text = "Сохранить в базу данных";
            this.saveToDatabaseButton.UseVisualStyleBackColor = true;
            this.saveToDatabaseButton.Click += new System.EventHandler(this.saveToDatabaseButton_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Location = new System.Drawing.Point(1972, 987);
            this.saveToFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(208, 28);
            this.saveToFileButton.TabIndex = 7;
            this.saveToFileButton.Text = "Сорхранить в файл";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // ClearButton1
            // 
            this.ClearButton1.Location = new System.Drawing.Point(512, 415);
            this.ClearButton1.Name = "ClearButton1";
            this.ClearButton1.Size = new System.Drawing.Size(105, 23);
            this.ClearButton1.TabIndex = 8;
            this.ClearButton1.Text = "Сброс";
            this.ClearButton1.UseVisualStyleBackColor = true;
            this.ClearButton1.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // saveToDatabaseButton1
            // 
            this.saveToDatabaseButton1.Location = new System.Drawing.Point(655, 415);
            this.saveToDatabaseButton1.Name = "saveToDatabaseButton1";
            this.saveToDatabaseButton1.Size = new System.Drawing.Size(136, 23);
            this.saveToDatabaseButton1.TabIndex = 9;
            this.saveToDatabaseButton1.Text = "Сохранить в БД";
            this.saveToDatabaseButton1.UseVisualStyleBackColor = true;
            this.saveToDatabaseButton1.Click += new System.EventHandler(this.saveToDatabaseButton_Click);
            // 
            // showDatabaseButton1
            // 
            this.showDatabaseButton1.Location = new System.Drawing.Point(1061, 415);
            this.showDatabaseButton1.Name = "showDatabaseButton1";
            this.showDatabaseButton1.Size = new System.Drawing.Size(136, 23);
            this.showDatabaseButton1.TabIndex = 10;
            this.showDatabaseButton1.Text = "Открыть БД";
            this.showDatabaseButton1.UseVisualStyleBackColor = true;
            this.showDatabaseButton1.Click += new System.EventHandler(this.showDatabaseButton_Click);
            // 
            // saveToFileButton1
            // 
            this.saveToFileButton1.Location = new System.Drawing.Point(657, 444);
            this.saveToFileButton1.Name = "saveToFileButton1";
            this.saveToFileButton1.Size = new System.Drawing.Size(134, 23);
            this.saveToFileButton1.TabIndex = 11;
            this.saveToFileButton1.Text = "Сохранить в файл";
            this.saveToFileButton1.UseVisualStyleBackColor = true;
            this.saveToFileButton1.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 586);
            this.Controls.Add(this.saveToFileButton1);
            this.Controls.Add(this.showDatabaseButton1);
            this.Controls.Add(this.saveToDatabaseButton1);
            this.Controls.Add(this.ClearButton1);
            this.Controls.Add(this.saveToFileButton);
            this.Controls.Add(this.saveToDatabaseButton);
            this.Controls.Add(this.showDatabaseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.textBoxResults);
            this.Controls.Add(this.textBoxN);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showDatabaseButton;
        private System.Windows.Forms.Button saveToDatabaseButton;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.Button ClearButton1;
        private System.Windows.Forms.Button saveToDatabaseButton1;
        private System.Windows.Forms.Button showDatabaseButton1;
        private System.Windows.Forms.Button saveToFileButton1;
    }
}

