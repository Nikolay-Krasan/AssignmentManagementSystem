using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using CommonCode.Requests;

namespace CommonCode
{
    public class UsersOrganizer
    {
        private List<User> _allUsers;
        private readonly XmlSerializer _usersSerializer;

        [XmlArray("ArrayOfUser")]
        [XmlArrayItem("User", typeof(User))]
        [XmlArrayItem("Admin", typeof(Admin))]
        public List<User> AllUsers
        {
            get { return _allUsers; }
            set { _allUsers = value; }
        }
 
        public UsersOrganizer()
        {
            _allUsers = new List<User>();
            _usersSerializer = new XmlSerializer(typeof (List<User>));

            GetAllUsers();
        }

        public void Add(User user)
        {
            if (AllUsers.Any(u => u.Name == user.Name))
            {
                throw new InvalidOperationException("UserName is already used");
            }
            
            AllUsers.Add(user);
            Serialize();
            GetAllUsers();
        }

        public void Delete(User user)
        {
            var userForDeletion = _allUsers.Find(u => u.Id == user.Id);
            _allUsers.Remove(userForDeletion);
            Serialize();
            GetAllUsers();
        }

        public void Change(User user)
        {
            var userToChange = _allUsers.Find(u => u.Id == user.Id);
            if (AllUsers.Any(u => u.Name == user.Name))
            {
                throw new InvalidOperationException("UserName is already used");
            }
            _allUsers.Remove(userToChange);
            _allUsers.Add(user);
            Serialize();
            GetAllUsers();
        }

        public User LogIn(User user)
        {
            GetAllUsers();
            var loggedUser = _allUsers.Find(u => u.Password == user.Password && u.Name == user.Name);
            if (loggedUser == null)
            {
                throw new InvalidOperationException("UserName or password is incorrect");
            }

            return loggedUser;
        }

        public User GetUser(User user)
        {
            GetAllUsers();
            var userForEdition = _allUsers.Find(u => u.Name == user.Name);
            if (userForEdition == null)
            {
                throw new InvalidOperationException("Can't find such user");
            }

            return userForEdition;
        }

        public void GetAllUsers()
        {
            if (!File.Exists("Users.xml"))
            {
                return;
            }

            using (var stream = File.OpenRead("Users.xml"))
            {
                var usersFromXml = (List<User>)_usersSerializer.Deserialize(stream);

                _allUsers.Clear();
                foreach (var user in usersFromXml)
                {
                    _allUsers.Add(user);
                }
            }
        }

        private void Serialize()
        {
            var streamWriter = new StreamWriter("Users.xml");
            _usersSerializer.Serialize(streamWriter, AllUsers);
            streamWriter.Close();
        }
    }
}