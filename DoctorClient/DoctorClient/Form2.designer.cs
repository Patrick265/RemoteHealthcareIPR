namespace DoctorClient
{
    partial class Form2
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.nametxt = new System.Windows.Forms.Label();
            this.dateofbirthtxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(11, 91);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.MinimumSize = new System.Drawing.Size(205, 404);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 404);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.textBox3.Location = new System.Drawing.Point(221, 91);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(513, 398);
            this.textBox3.TabIndex = 3;
            // 
            // nametxt
            // 
            this.nametxt.BackColor = System.Drawing.Color.White;
            this.nametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nametxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.nametxt.Location = new System.Drawing.Point(11, 10);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(173, 30);
            this.nametxt.TabIndex = 88;
            this.nametxt.Text = "nametxt";
            // 
            // dateofbirthtxt
            // 
            this.dateofbirthtxt.BackColor = System.Drawing.Color.White;
            this.dateofbirthtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateofbirthtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateofbirthtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(108)))));
            this.dateofbirthtxt.Location = new System.Drawing.Point(11, 49);
            this.dateofbirthtxt.Name = "dateofbirthtxt";
            this.dateofbirthtxt.Size = new System.Drawing.Size(165, 29);
            this.dateofbirthtxt.TabIndex = 89;
            this.dateofbirthtxt.Text = "dateofbirthtxt";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.dateofbirthtxt);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(974, 618);
            this.MinimumSize = new System.Drawing.Size(974, 618);
            this.Name = "Form2";
            this.Text = "`";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label nametxt;
        private System.Windows.Forms.Label dateofbirthtxt;
    }
}