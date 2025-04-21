using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;

namespace petMover_Final_Project
{
    public class TreatmentRate
    {
        #region Data Members
        Treatment treatment;
        PetType petType;
        int dailyRate;
        #endregion

        #region Properties
        public Treatment Treatment { get => treatment; set => treatment = value; }
        public PetType PetType { get => petType; set => petType = value; }
        public int DailyRate { get => dailyRate; set => dailyRate = value; }
        #endregion

        #region Constructors
        public TreatmentRate(Treatment treatment, PetType petType, int dailyRate)
        {
            Treatment = treatment;
            PetType = petType;
            DailyRate = dailyRate;
        }
        #endregion

        #region Methods
        public static List<TreatmentRate> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT tr.TreatmentId, tr.PetTypeId, tr.DailyRate, t.Name, p.Name FROM treatmentrate tr INNER JOIN treatment t ON tr.TreatmentId = t.Id INNER JOIN pettype p ON tr.PetTypeId = p.Id ";
            if (searchCriteria == "any")
            {
                sql += "WHERE t.Name LIKE '%" + criteriaValue + "%' OR p.Name LIKE '%" + criteriaValue + "%'";
            }
            else if(searchCriteria == "Id")
            {
                string[] code = criteriaValue.Split();
                sql += "WHERE tr.TreatmentId = '" + code[0] + "' AND tr.PetTypeId = '" + code[1] + "'";
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<TreatmentRate> list = new List<TreatmentRate>();
            while (results.Read() == true)
            {
                Treatment t = new Treatment(results.GetInt32(0), results.GetString(3));
                PetType p = new PetType(results.GetInt32(1), results.GetString(4));
                TreatmentRate tr = new TreatmentRate(t,p,results.GetInt32(2));
                list.Add(tr);
            }
            return list;
        }
        public static TreatmentRate GetByCode(string categoryCode)
        {
            List<TreatmentRate> results = TreatmentRate.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(TreatmentRate newRecord)
        {
            //newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO treatmentrate(TreatmentId, PetTypeId, DailyRate) VALUES ('" + newRecord.Treatment.Id + "','" + newRecord.PetType.Id + "','" + newRecord.DailyRate + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(TreatmentRate editRecord)
        {
            //editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE treatmentrate SET DailyRate = '" + editRecord.DailyRate + "' WHERE TreatmentId = '" + editRecord.Treatment.Id + "' AND PetTypeId = '" + editRecord.PetType.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(TreatmentRate deleteRecord)
        {
            string sql = "DELETE FROM treatmentrate WHERE TreatmentId = '" + deleteRecord.Treatment.Id + "' AND PetTypeId = '" + deleteRecord.PetType.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return PetType.Name + " " + Treatment.Name;
        }
        #endregion

    }
}
