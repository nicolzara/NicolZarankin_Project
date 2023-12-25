using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User
    {
        public string userName { get; set; }        
        public string email { get; set; }
        public string birthdate { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }

        public int permissionLevel {  get; set; }

        /// <summary>
        /// the function returns if the object is totally empty
        /// </summary>
        /// <returns>if the object is totally empty</returns>
        public bool isEmpty()
        {
            return (string.IsNullOrEmpty(this.userName) || string.IsNullOrEmpty(this.password) || string.IsNullOrEmpty(this.email) || string.IsNullOrEmpty(this.phoneNumber) || string.IsNullOrEmpty(this.birthdate));
        }
    }
}
