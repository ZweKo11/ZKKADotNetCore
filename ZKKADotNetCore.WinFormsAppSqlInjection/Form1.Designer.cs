namespace ZKKADotNetCore.WinFormsAppSqlInjection
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnLogIn = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(170, 34);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(276, 27);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(170, 81);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(276, 27);
            txtPassword.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = SystemColors.HotTrack;
            btnLogIn.Cursor = Cursors.Hand;
            btnLogIn.ForeColor = SystemColors.ControlLightLight;
            btnLogIn.Location = new Point(371, 132);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(75, 34);
            btnLogIn.TabIndex = 3;
            btnLogIn.Text = "&LogIn";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(914, 600);
            Controls.Add(btnLogIn);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtPassword;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnLogIn;
    }
}
