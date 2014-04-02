using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CommonCode
{
    public class AssignmentOrganizer : OrganizerBase
    {
        private const string XmlFilePath = @"Assignment.xml";
        private readonly XmlSerializer _assignmentSerializer;

        public AssignmentOrganizer()
        {
            AllAssignments = new List<Assignment>();
            _assignmentSerializer = new XmlSerializer(typeof(List<Assignment>));

            GetAllAssignments();
        }

        public List<Assignment> AllAssignments { get; set; }

        public void Add(Assignment assignment)
        {
            AllAssignments.Add(assignment);
            Serialize();
            GetAllAssignments();
        }

        public List<Assignment> GetAllAssignmentsForAssignment(Guid ownerGuid)
        {
            return AllAssignments.Where(a => a.Owner == ownerGuid).ToList();
        }

        public void GetAllAssignments()
        {
            if (!File.Exists(XmlFilePath))
            {
                return;
            }

            using (var stream = File.OpenRead(XmlFilePath))
            {
                var assignmentsFromXml = (List<Assignment>)_assignmentSerializer.Deserialize(stream);

                AllAssignments.Clear();
                foreach (var assignment in assignmentsFromXml)
                {
                    AllAssignments.Add(assignment);
                }
            }
        }

        public void Delete(Assignment assignment)
        {
            var assignmentForDeletion = AllAssignments.Find(a => a.Id == assignment.Id);
            AllAssignments.Remove(assignmentForDeletion);
            Serialize();
            GetAllAssignments();
        }

        public void Change(Assignment assignment)
        {
            var assignmentToChange = AllAssignments.Find(u => u.Id == assignment.Id);
            if (AllAssignments.Any(u => u.Name == assignment.Name))
            {
                throw new InvalidOperationException("AssignmentName is already used");
            }
            AllAssignments.Remove(assignmentToChange);
            AllAssignments.Add(assignment);
            Serialize();
            GetAllAssignments();
        }

        private void Serialize()
        {
            var streamWriter = new StreamWriter(XmlFilePath);
            _assignmentSerializer.Serialize(streamWriter, AllAssignments);
            streamWriter.Close();
        }
    }
}
