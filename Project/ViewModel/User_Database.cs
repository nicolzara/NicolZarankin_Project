﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
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
            user.UserName = reader["UserName"].ToString();
            user.Email = reader["Email"].ToString();
            user.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
            user.PhoneNumber = reader["PhoneNumber"].ToString();
            user.PermissionLevel = int.Parse(reader["PermissionLevel"].ToString());
            user.Password = reader["Password"].ToString();
            user.FreeBalance = double.Parse(reader["FreeBalance"].ToString());

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
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@FirstName", user.UserName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Birthdate", user.Birthdate);           
            command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            command.Parameters.AddWithValue("@PermissionLevel", user.PermissionLevel);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@FreeBalance", user.FreeBalance);
        }

        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO User_Table (UserName, Email, Birthdate, PhoneNumber, PermissionLevel, Password, FreeBalance) VALUES (@UserName, @Email, @Birthdate, @PhoneNumber, @PermissionLevel, @Password, @FreeBalance)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE User_Table SET UserName = @UserName, Email = @Email, Birthdate = @Birthdate, PhoneNumber = @PhoneNumber, PermissionLevel = @PermissionLevel, Password = @Password, FreeBalance=@FreeBalance WHERE Id = @Id";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user)
        {
            command.CommandText = "DELETE FROM User_Table WHERE Id = @Id";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public bool Login(string username, string password)
        {
            command.CommandText = "SELECT * FROM User_Table WHERE Username=" + username + "AND [Password]=" + password;
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
