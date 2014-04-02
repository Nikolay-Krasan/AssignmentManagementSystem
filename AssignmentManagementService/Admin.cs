using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AssignmentManagementClient
{
    [Serializable]
    [XmlType(TypeName = "Admin")]
    public class Admin : User
    {
        public void EditUser(User user)
        {
        }

        public override List<Assignment> GetAssignments()
        {
            return AssignmentManagementClient.AssignmentOrganizer.AllAssignments;
        }

        public List<Assignment> GetAssignmentForUser(string name)
        {
            return AssignmentManagementClient.AssignmentOrganizer.GetAllAssignmentsForUser(Guid.NewGuid());
        }

        public override void CreateAssignment()
        {
            var userList = AssignmentManagementClient.UsersOrganizer.AllUsers;
            var assignmentForm = new AssignmentForm(userList);
            assignmentForm.Show();
        }
    }
}
