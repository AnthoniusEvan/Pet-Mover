using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class TransportRate
    {
        #region Data Members
        City cityOrigin;
        City cityDestination;
        ServiceType serviceType;
        int rate;
        #endregion

        #region Properties
        public City CityOrigin { get => cityOrigin; set => cityOrigin = value; }
        public City CityDestination { get => cityDestination; set => cityDestination = value; }
        public ServiceType ServiceType { get => serviceType; set => serviceType = value; }
        public int Rate { get => rate; set => rate = value; }
        #endregion

        #region Constructors
        public TransportRate(City origin, City destination, ServiceType service, int rate)
        {
            CityOrigin = origin;
            CityDestination = destination;
            ServiceType = service;
            Rate = rate;
        }
        #endregion

        #region Methods
        public static List<TransportRate> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT t.CityOrigin, t.CityDestination, t.ServiceType, t.Rate, co.Name, cd.Name, s.Name FROM transportrate t INNER JOIN city co ON t.CityOrigin = co.Id INNER JOIN city cd ON t.CityDestination = cd.Id INNER JOIN servicetype s ON t.ServiceType = s.Id";
            if (searchCriteria == "any")
            {
                sql += " WHERE co.Name LIKE '%" + criteriaValue + "%' OR cd.Name LIKE '%" + criteriaValue + "%' OR s.Name LIKE '%" + criteriaValue + "%' OR t.Rate LIKE '%" + criteriaValue + "%'";
            }
            else if (searchCriteria == "Id")
            {
                string[] code = criteriaValue.Split();
                sql += " WHERE t.CityOrigin = '" + code[0] + "' AND t.CityDestination = '" + code[1] + "' AND t.ServiceType = '" + code[2] + "'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<TransportRate> list = new List<TransportRate>();
            if (results.HasRows)
            {
                while (results.Read() == true)
                {
                    City co = new City(results.GetInt32(0), results.GetString(4));
                    City cd = new City(results.GetInt32(1), results.GetString(5));
                    ServiceType s = new ServiceType(results.GetInt32(2), results.GetString(6));
                    TransportRate transportRate = new TransportRate(co, cd, s, results.GetInt32(3));
                    list.Add(transportRate);
                }
            }
            return list;
        }
        public static TransportRate GetByCode(string categoryCode)
        {
            List<TransportRate> results = TransportRate.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(TransportRate newRecord)
        {
            ///newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO transportrate(CityOrigin, CityDestination, ServiceType, Rate) VALUES ('" + newRecord.CityOrigin.Id + "','" + newRecord.CityDestination.Id + "','" + newRecord.ServiceType.Id + "','" + newRecord.Rate  + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(TransportRate editRecord)
        {
            //editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE transportrate SET Rate = '" + editRecord.Rate + "' WHERE CityOrigin = '" + editRecord.CityOrigin.Id + "' AND CityDestination = '" + editRecord.CityDestination.Id + "' AND ServiceType = '" + editRecord.ServiceType.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(TransportRate deleteRecord)
        {
            string sql = "DELETE FROM transportrate WHERE CityOrigin = '" + deleteRecord.CityOrigin.Id + "' AND CityDestination = '" + deleteRecord.CityDestination.Id + "' AND ServiceType = '" + deleteRecord.ServiceType.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        #endregion
    }
}
