namespace ZKKADotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCancel = new Button();
            txtSave = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(86, 25);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(238, 25);
            txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(86, 87);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(238, 25);
            txtAuthor.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(86, 151);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(238, 109);
            txtContent.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 27);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 4;
            label1.Text = "Title : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 89);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 5;
            label2.Text = "Author : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 157);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 6;
            label3.Text = "Content : ";
            // 
            // txtCancel
            // 
            txtCancel.BackColor = Color.FromArgb(158, 158, 158);
            txtCancel.FlatAppearance.BorderSize = 0;
            txtCancel.FlatStyle = FlatStyle.Flat;
            txtCancel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCancel.ForeColor = SystemColors.ControlLight;
            txtCancel.Location = new Point(186, 290);
            txtCancel.Name = "txtCancel";
            txtCancel.Size = new Size(61, 32);
            txtCancel.TabIndex = 7;
            txtCancel.Text = "Cancel";
            txtCancel.UseVisualStyleBackColor = false;
            txtCancel.Click += btnCancel_Click;
            // 
            // txtSave
            // 
            txtSave.BackColor = Color.FromArgb(124, 179, 66);
            txtSave.FlatAppearance.BorderSize = 0;
            txtSave.FlatStyle = FlatStyle.Flat;
            txtSave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSave.ForeColor = Color.White;
            txtSave.Location = new Point(262, 290);
            txtSave.Name = "txtSave";
            txtSave.Size = new Size(62, 32);
            txtSave.TabIndex = 8;
            txtSave.Text = "Save";
            txtSave.UseVisualStyleBackColor = false;
            txtSave.Click += btnSave_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 510);
            Controls.Add(txtSave);
            Controls.Add(txtCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button txtCancel;
        private Button txtSave;
    }
}
