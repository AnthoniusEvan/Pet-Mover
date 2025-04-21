using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class Staff
    {
        #region Data Members
        string id;
        string name;
        Branch branch;
        string password;
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Branch Branch { get => branch; set => branch = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region Constructors
        public Staff(string id)
        {
            Id = id;
        }
        public Staff(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public Staff(string id, string name, Branch branch)
        {
            Id = id;
            Name = name;
            Branch = branch;
        }
        public Staff(string id, string name, Branch branch, string password)
        {
            Id = id;
            Name = name;
            Branch = branch;
            Password = password;
        }
        #endregion

        #region Methods
        public static List<Staff> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT s.Id, s.Name, b.Id, b.Name FROM staff s INNER JOIN branch b ON s.BranchId = b.Id";
            if (searchCriteria == "any")
            {
                sql += " WHERE s.Id LIKE '%" + criteriaValue + "%' OR s.Name LIKE '%" + criteriaValue + "%' OR b.Name LIKE '%" + criteriaValue + "%'";
            }
            else if (searchCriteria == "Id")
            {
                sql += " WHERE s.Id = " + criteriaValue;
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<Staff> list = new List<Staff>();
            while (results.Read() == true)
            {
                Branch b = new Branch(results.GetInt32(2), results.GetString(3));
                Staff staff = new Staff(results.GetString(0), results.GetString(1), b);
                list.Add(staff);
            }
            return list;
        }
        public static Staff GetByCode(string categoryCode)
        {
            List<Staff> results = Staff.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(Staff newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO staff(Id, Name, BranchId,`Password`) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "','" + newRecord.Branch.Id + "', SHA2('" + newRecord.Password + "',512))";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(Staff editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE staff SET Name = '" + editRecord.Name + "', BranchId = '" + editRecord.Branch.Id + "'";

            if (editRecord.Password != null && editRecord.Password != "")
            {
                sql += ", Password = SHA2('" + editRecord.Password + "',512)";
            }
            sql += " WHERE Id = '" + editRecord.Id + "'";
            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(Staff deleteRecord)
        {
            string sql = "DELETE FROM staff WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static Staff ValidateLogin(string username, string password)
        {
            string sql = "SELECT s.Id, s.Name, s.Password, b.Id, b.Name FROM staff s INNER JOIN branch b ON s.BranchId = b.Id WHERE s.Name ='" + username + "' AND s.Password = SHA2('" + password + "',512)";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);

            if (results.Read())
            {
                Branch b = new Branch(results.GetInt32(3),results.GetString(4));

                Staff s = new Staff(results.GetString(0), results.GetString(1), b);
                return s;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
