using NicolZarankin_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolZarankin_Project.ViewModel
{
    public class User_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;

            user.Id = int.Parse(reader["Id"].ToString());
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.Email = reader["Email"].ToString();
            user.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
            user.Gender = reader["Gender"].ToString();
            user.PhoneNumber = reader["PhoneNumber"].ToString();
            user.PermissionLevel = int.Parse(reader["PermissionLevel"].ToString());
            user.Password = reader["Password"].ToString();

            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM User_Table";
            UserList userList = new UserList(ExecuteCommand());
            return userList;
        }

        public User SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM User_Table WHERE Id=" + Id;
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return null;
            }

            return userList[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", user.Id);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Birthdate", user.Birthdate);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            command.Parameters.AddWithValue("@PermissionLevel", user.PermissionLevel);
            command.Parameters.AddWithValue("@Password", user.Password);
        }

        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO User_Table (FirstName, LastName, Email, Birthdate, Gender, PhoneNumber, PermissionLevel, Password) VALUES (@FirstName, @LastName, @Email, @Birthdate, @Gender, @PhoneNumber, @PermissionLevel, @Password)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE User_Table SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Birthdate = @Birthdate, Gender = @Gender, PhoneNumber = @PhoneNumber, PermissionLevel = @PermissionLevel, Password = @Password WHERE Id = @Id";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user)
        {
            command.CommandText = "DELETE FROM User_Table WHERE Id = @Id";
            LoadParameters(user);
            return ExecuteCRUD();
        }
    }
}
