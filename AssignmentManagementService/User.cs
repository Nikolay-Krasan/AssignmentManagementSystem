using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace AssignmentManagementClient
{
    [Serializable]
    [XmlType(TypeName = "User")]
    [XmlInclude(typeof(Admin))]
    public class User
    {
        private string _password;

        [XmlElement("PhoneNumber")]
        public string PhoneNumber;

        [XmlElement("Post")]
        public string Post;

        [XmlElement("Address")]
        public string Address;

        [XmlElement("Name")]
        public string Name;

        [XmlElement("Password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [XmlElement("Id")]
        public Guid Id;

        public void CreateNewPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                _password = Convert.ToBase64String(hash);
            }
        }

        public virtual List<Assignment> GetAssignments()
        {
            return AssignmentManagementClient.AssignmentOrganizer.GetAllAssignmentsForUser(Id);
        }

        public virtual void CreateAssignment()
        {
            var userList = new List<User> {AssignmentManagementClient.CurrentUser};
            var assignmentForm = new AssignmentForm(userList);
            assignmentForm.Show();
        }
    }
}
