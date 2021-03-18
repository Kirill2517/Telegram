
namespace ServerApplicationInterface
{
    partial class SignUpForm
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
            this.EmployerButton = new System.Windows.Forms.Button();
            this.ApplicantButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmployerButton
            // 
            this.EmployerButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.EmployerButton.Location = new System.Drawing.Point(97, 71);
            this.EmployerButton.Name = "EmployerButton";
            this.EmployerButton.Size = new System.Drawing.Size(250, 23);
            this.EmployerButton.TabIndex = 0;
            this.EmployerButton.Text = "Зарегистрироваться как работодатель";
            this.EmployerButton.UseVisualStyleBackColor = true;
            this.EmployerButton.Click += new System.EventHandler(this.EmployerButton_Click);
            // 
            // ApplicantButton
            // 
            this.ApplicantButton.Location = new System.Drawing.Point(97, 124);
            this.ApplicantButton.Name = "ApplicantButton";
            this.ApplicantButton.Size = new System.Drawing.Size(250, 23);
            this.ApplicantButton.TabIndex = 1;
            this.ApplicantButton.Text = "Зарегистрироваться как заявитель";
            this.ApplicantButton.UseVisualStyleBackColor = true;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 234);
            this.Controls.Add(this.ApplicantButton);
            this.Controls.Add(this.EmployerButton);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EmployerButton;
        private System.Windows.Forms.Button ApplicantButton;
    }
}