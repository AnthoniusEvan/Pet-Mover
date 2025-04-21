using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class Client
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
        public Client(int id, string name, string address, string phoneNumber, City city)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            City = city;
        }
        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Client(int id)
        {
            Id = id;
        }
        #endregion

        #region Methods
        public static List<Client> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT cl.Id, cl.Name, cl.Address, cl.PhoneNumber, c.Id, c.Name FROM client cl INNER JOIN city c ON cl.CityId = c.Id";
            if (searchCriteria == "any")
            {
                sql += " WHERE cl.Id LIKE '%" + criteriaValue + "%' OR cl.Name LIKE '%" + criteriaValue + "%' OR cl.Address LIKE '%" + criteriaValue + "%' OR cl.PhoneNumber LIKE '%" + criteriaValue + "%' OR c.Id LIKE '%" + criteriaValue + "%' OR c.Name LIKE '%" + criteriaValue + "%'";
            }
            else if (searchCriteria == "Id")
            {
                sql += " WHERE cl.Id = '" + criteriaValue + "'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<Client> list = new List<Client>();
            while (results.Read() == true) 
            {
                City c = new City(results.GetInt32(4), results.GetString(5));
                Client client = new Client(results.GetInt32(0), results.GetString(1), results.GetString(2), results.GetString(3), c);
                list.Add(client);
            }
            return list;
        }
        public static Client GetByCode(string categoryCode)
        {
            List<Client> results = Client.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(Client newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO client(Id, Name, Address, PhoneNumber, CityId) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "','" + newRecord.Address + "','" + newRecord.PhoneNumber + "','" + newRecord.City.Id + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(Client editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE client SET Name = '" + editRecord.Name + "', Address = '" + editRecord.Address + "', PhoneNumber = '" + editRecord.PhoneNumber + "', CityId = '" + editRecord.City.Id + "' WHERE Id = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(Client deleteRecord)
        {
            string sql = "DELETE FROM client WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
