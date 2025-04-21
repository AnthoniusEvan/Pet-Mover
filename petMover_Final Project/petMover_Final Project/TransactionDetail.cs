using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class TransactionDetail
    {
        #region Data Members
        int id;
        Branch branch;
        PetType petType;
        Cage cage;
        Treatment treatment;
        string description;
        int qty;
        int price;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public Branch Branch { get => branch; set => branch = value; }
        public PetType PetType { get => petType; set => petType = value; }
        public Cage Cage { get => cage; set => cage = value; }
        public Treatment Treatment { get => treatment; set => treatment = value; }
        public string Description { get => description; set => description = value; }
        public int Qty { get => qty; set => qty = value; }
        public int Price { get => price; set => price = value; }
        #endregion

        #region Constructors
        public TransactionDetail(int id, Branch branch, PetType petType, Cage cage, Treatment treatment, string description, int qty, int price)
        {
            Id = id;
            Branch = branch;
            PetType = petType;
            Cage = cage;
            Treatment = treatment;
            Description = description;
            Qty = qty;
            Price = price;
        }
        #endregion

        #region Methods
        public static List<TransactionDetail> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT td.Id, td.BranchId, td.TransactionId, td.PetTypeId, td.CageId, td.TreatmentId, td.Description, td.Qty, td.Price, b.Name, p.Name, c.Name, t.Name FROM transactiondetail td LEFT JOIN branch b ON td.BranchId = b.Id LEFT JOIN pettype p ON td.PetTypeId = p.Id LEFT JOIN cage c on td.CageId = c.Id LEFT JOIN treatment t ON td.TreatmentId = t.Id";
            if (searchCriteria == "")
            {
                sql += " WHERE " + searchCriteria + " like '%" + criteriaValue + "%'";
            }
            else if (searchCriteria == "Id")
            {
                string[] code = criteriaValue.Split();
                sql += " WHERE td.BranchId = '" + code[0] + "' AND td.TransactionId = '" + code[1] + "'";
            }

            List<TransactionDetail> list = new List<TransactionDetail>();

            using (dbConnection con = new dbConnection())
            {
                MySqlCommand com = new MySqlCommand(sql, con.DbCon);
                using (MySqlDataReader results = com.ExecuteReader())
                {

                    if (results.HasRows)
                    {
                        while (results.Read() == true)
                        {
                            PetType p = null;
                            Cage c = null;
                            Treatment t = null;
                            Branch b = new Branch(results.GetInt32(1), results.GetString(9));
                            if (!results.IsDBNull(3))
                                p = new PetType(results.GetInt32(3), results.GetString(10));
                            if (!results.IsDBNull(4))
                                c = new Cage(results.GetInt32(4), results.GetString(11));
                            if (!results.IsDBNull(5))
                                t = new Treatment(results.GetInt32(5), results.GetString(12));
                            TransactionDetail td = new TransactionDetail(results.GetInt32(0), b, p, c, t, results.GetString(6), results.GetInt32(7), results.GetInt32(8));
                            list.Add(td);
                        }
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
