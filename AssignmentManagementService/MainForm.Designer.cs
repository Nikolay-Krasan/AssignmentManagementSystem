namespace AssignmentManagementClient
{
    partial class MainForm
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
            this.newAssignmentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.RegisterUserButton = new System.Windows.Forms.Button();
            this.LogInButton = new System.Windows.Forms.Button();
            this.AssignmentsList = new System.Windows.Forms.ListBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.UsersList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // newAssignmentButton
            // 
            this.newAssignmentButton.Location = new System.Drawing.Point(12, 12);
            this.newAssignmentButton.Name = "newAssignmentButton";
            this.newAssignmentButton.Size = new System.Drawing.Size(124, 23);
            this.newAssignmentButton.TabIndex = 0;
            this.newAssignmentButton.Text = "New Assignment";
            this.newAssignmentButton.UseVisualStyleBackColor = true;
            this.newAssignmentButton.Click += new System.EventHandler(this.NewAssignmentButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(230, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(172, 20);
            this.NameTextBox.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(230, 38);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(172, 20);
            this.PasswordTextBox.TabIndex = 5;
            // 
            // RegisterUserButton
            // 
            this.RegisterUserButton.Location = new System.Drawing.Point(409, 12);
            this.RegisterUserButton.Name = "RegisterUserButton";
            this.RegisterUserButton.Size = new System.Drawing.Size(123, 23);
            this.RegisterUserButton.TabIndex = 6;
            this.RegisterUserButton.Text = "Register";
            this.RegisterUserButton.UseVisualStyleBackColor = true;
            this.RegisterUserButton.Click += new System.EventHandler(this.RegisterUserButton_Click);
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(409, 41);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(123, 23);
            this.LogInButton.TabIndex = 7;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // AssignmentsList
            // 
            this.AssignmentsList.FormattingEnabled = true;
            this.AssignmentsList.Location = new System.Drawing.Point(13, 76);
            this.AssignmentsList.Name = "AssignmentsList";
            this.AssignmentsList.Size = new System.Drawing.Size(251, 251);
            this.AssignmentsList.TabIndex = 10;
            this.AssignmentsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AssignmentsList_MouseDoubleClick);
            // 
            // QuitButton
            // 
            this.QuitButton.Enabled = false;
            this.QuitButton.Location = new System.Drawing.Point(13, 41);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(123, 23);
            this.QuitButton.TabIndex = 11;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Visible = false;
            this.QuitButton.Click += new System.EventHandler(this.Quit_Click);
            // 
            // UsersList
            // 
            this.UsersList.FormattingEnabled = true;
            this.UsersList.Location = new System.Drawing.Point(270, 76);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(262, 251);
            this.UsersList.TabIndex = 12;
            this.UsersList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UsersList_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 347);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.AssignmentsList);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.RegisterUserButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newAssignmentButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newAssignmentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button RegisterUserButton;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.ListBox AssignmentsList;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.ListBox UsersList;
    }
}

