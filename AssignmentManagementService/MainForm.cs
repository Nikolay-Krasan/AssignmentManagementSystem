using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AssignmentManagementClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NewAssignmentButtonClick(object sender, EventArgs e)
        {
            AssignmentManagementClient.CurrentUser.CreateAssignment();
        }

        private void RegisterUserButton_Click(object sender, EventArgs e)
        {
            var registerUserWindow = new RegisterUserWindow();
            registerUserWindow.Show();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    Name = NameTextBox.Text,
                };

                user.CreateNewPassword(PasswordTextBox.Text);

                var loggedUser = AssignmentManagementClient.UsersOrganizer.LogIn(user);
                AssignmentManagementClient.CurrentUser = loggedUser;
                NameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                LogInButton.Enabled = false;
                QuitButton.Enabled = true;
                QuitButton.Visible = true;

                if (loggedUser is Admin)
                {
                    UsersList.Visible = true;
                    UsersList.Enabled = true;
                    foreach (var userFromList in AssignmentManagementClient.UsersOrganizer.AllUsers)
                    {
                        UsersList.Items.Add(userFromList.Name);
                    }
                }

                foreach (var assignment in loggedUser.GetAssignments())
                {
                    AssignmentsList.Items.Add(assignment.Name);
                }
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            NameTextBox.Enabled = true;
            PasswordTextBox.Enabled = true;

            NameTextBox.Clear();
            PasswordTextBox.Clear();

            AssignmentManagementClient.CurrentUser = null;
        }

        private void UsersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (UsersList.SelectedItem != null)
            {
                try
                {
                    var user = AssignmentManagementClient.UsersOrganizer.GetUserByName(UsersList.SelectedItem.ToString());

                    var editUserForm = new EditUserForm(user);

                    editUserForm.Show();
                    
                    editUserForm.Closed += ((_, __) =>
                        {
                            UsersList.Items.Clear();

                            foreach (var userFromList in AssignmentManagementClient.UsersOrganizer.AllUsers)
                            {
                                UsersList.Items.Add(userFromList.Name);
                            }

                            UsersList.Refresh();
                        });
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AssignmentsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AssignmentsList.SelectedItem != null)
            {
                try
                {
                    var assignment = AssignmentManagementClient.AssignmentOrganizer.GetAssignment(AssignmentsList.SelectedItem.ToString());

                    var users = AssignmentManagementClient.CurrentUser is Admin
                                    ? AssignmentManagementClient.UsersOrganizer.AllUsers
                                    : new List<User> {AssignmentManagementClient.CurrentUser};

                    var editAssignmentForm = new EditAssignmentForm(assignment, users);

                    editAssignmentForm.Show();
                    
                    editAssignmentForm.Closed += ((_, __) =>
                    {
                        AssignmentsList.Items.Clear();

                        foreach (var assignmentFromList in AssignmentManagementClient.CurrentUser.GetAssignments())
                        {
                            AssignmentsList.Items.Add(assignmentFromList.Name);
                        }

                        AssignmentsList.Refresh();
                    });
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
