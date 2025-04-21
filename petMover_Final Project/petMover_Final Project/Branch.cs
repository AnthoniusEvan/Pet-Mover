using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class Branch
    {
        #region Data Members
        int id;
        string name;
        string address;
        string phoneNumber;
        City city;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public City City { get => city; set => city = value; }
        #endregion

        #region Constructors
        public Branch(int id)
        {
            Id = id;
        }
        public Branch(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Branch(int id, string name, string address, City city)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
        }
        public Branch(int id, string name, string address, string phoneNumber, City city)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            City = city;
        }
        #endregion

        #region Methods
        public static List<Branch> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT b.Id, b.Name, b.Address, b.PhoneNumber, c.Id, c.Name FROM branch b INNER JOIN city c ON b.CityId = c.Id";
            if (searchCriteria == "any")
            {
                sql += " WHERE b.Id LIKE '%" + criteriaValue + "%' OR b.Name LIKE '%" + criteriaValue + "%' OR b.Address LIKE '%" + criteriaValue + "%' OR b.PhoneNumber LIKE '%" + criteriaValue + "%' OR c.Id LIKE '%" + criteriaValue + "%' OR c.Name LIKE '%" + criteriaValue + "%'";
            }
            else if (searchCriteria == "Id")
            {
                sql += " WHERE b.Id = " + criteriaValue;
            }
            else if (searchCriteria == "Name")
            {
                sql += " WHERE b.Name = '" + criteriaValue + "'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<Branch> list = new List<Branch>();
            while (results.Read() == true)
            {
                City c = new City(results.GetInt32(4), results.GetString(5));
                Branch branch = new Branch(results.GetInt32(0), results.GetString(1), results.GetString(2), results.GetString(3), c);
                list.Add(branch);
            }
            return list;
        }
        public static Branch GetByCode(string categoryCode)
        {
            List<Branch> results = Branch.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(Branch newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO branch(Id, Name, Address, PhoneNumber, CityId) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "','" + newRecord.Address + "','" + newRecord.PhoneNumber + "','" + newRecord.City.Id + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(Branch editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE branch SET Name = '" + editRecord.Name + "', Address = '" + editRecord.Address + "', PhoneNumber = '" + editRecord.PhoneNumber + "', CityId = '" + editRecord.City.Id + "' WHERE Id = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(Branch deleteRecord)
        {
            string sql = "DELETE FROM branch WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
