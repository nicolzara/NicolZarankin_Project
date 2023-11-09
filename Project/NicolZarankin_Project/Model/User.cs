using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolZarankin_Project.Model
{
    public enum PermissionLevel
    {
        Teen, // have permission only to foreign exchange
        Normal, // have permission to foreign exchange and stock
        Manager // have permission to everything including users
    }
    public class User : BaseEntity
    {
        protected string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        protected string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        protected string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        protected DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        protected string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        protected string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        protected int permissionLevel;
        public int PermissionLevel
        {
            get { return permissionLevel; }
            set { permissionLevel = value; }
        }

        protected string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }

    public class UserList : List<User>
    {
        public UserList() { } // default c'tor with empty list

        public UserList(IEnumerable<User> list) : base(list) { } // parse generic list to user list

        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to user list
    }
}
