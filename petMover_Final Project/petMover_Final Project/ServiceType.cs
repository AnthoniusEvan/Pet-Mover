using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class ServiceType
    {
        #region Data Members
        private int id;
        private string name;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region Constructors
        public ServiceType(int id)
        {
            Id = id;
        }
        public ServiceType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        public static List<ServiceType> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "";
            if (searchCriteria == "")
            {
                sql = "SELECT * FROM servicetype";
            }
            else if (searchCriteria == "any")
            {
                sql = "SELECT * FROM servicetype WHERE Id = '" + criteriaValue + "' OR Name LIKE '%" + criteriaValue + "%'";
            }
            else
            {
                sql = "SELECT * FROM servicetype WHERE " + searchCriteria + " LIKE '%" + criteriaValue + "%'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<ServiceType> list = new List<ServiceType>();
            while (results.Read() == true)
            {
                ServiceType servicetype = new ServiceType(results.GetInt32(0), results.GetString(1));
                list.Add(servicetype);
            }
            return list;
        }
        public static ServiceType GetByCode(string categoryCode)
        {
            List<ServiceType> results = ServiceType.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(ServiceType newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO servicetype(Id, Name) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(ServiceType editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE servicetype SET Name = '" + editRecord.Name + "' WHERE Id = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(ServiceType deleteRecord)
        {
            string sql = "DELETE FROM servicetype WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
