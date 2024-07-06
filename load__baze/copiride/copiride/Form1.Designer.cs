namespace copiride
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnCopyFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tim_Этапы = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(59, 27);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "button1";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.Location = new System.Drawing.Point(212, 27);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(75, 23);
            this.btnCopyFile.TabIndex = 1;
            this.btnCopyFile.Text = "button2";
            this.btnCopyFile.UseVisualStyleBackColor = true;
            this.btnCopyFile.Click += new System.EventHandler(this.btnCopyFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 58);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(357, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "...";
            // 
            // tim_Этапы
            // 
            this.tim_Этапы.Tick += new System.EventHandler(this.tim_Этапы_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCopyFile);
            this.Controls.Add(this.btnChooseFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(397, 129);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(397, 129);
            this.Name = "Form1";
            this.Text = "Перенос файлов.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnCopyFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tim_Этапы;
    }
}

