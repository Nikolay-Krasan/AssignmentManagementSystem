using System;
using System.Windows.Forms;

namespace AssignmentManagementClient
{
    static class AssignmentManagementClient
    {
        public static User CurrentUser;
        public static readonly UsersOrganizer UsersOrganizer = new UsersOrganizer();
        public static readonly AssignmentOrganizer AssignmentOrganizer = new AssignmentOrganizer();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
