namespace DoctorClient
{
    partial class LoginForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.box_login_username = new System.Windows.Forms.TextBox();
            this.box_login_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_error_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(120, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // box_login_username
            // 
            this.box_login_username.Location = new System.Drawing.Point(70, 85);
            this.box_login_username.Margin = new System.Windows.Forms.Padding(4);
            this.box_login_username.Name = "box_login_username";
            this.box_login_username.Size = new System.Drawing.Size(200, 22);
            this.box_login_username.TabIndex = 1;
            this.box_login_username.Text = "dokter";
            // 
            // box_login_password
            // 
            this.box_login_password.Location = new System.Drawing.Point(70, 165);
            this.box_login_password.Margin = new System.Windows.Forms.Padding(4);
            this.box_login_password.Name = "box_login_password";
            this.box_login_password.PasswordChar = '*';
            this.box_login_password.Size = new System.Drawing.Size(200, 22);
            this.box_login_password.TabIndex = 2;
            this.box_login_password.Text = "Welkom123";
            this.box_login_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label_error_message
            // 
            this.label_error_message.AutoSize = true;
            this.label_error_message.ForeColor = System.Drawing.Color.Red;
            this.label_error_message.Location = new System.Drawing.Point(71, 242);
            this.label_error_message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_error_message.Name = "label_error_message";
            this.label_error_message.Size = new System.Drawing.Size(0, 17);
            this.label_error_message.TabIndex = 5;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(343, 368);
            this.Controls.Add(this.label_error_message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_login_password);
            this.Controls.Add(this.box_login_username);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox box_login_username;
        private System.Windows.Forms.TextBox box_login_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_error_message;
    }
}