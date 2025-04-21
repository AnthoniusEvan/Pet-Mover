using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;

namespace petMover_Final_Project
{
    public class Cage
    {
        #region Data Members
        private int id;
        private string name;
        private string dimensions;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Dimensions { get => dimensions; set => dimensions = value; }
        #endregion

        #region Constructors
        public Cage(int id)
        {
            Id = id;
        }
        public Cage(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Cage(int id, string name, string dimensions)
        {
            Id = id;
            Name = name;
            Dimensions = dimensions;
        }
        #endregion

        #region Methods
        public static List<Cage> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "";
            if (searchCriteria == "")
            {
                sql = "SELECT * FROM cage";
            }
            else if (searchCriteria == "any")
            {
                sql = "SELECT * FROM cage WHERE Id = '" + criteriaValue + "' OR Name LIKE '%" + criteriaValue + "%' OR Dimensions LIKE '%" + criteriaValue + "%'"; 
            }
            else
            {
                sql = "SELECT * FROM cage WHERE " + searchCriteria + " LIKE '%" + criteriaValue + "%'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<Cage> list = new List<Cage>();
            while (results.Read() == true)
            {
                Cage cage = new Cage(results.GetInt32(0), results.GetString(1), results.GetString(2));
                list.Add(cage);
            }
            return list;
        }
        public static Cage GetByCode(string categoryCode)
        {
            List<Cage> results = Cage.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(Cage newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO cage(Id, Name, Dimensions) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "','" + newRecord.Dimensions + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(Cage editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE cage SET Name = '" + editRecord.Name + "', Dimensions = '" + editRecord.Dimensions + "' WHERE Id = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(Cage deleteRecord)
        {
            string sql = "DELETE FROM cage WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
