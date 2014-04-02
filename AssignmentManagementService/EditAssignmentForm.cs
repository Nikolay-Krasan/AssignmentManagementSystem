using System;
using System.Collections.Generic;

namespace AssignmentManagementClient
{
    public partial class EditAssignmentForm : AssignmentForm
    {
        private Guid _id;

        public EditAssignmentForm(Assignment assignment, List<User> users)
        {
            InitializeComponent();

            DescriptionRichTextBox.Text = assignment.Description;
            ExpirationDateTimePicker.Value = assignment.ExpirationDate;
            AssignmentNameBox.Text = assignment.Name;
            foreach (var user in users)
            {
                OwnerComboBox.Items.Add(user.Name);
            };

            OwnerComboBox.Text = AssignmentManagementClient.UsersOrganizer.GetUserById(assignment.Owner).Name;
            _id = assignment.Id;

            RemoveAssignmentButton.Enabled = true;
        }

        protected new void OkButton_Click(object sender, EventArgs e)
        {
            var assignment = new Assignment
            {
                Description = DescriptionRichTextBox.Text,
                ExpirationDate = ExpirationDateTimePicker.Value,
                Name = AssignmentNameBox.Text,
                Owner = AssignmentManagementClient.UsersOrganizer.GetUserByName(OwnerComboBox.Text).Id,
                Id = _id
            };

            AssignmentManagementClient.AssignmentOrganizer.Change(assignment);
            Close();
        }

        private void RemoveAssignmentButton_Click(object sender, EventArgs e)
        {
            AssignmentManagementClient.AssignmentOrganizer.Delete(new Assignment{Id = _id});
            Close();
        }
    }
}
