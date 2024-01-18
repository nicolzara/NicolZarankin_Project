using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public abstract class Base_Database
    {
        protected static string connectionString;
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected abstract BaseEntity NewEntity();
        protected abstract void LoadParameters(BaseEntity entity);
        public int ExecuteCRUD() //����� ������ ������� ��� ����
        {
            int records = 0;
            try
            {
                connection.Open(); //����� ������ �� ����
                records = command.ExecuteNonQuery(); //����� �������                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return records;
        }
        protected abstract BaseEntity CreateModel(BaseEntity entity);
        public Base_Database()
        {
            if (connectionString == null)
            {
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    Path() + @"\Database.accdb;Persist Security Info=True";
            }

            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public List<BaseEntity> ExecuteCommand() //����� ������ ������� ��� ����
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                connection.Open(); //����� ������ �� ����
                reader = command.ExecuteReader(); //����� �������
                while (reader.Read()) //���� �� �� �������
                {
                    BaseEntity entity = NewEntity(); //����� ��� ��� ����� ����� ������
                    list.Add(CreateModel(entity)); //����� ���� ������� �������
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return list;
        }
        private static string Path()
        {
            string s = Environment.CurrentDirectory; //������ ��� �� �������
            string[] sub = s.Split('\\'); //����� ������ ������ ����� ��� ������

            int index = sub.Length - 3; //���� ����� 2 ������
            sub[index] = "ViewModel";     //����� ������ ������ �������
            Array.Resize(ref sub, index + 1); //����� �� ���� �����, ����� ������ �������

            s = String.Join("\\", sub);  //����� ���� �� ����� �� / ����� ���� 
            return s;
        }
    }
}