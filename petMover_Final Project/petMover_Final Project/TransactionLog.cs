using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
namespace petMover_Final_Project
{
    public class TransactionLog
    {
        #region Data Members
        DateTime logTime;
        Branch branch;
        int id;
        City city;
        string description;
        Staff staff;
        #endregion

        #region Properties
        public DateTime LogTime { get => logTime; set => logTime = value; }
        public Branch Branch { get => branch; set => branch = value; }
        public int Id { get => id; set => id = value; }
        public City City { get => city; set => city = value; }
        public string Description { get => description; set => description = value; }
        public Staff Staff { get => staff; set => staff = value; }
        #endregion

        #region Constructors
        public TransactionLog(DateTime logTime, Branch branch, int id, City city, string description, Staff staff)
        {
            LogTime = logTime;
            Branch = branch;
            Id = id;
            City = city;
            Description = description;
            Staff = staff;
        }
        #endregion

        #region Methods
        public static List<TransactionLog> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT t.LogTime, t.TransactionBranchId, b.Name, t.TransactionId, t.CityId, c.Name, t.Description, t.StaffId, s.Name FROM transactionlog t INNER JOIN branch b ON t.TransactionBranchId = b.Id INNER JOIN city c ON t.CityId = c.Id INNER JOIN staff s ON t.StaffId = s.Id";
            if (searchCriteria == "any")
            {
                string[] code = criteriaValue.Split();
                sql += " WHERE t.TransactionBranchId = '" + code[0] + "' AND t.TransactionId = '" + code[1] + "'";
            }
            else if (searchCriteria == "Id")
            {
                sql += " WHERE t.LogTime = '" + criteriaValue + "'";
            }
            else if (searchCriteria == "search")
            {
                string[] code = criteriaValue.Split();
                sql += " WHERE t.TransactionBranchId = '" + code[0] + "' AND t.TransactionId = '" + code[1] + "' AND (t.LogTime LIKE '%" + code[2] + "%' OR c.Name LIKE '%" + code[2] + "%' OR s.Name LIKE '%" + code[2] + "%' OR t.Description LIKE '%" + code[2] + "%')" ;
            }

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);

            List<TransactionLog> list = new List<TransactionLog>();
            while (results.Read() == true)
            {
                Branch b = new Branch(results.GetInt32(1), results.GetString(2));
                City c = new City(results.GetInt32(4), results.GetString(5));
                Staff s = new Staff(results.GetString(7), results.GetString(8));

                TransactionLog tl = new TransactionLog(results.GetDateTime(0), b, results.GetInt32(3), c, results.GetString(6), s);
                list.Add(tl);
            }
            return list;
        }
        public static int Add(TransactionLog newRecord)
        {
            string sql = string.Format("INSERT INTO transactionlog(LogTime, TransactionBranchId, TransactionId, CityId, Description, StaffId) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", newRecord.LogTime.ToString("yyyy-MM-dd HH:mm:ss"), newRecord.Branch.Id, newRecord.Id, newRecord.City.Id, newRecord.Description, newRecord.Staff.Id);

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(TransactionLog editRecord)
        {
            string sql = "UPDATE transactionlog SET CityId = '" + editRecord.City.Id + "', Description = '" + editRecord.Description + "', StaffId = '" + editRecord.Staff.Id + "' WHERE LogTime = '" + editRecord.LogTime.ToString("yyyy-MM-dd HH:mm:ss")+ "' AND TransactionBranchId = '" + editRecord.Branch.Id + "' AND TransactionId = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
