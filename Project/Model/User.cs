using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NicolZarankin_Project
{
    public enum PermissionLevel
    {
        Teen, // have permission only to foreign exchange
        Normal, // have permission to foreign exchange and stock
        Manager // have permission to everything including users
    }

    [DataContract]
    public class User : BaseEntity
    {
        protected string firstName;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        protected string lastName;
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        protected string email;
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        protected DateTime birthdate;
        [DataMember]
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        protected string gender;
        [DataMember]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        protected string phoneNumber;
        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        protected int permissionLevel;
        [DataMember]
        public int PermissionLevel
        {
            get { return permissionLevel; }
            set { permissionLevel = value; }
        }

        protected string password;
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }

    [CollectionDataContract]
    public class UserList : List<User>
    {
        public UserList() { } // default c'tor with empty list

        public UserList(IEnumerable<User> list) : base(list) { } // parse generic list to user list

        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to user list
    }
}
