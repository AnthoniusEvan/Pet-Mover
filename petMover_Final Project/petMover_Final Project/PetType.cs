using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class PetType
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
        public PetType(int id)
        {
            Id = id;
        }
        public PetType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        public static List<PetType> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "";
            if (searchCriteria == "")
            {
                sql = "SELECT * FROM pettype";
            }
            else if (searchCriteria == "any")
            {
                sql = "SELECT * FROM pettype WHERE Id = '"+criteriaValue+"' OR Name LIKE '%" + criteriaValue + "%'";
            }
            else
            {
                sql = "SELECT * FROM pettype WHERE " + searchCriteria + " LIKE '%" + criteriaValue + "%'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<PetType> list = new List<PetType>();
            while (results.Read() == true)
            {
                PetType pettype = new PetType(results.GetInt32(0), results.GetString(1));
                list.Add(pettype);
            }
            return list;
        }
        public static PetType GetByCode(string categoryCode)
        {
            List<PetType> results = PetType.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(PetType newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO pettype(Id, Name) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(PetType editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE pettype SET Name = '" + editRecord.Name + "' WHERE Id = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(PetType deleteRecord)
        {
            string sql = "DELETE FROM pettype WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
