using System;
using System.Windows.Forms;

namespace AssignmentManagementClient
{
    public partial class EditUserForm : RegisterUserWindow
    {
        private readonly Guid _id;
        private readonly string _password;

        public EditUserForm(User user)
        {
            NameTextBox.Text = user.Name;
            PhoneTextBox.Text = user.PhoneNumber;
            AddressTextBox.Text = user.Address;
            PostTextBox.Text = user.Post;
            _id = user.Id;
            _password = user.Password;

            InitializeComponent();
        }

        protected override void OKButton_Click(object sender, EventArgs e)
        {
            var user = AdministratorPrivilegesRadioButton.Checked ? new Admin() : new User();

            user.Address = AddressTextBox.Text;
            user.Name = NameTextBox.Text;
            user.PhoneNumber = PhoneTextBox.Text;
            user.Post = PostTextBox.Text;
            user.Password = PasswordTextBox.Text == string.Empty ? _password : PasswordTextBox.Text;
            user.Id = _id;

            user.CreateNewPassword(PasswordTextBox.Text);

            try
            {
                AssignmentManagementClient.UsersOrganizer.Change(user);
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {

        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((_id) == AssignmentManagementClient.CurrentUser.Id)
                {
                    throw new InvalidOperationException("Can't remove myself");
                }

                var user = new User {Id = _id};
                AssignmentManagementClient.UsersOrganizer.Delete(user);
                Close();
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
