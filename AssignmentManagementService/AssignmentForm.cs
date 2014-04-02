using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AssignmentManagementClient
{
    public partial class AssignmentForm : Form
    {
        public AssignmentForm()
        {
            InitializeComponent();
        }

        public AssignmentForm(IEnumerable<User> users)
        {
            InitializeComponent();
            foreach (var user in users)
            {
                OwnerComboBox.Items.Add(user.Name);
            }
        }

        protected virtual void OkButton_Click(object sender, EventArgs e)
        {
            var assignment = new Assignment
                {
                    Description = DescriptionRichTextBox.Text,
                    ExpirationDate = ExpirationDateTimePicker.Value,
                    Id = Guid.NewGuid(),
                    Name = AssignmentNameBox.Text,
                    Owner = AssignmentManagementClient.UsersOrganizer.GetUserByName(AssignmentNameBox.Text).Id
                };

            AssignmentManagementClient.AssignmentOrganizer.Add(assignment);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
