using System;
using System.Xml.Serialization;

namespace AssignmentManagementClient
{
    [Serializable]
    public class Assignment : Object
    {
        [XmlElement("Id")]
        public Guid Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Task")]
        public string Task { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Owner")]
        public Guid Owner { get; set; }

        [XmlElement("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}
