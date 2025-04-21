using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class CageRate
    {
        #region Data Members
        Cage cage;
        ServiceType serviceType;
        int rate;
        #endregion

        #region Properties
        public Cage Cage { get => cage; set => cage = value; }
        public ServiceType ServiceType { get => serviceType; set => serviceType = value; }
        public int Rate { get => rate; set => rate = value; }
        #endregion

        #region Constructors
        public CageRate(Cage cage, ServiceType serviceType, int rate)
        {
            Cage = cage;
            ServiceType = serviceType;
            Rate = rate;
        }
        #endregion

        #region Methods
        public static List<CageRate> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT cr.CageId, cr.ServiceTypeId, cr.Rate, ca.Name, s.Name FROM cagerate cr INNER JOIN cage ca ON cr.CageId = ca.Id INNER JOIN servicetype s ON cr.ServiceTypeId = s.Id";
            if (searchCriteria == "any")
            {
                sql += " WHERE ca.Name LIKE '%" + criteriaValue + "%' OR s.Name LIKE '%" + criteriaValue + "%' OR cr.Rate LIKE '%" + criteriaValue + "%'";
            }
            else if (searchCriteria == "Id")
            {
                string[] code = criteriaValue.Split(';');
                sql += " WHERE cr.CageId = '" + code[0] + "' AND cr.ServiceTypeId = '" + code[1] + "'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<CageRate> list = new List<CageRate>();
            while (results.Read() == true)
            {
                Cage cage = new Cage(results.GetInt32(0),results.GetString(3));
                ServiceType serviceType = new ServiceType(results.GetInt32(1), results.GetString(4));
                CageRate cageRate = new CageRate(cage, serviceType, results.GetInt32(2));
                list.Add(cageRate);
            }
            return list;
        }
        public static CageRate GetByCode(string categoryCode)
        {
            List<CageRate> results = CageRate.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(CageRate newRecord)
        {
            //newRecord.Rate = newRecord.Rate.Replace("'", "\\");
            string sql = "INSERT INTO cagerate(CageId, ServiceTypeId, Rate) VALUES ('" + newRecord.Cage.Id + "','" + newRecord.ServiceType.Id + "','" + newRecord.Rate + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(CageRate editRecord)
        {
            //editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE cagerate SET Rate = '" + editRecord.Rate + "' WHERE CageId = '" + editRecord.Cage.Id + "' AND ServiceTypeId = '" + editRecord.ServiceType.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(CageRate deleteRecord)
        {
            string sql = "DELETE FROM cagerate WHERE CageId = '" + deleteRecord.Cage.Id + "' AND ServiceTypeId = '"+deleteRecord.ServiceType.Id+"';";

            return dbConnection.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
