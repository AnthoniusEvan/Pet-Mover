using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class Treatment
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
        public Treatment(int id)
        {
            Id = id;
        }
        public Treatment(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        public static List<Treatment> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "";
            if (searchCriteria == "")
            {
                sql = "SELECT * FROM treatment";
            }
            else if (searchCriteria == "any")
            {
                sql = "SELECT * FROM treatment WHERE Id = '" + criteriaValue + "' OR Name LIKE '%" + criteriaValue + "%'";
            }
            else
            {
                sql = "SELECT * FROM treatment WHERE " + searchCriteria + " LIKE '%" + criteriaValue + "%'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<Treatment> list = new List<Treatment>();
            while (results.Read() == true)
            {
                Treatment treatment = new Treatment(results.GetInt32(0), results.GetString(1));
                list.Add(treatment);
            }
            return list;
        }
        public static Treatment GetByCode(string categoryCode)
        {
            List<Treatment> results = Treatment.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(Treatment newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO treatment(Id, Name) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(Treatment editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE treatment SET Name = '" + editRecord.Name + "' WHERE Id = '" + editRecord.Id+"'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(Treatment deleteRecord)
        {
            string sql = "DELETE FROM treatment WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
