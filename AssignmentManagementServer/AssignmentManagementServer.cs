using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonCode;

namespace AssignmentManagementServer
{
    class AssignmentManagementServer
    {
        private static readonly AssignmentOrganizer _assignmentOrganizer = new AssignmentOrganizer();
        private static readonly UsersOrganizer _usersOrganizer = new UsersOrganizer();

        static void Main()
        {
            Console.WriteLine("Starting Assignment Management Server");

            var clientInteractor = new ClientInteractor(_assignmentOrganizer, _usersOrganizer);
            clientInteractor.HandleRequests();
        }
    }
}
