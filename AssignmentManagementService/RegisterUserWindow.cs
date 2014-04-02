using System;
using System.Windows.Forms;

namespace AssignmentManagementClient
{
    public partial class RegisterUserWindow : Form
    {
        public RegisterUserWindow()
        {
            InitializeComponent();
        }

        protected virtual void OKButton_Click(object sender, EventArgs e)
        {
            var user = AdministratorPrivilegesRadioButton.Checked ? new Admin() : new User();

            user.Address = AddressTextBox.Text;
            user.Id = Guid.NewGuid();
            user.Name = NameTextBox.Text;
            user.PhoneNumber = PhoneTextBox.Text;
            user.Post = PostTextBox.Text;

            user.CreateNewPassword(PasswordTextBox.Text);

            if (this is EditUserForm)
            {
                try
                {
                    AssignmentManagementClient.UsersOrganizer.Change(user);
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                AssignmentManagementClient.UsersOrganizer.Add(user);
            }
            catch(InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
