
namespace generatorView.panels
{
    partial class SingUpPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.applicant = new System.Windows.Forms.CheckBox();
            this.employer = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.log = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // applicant
            // 
            this.applicant.AutoSize = true;
            this.applicant.Location = new System.Drawing.Point(4, 14);
            this.applicant.Name = "applicant";
            this.applicant.Size = new System.Drawing.Size(69, 17);
            this.applicant.TabIndex = 0;
            this.applicant.Text = "applicant";
            this.applicant.UseVisualStyleBackColor = true;
            // 
            // employer
            // 
            this.employer.AutoSize = true;
            this.employer.Location = new System.Drawing.Point(4, 38);
            this.employer.Name = "employer";
            this.employer.Size = new System.Drawing.Size(68, 17);
            this.employer.TabIndex = 1;
            this.employer.Text = "employer";
            this.employer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Колиество";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(71, 72);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(97, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // log
            // 
            this.log.AutoSize = true;
            this.log.Location = new System.Drawing.Point(4, 134);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(35, 13);
            this.log.TabIndex = 4;
            this.log.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SingUpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.employer);
            this.Controls.Add(this.applicant);
            this.Name = "SingUpPanel";
            this.Size = new System.Drawing.Size(347, 250);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox applicant;
        private System.Windows.Forms.CheckBox employer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label log;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
