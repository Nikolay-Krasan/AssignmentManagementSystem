using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace CommonCode
{
    [Serializable]
    //[XmlRoot("User")]
    [XmlType(TypeName = "User")]
    [XmlInclude(typeof(Admin))]
    public class User : BaseObject
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

        public void CreateNewPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                _password = Convert.ToBase64String(hash);
            }
        }

        public void CreateAssignment()
        {
            
        }

        public List<Assignment> GetAssignments()
        {
            AssignmentManagementClient.
        }
    }
}
