
namespace ServerApplicationInterface
{
    partial class SignUpDataUserForm
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
            this.emailTB = new System.Windows.Forms.TextBox();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.middleNameTB = new System.Windows.Forms.TextBox();
            this.surnameTB = new System.Windows.Forms.TextBox();
            this.phoneTB = new System.Windows.Forms.TextBox();
            this.birthdayDTP = new System.Windows.Forms.DateTimePicker();
            this.idSex = new System.Windows.Forms.TextBox();
            this.idEducation = new System.Windows.Forms.TextBox();
            this.idTypeEmployment = new System.Windows.Forms.TextBox();
            this.desiredArea = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(12, 12);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(100, 20);
            this.emailTB.TabIndex = 0;
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(12, 53);
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(100, 20);
            this.firstNameTB.TabIndex = 1;
            // 
            // middleNameTB
            // 
            this.middleNameTB.Location = new System.Drawing.Point(12, 94);
            this.middleNameTB.Name = "middleNameTB";
            this.middleNameTB.Size = new System.Drawing.Size(100, 20);
            this.middleNameTB.TabIndex = 2;
            // 
            // surnameTB
            // 
            this.surnameTB.Location = new System.Drawing.Point(12, 137);
            this.surnameTB.Name = "surnameTB";
            this.surnameTB.Size = new System.Drawing.Size(100, 20);
            this.surnameTB.TabIndex = 3;
            // 
            // phoneTB
            // 
            this.phoneTB.Location = new System.Drawing.Point(12, 224);
            this.phoneTB.Name = "phoneTB";
            this.phoneTB.Size = new System.Drawing.Size(100, 20);
            this.phoneTB.TabIndex = 5;
            // 
            // birthdayDTP
            // 
            this.birthdayDTP.Location = new System.Drawing.Point(12, 181);
            this.birthdayDTP.Name = "birthdayDTP";
            this.birthdayDTP.Size = new System.Drawing.Size(140, 20);
            this.birthdayDTP.TabIndex = 6;
            // 
            // idSex
            // 
            this.idSex.Location = new System.Drawing.Point(208, 12);
            this.idSex.Name = "idSex";
            this.idSex.Size = new System.Drawing.Size(100, 20);
            this.idSex.TabIndex = 7;
            // 
            // idEducation
            // 
            this.idEducation.Location = new System.Drawing.Point(208, 53);
            this.idEducation.Name = "idEducation";
            this.idEducation.Size = new System.Drawing.Size(100, 20);
            this.idEducation.TabIndex = 8;
            // 
            // idTypeEmployment
            // 
            this.idTypeEmployment.Location = new System.Drawing.Point(208, 94);
            this.idTypeEmployment.Name = "idTypeEmployment";
            this.idTypeEmployment.Size = new System.Drawing.Size(100, 20);
            this.idTypeEmployment.TabIndex = 9;
            // 
            // desiredArea
            // 
            this.desiredArea.Location = new System.Drawing.Point(208, 137);
            this.desiredArea.Name = "desiredArea";
            this.desiredArea.Size = new System.Drawing.Size(100, 20);
            this.desiredArea.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Зарегистрировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(208, 181);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(100, 20);
            this.passwordTB.TabIndex = 12;
            // 
            // SignUpDataUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 256);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.desiredArea);
            this.Controls.Add(this.idTypeEmployment);
            this.Controls.Add(this.idEducation);
            this.Controls.Add(this.idSex);
            this.Controls.Add(this.birthdayDTP);
            this.Controls.Add(this.phoneTB);
            this.Controls.Add(this.surnameTB);
            this.Controls.Add(this.middleNameTB);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.emailTB);
            this.Name = "SignUpDataUserForm";
            this.Text = "SignUpDataUserForm";
            this.Load += new System.EventHandler(this.SignUpDataUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox firstNameTB;
        private System.Windows.Forms.TextBox middleNameTB;
        private System.Windows.Forms.TextBox surnameTB;
        private System.Windows.Forms.TextBox phoneTB;
        private System.Windows.Forms.DateTimePicker birthdayDTP;
        private System.Windows.Forms.TextBox idSex;
        private System.Windows.Forms.TextBox idEducation;
        private System.Windows.Forms.TextBox idTypeEmployment;
        private System.Windows.Forms.TextBox desiredArea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox passwordTB;
    }
}