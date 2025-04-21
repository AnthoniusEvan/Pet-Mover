using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using System.Transactions;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class Transaction
    {
        #region Data Members
        Branch branch;
        int id;
        DateTime transactionDate;
        Client client;
        Staff createdBy;
        ServiceType service;
        string destinationAddress;
        City destinationCity;
        DateTime expectedArrival;
        List<TransactionDetail> details;
        #endregion

        #region Properties
        public Branch Branch { get => branch; set => branch = value; }
        public int Id { get => id; set => id = value; }
        public DateTime TransactionDate { get => transactionDate; set => transactionDate = value; }
        public Client Client { get => client; set => client = value; }
        public Staff CreatedBy { get => createdBy; set => createdBy = value; }
        public ServiceType Service { get => service; set => service = value; }
        public string DestinationAddress { get => destinationAddress; set => destinationAddress = value; }
        public City DestinationCity { get => destinationCity; set => destinationCity = value; }
        public DateTime ExpectedArrival { get => expectedArrival; set => expectedArrival = value; }
        internal List<TransactionDetail> Details { get => details; set => details = value; }
        #endregion

        #region Constructors
        public Transaction(Branch branch, int id)
        {
            Branch = branch;
            Id = id;
            Details = new List<TransactionDetail>();
        }
        public Transaction(Branch branch, int id, DateTime transactionDate, Client client, Staff staff, ServiceType service, string address, City city, DateTime expectedArrival)
        {
            Branch = branch;
            Id = id;
            TransactionDate = transactionDate;
            Client = client;
            CreatedBy = staff;
            Service = service;
            DestinationAddress = address;
            DestinationCity = city;
            ExpectedArrival = expectedArrival;
            Details = new List<TransactionDetail>();
        }
        #endregion

        #region Methods

        public static int GetUnusedId(int branchId)
        {
            string sql = "SELECT MAX(Id) FROM transaction WHERE BranchId = '" + branchId + "'";
            int max = 0;
            dbConnection con = new dbConnection();
            MySqlCommand com = new MySqlCommand(sql, con.DbCon);
            using (MySqlDataReader results = com.ExecuteReader())
            {
                while (results.Read() == true)
                {
                    max = results.GetInt32(0);
                }
            }
            sql = "SELECT Id FROM transaction WHERE BranchId = '" + branchId + "' ORDER BY Id ASC";
            con = new dbConnection();
            com = new MySqlCommand(sql, con.DbCon);
            List<int> ids = new List<int>();
            using (MySqlDataReader results = com.ExecuteReader())
            {
                while (results.Read() == true)
                {
                    ids.Add(results.GetInt32(0));
                }
            }

            int newIndex = 0;
            for (int i = 1; i <= ids.Count; i++)
            {
                if (i != ids[i - 1])
                {
                    newIndex = i;
                    break;
                }
            }
            if (newIndex == 0) newIndex = max + 1;

            return newIndex;
        }
        public static List<Transaction> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "SELECT t.BranchId, t.Id, t.TransactionDateDate, t.ClientId, t.CreatedBy, t.ServiceTypeId, t.DestinationAddress, t.DestinationCity, t.ExpectedArrival, b.Name, c.Name, s.Name, st.Name, ci.Name, c.Address, c.PhoneNumber, c.CityId, b.CityId, b.Address, cc.Name, bc.Name, cc.Province, bc.Province, ci.Province FROM transaction t INNER JOIN branch b ON t.BranchId = b.Id INNER JOIN client c ON t.ClientId = c.Id INNER JOIN staff s ON t.CreatedBy = s.Id INNER JOIN servicetype st ON t.ServiceTypeId = st.Id INNER JOIN city ci ON t.DestinationCity = ci.Id INNER JOIN city cc ON c.CityId = cc.Id INNER JOIN city bc ON b.CityId = bc.Id";
            if (searchCriteria == "any")
            {
                sql += " WHERE t.Id LIKE '%" + criteriaValue + "%' OR b.Name LIKE '%" + criteriaValue + "%' OR c.Name LIKE '%" + criteriaValue + "%' OR s.Name LIKE '%" + criteriaValue + "%' OR st.Name LIKE '%" + criteriaValue + "%' OR ci.Name LIKE '%" + criteriaValue + "%' OR t.TransactionDateDate LIKE '%" + criteriaValue + "%' OR t.ExpectedArrival LIKE '%" + criteriaValue + "%' OR t.DestinationAddress LIKE '%" + criteriaValue +"%'";
            }
            else if (searchCriteria == "Id")
            {
                string[] code = criteriaValue.Split();
                sql += " WHERE t.BranchId = '" + code[0] + "' AND t.Id = '" + code[1] + "'";
            }
            else if (searchCriteria == "branchdate")
            {
                string[] code = criteriaValue.Split(';');
                sql += " WHERE t.BranchId = '" + code[0] + "' AND t.TransactionDateDate = '" + code[1] + "'";
            }
            else if (searchCriteria == "branch")
            {
                sql += " WHERE t.BranchId = '" + criteriaValue + "'";
            }
            else if (searchCriteria == "client")
            {
                sql += " WHERE t.ClientId = '" + criteriaValue + "'";
            }
            else if (searchCriteria == "city")
            {
                sql += " WHERE bc.Id = '" + criteriaValue + "'";
            }
            else if (searchCriteria.StartsWith("datemonth"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    if (criteriaValue.Contains('-'))
                    {
                        string[] code2 = criteriaValue.Split('-');
                        sql += " WHERE " + code[1] + ".Id = '" + code[2] + "' AND t.TransactionDateDate LIKE '" + code2[0] + "-" + code2[1] + "-__'";
                    }
                }
                else
                {
                    if (criteriaValue.Contains('-'))
                    {
                        string[] code2 = criteriaValue.Split('-');
                        sql += " WHERE t.TransactionDateDate LIKE '" + code2[0] + "-" + code2[1] + "-__'";
                    }
                }
            }
            else if (searchCriteria.StartsWith("dateyear"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    sql += " WHERE " + code[1] + ".Id = '" + code[2] + "' AND t.TransactionDateDate LIKE '" + criteriaValue + "-" + "__-__'";
                }
                else
                    sql += " WHERE t.TransactionDateDate LIKE '"+criteriaValue+"-" + "__-__'";
            }
            else if (searchCriteria.StartsWith("date"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    sql += " WHERE "+code[1]+".Id = '" + code[2] + "' AND t.TransactionDateDate = '" + criteriaValue + "'";
                }
                else
                    sql += " WHERE t.TransactionDateDate LIKE '" + criteriaValue + "'";
            }
            else if (searchCriteria.StartsWith("clientdatemonth"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    if (criteriaValue.Contains('-'))
                    {
                        string[] code2 = criteriaValue.Split('-');
                        sql += " WHERE t.ClientId = '" + code[1] + "' AND t.TransactionDateDate LIKE '"+code2[0]+"-" + code2[1] + "-__'";
                    }
                }
            }
            else if (searchCriteria.StartsWith("clientdateyear"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    sql += " WHERE t.ClientId = '" + code[1] + "' AND t.TransactionDateDate LIKE '" + criteriaValue + "-" + "__-__'";
                }
            }
            else if (searchCriteria.StartsWith("clientdate"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    sql += " WHERE t.ClientId = '" + code[1] + "' AND t.TransactionDateDate = '" + criteriaValue + "'";
                }
            }
            else if (searchCriteria.StartsWith("branchdatemonth"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    if (criteriaValue.Contains('-'))
                    {
                        string[] code2 = criteriaValue.Split('-');
                        sql += " WHERE t.BranchId = '" + code[1] + "' AND t.TransactionDateDate LIKE '"+code2[0]+"-" + code2[1] + "-__'";
                    }
                }
            }
            else if (searchCriteria.StartsWith("branchdateyear"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    sql += " WHERE t.BranchId = '" + code[1] + "' AND t.TransactionDateDate LIKE '" + criteriaValue + "-" + "__-__'";
                }
            }
            else if (searchCriteria.StartsWith("branchdate"))
            {
                if (searchCriteria.Contains(';'))
                {
                    string[] code = searchCriteria.Split(';');
                    sql += " WHERE t.BranchId = '" + code[1] + "' AND t.TransactionDateDate = '" + criteriaValue + "'";
                }
            }

            List<Transaction> list = new List<Transaction>();

            //MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            //dbConnection con = new dbConnection();
            
            using (dbConnection con = new dbConnection())
            {
                MySqlCommand com = new MySqlCommand(sql, con.DbCon);
                using (MySqlDataReader results = com.ExecuteReader())
                {
                    if (results.HasRows)
                    {
                        while (results.Read() == true)
                        {
                            City clientCity = new City(results.GetInt32(16), results.GetString(19), results.GetString(21));
                            City branchCity = new City(results.GetInt32(17), results.GetString(20), results.GetString(22));

                            Branch b = new Branch(results.GetInt32(0), results.GetString(9), results.GetString(18), branchCity);
                            City ci = new City(results.GetInt32(7), results.GetString(13), results.GetString(23));
                            Client c = new Client(results.GetInt32(3), results.GetString(10), results.GetString(14), results.GetString(15), clientCity);
                            Staff s = new Staff(results.GetString(4), results.GetString(11));
                            ServiceType st = new ServiceType(results.GetInt32(5), results.GetString(12));
                            Transaction t = new Transaction(b, results.GetInt32(1), results.GetDateTime(2), c, s, st, results.GetString(6), ci, results.GetDateTime(8));

                            /*sql = "SELECT td.Id, td.BranchId, td.TransactionId, td.PetTypeId, td.CageId, td.TreatmentId, td.Description, td.Qty, td.Price, b.Name, p.Name, c.Name, t.Name FROM transactiondetail td LEFT JOIN branch b ON td.BranchId = b.Id LEFT JOIN pettype p ON td.PetTypeId = p.Id LEFT JOIN cage c on td.CageId = c.Id LEFT JOIN treatment t ON td.TreatmentId = t.Id WHERE td.Id = '" + t.Id + "' AND td.BranchId = '" + t.Branch.Id + "'";

                            MySqlDataReader resultDetails = dbConnection.ExecuteQuery(sql);
                            while (resultDetails.Read())
                            {
                                PetType p = null;
                                Cage ca = null;
                                Treatment tr = null;
                                if (!resultDetails.IsDBNull(3))
                                    p = new PetType(resultDetails.GetInt32(3), resultDetails.GetString(10));
                                if (!resultDetails.IsDBNull(4))
                                    ca = new Cage(resultDetails.GetInt32(4), resultDetails.GetString(11));
                                if (!resultDetails.IsDBNull(5))
                                    tr = new Treatment(resultDetails.GetInt32(5), resultDetails.GetString(12));
                                TransactionDetail td = new TransactionDetail(t.Id, t.Branch, p, ca, tr, resultDetails.GetString(6), resultDetails.GetInt32(7), resultDetails.GetInt32(8));
                                t.AddDetail(td);
                            }*/

                            List<TransactionDetail> tds = TransactionDetail.Get("Id", t.Branch.Id + " " + t.Id);
                            foreach (TransactionDetail td in tds)
                            {
                                t.Details.Add(td);
                            }
                            list.Add(t);
                        }
                    }
                }
            }
            return list;
        }

        public static int Add(Transaction newRecord)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                dbConnection con = new dbConnection();
                string sql = string.Format("INSERT INTO transaction(BranchId, Id, TransactionDateDate, ClientId, CreatedBy, ServiceTypeId, DestinationAddress, DestinationCity, ExpectedArrival) VALUE('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", newRecord.Branch.Id, newRecord.Id, newRecord.TransactionDate.ToString("yyyy-MM-dd"), newRecord.Client.Id, newRecord.CreatedBy.Id, newRecord.Service.Id, newRecord.DestinationAddress, newRecord.DestinationCity.Id, newRecord.ExpectedArrival.ToString("yyyy-MM-dd"));

                dbConnection.ExecuteNonQuery(sql, con);

                foreach (TransactionDetail t in newRecord.Details)
                {
                    string itemName, itemValue;
                    if (t.PetType != null) {
                        itemValue = t.PetType.Id.ToString();
                        itemName = "PetTypeId";
                    }
                    else if (t.Cage != null)
                    {
                        itemValue = t.Cage.Id.ToString();
                        itemName = "CageId";
                    }
                    else
                    {
                        itemValue = t.Treatment.Id.ToString();
                        itemName = "TreatmentId";
                    }

                    sql = string.Format("INSERT INTO transactiondetail(BranchId, TransactionId, Description, Qty, Price, {6}) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", t.Branch.Id, newRecord.Id, t.Description, t.Qty, t.Price, itemValue, itemName);
                    dbConnection.ExecuteNonQuery(sql, con);
                }

                transcope.Complete();
            }
            return 1;   
        }
        public static Transaction GetByCode(string categoryCode)
        {
            List<Transaction> results = Transaction.Get("Id", categoryCode);
            return results[0];
        }

        public static int Edit(Transaction editRecord)
        {
            string sql = string.Format("UPDATE transaction SET TransactionDateDate = '{0}', ClientId = '{1}', CreatedBy = '{2}', ServiceTypeId = '{3}', DestinationAddress = '{4}', DestinationCity = '{5}', ExpectedArrival = '{6}' WHERE BranchId = '{7}' AND Id = '{8}'", editRecord.TransactionDate.ToString("yyyy-MM-dd"), editRecord.Client.Id, editRecord.CreatedBy.Id, editRecord.Service.Id, editRecord.DestinationAddress,editRecord.DestinationCity.Id,editRecord.ExpectedArrival.ToString("yyyy-MM-dd"),editRecord.Branch.Id,editRecord.Id);

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(Transaction deleteRecord)
        {
            string sql = "DELETE FROM transactionlog WHERE TransactionBranchId = '" + deleteRecord.Branch.Id + "' AND TransactionId = '" + deleteRecord.Id + "'";
            dbConnection.ExecuteNonQuery(sql);

            sql = "DELETE FROM transactiondetail WHERE BranchId = '" + deleteRecord.Branch.Id + "' AND TransactionId = '" + deleteRecord.Id + "'";
            dbConnection.ExecuteNonQuery(sql);

            sql = "DELETE FROM transaction WHERE BranchId = '" + deleteRecord.Branch.Id + "' AND Id = '" + deleteRecord.Id +"'";

            return dbConnection.ExecuteNonQuery(sql);
        }
        public void AddDetail(TransactionDetail td)
        {
            Details.Add(td);
        }
        private static List<DateTime> GetAvailableDate(string name, int id, bool allTransaction)
        {
            List<DateTime> dates = new List<DateTime>();
            string sql = "SELECT DISTINCT t.TransactionDateDate FROM transaction t INNER JOIN branch b ON t.BranchId = b.Id INNER JOIN city c ON b.CityId = c.Id";

            if (!allTransaction) sql += " WHERE " + name + " = '" + id + "'";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            while (results.Read() == true)
            {
                dates.Add(results.GetDateTime(0));
            }
            return dates;
        }
        private static List<string> GetAvailableMonth(string name, int id, bool allTransaction)
        {
            List<string> months = new List<string>();
            string sql = "SELECT DISTINCT CONCAT(YEAR(t.TransactionDateDate), '-', MONTH(t.TransactionDateDate)) FROM transaction t INNER JOIN branch b ON t.BranchId = b.Id INNER JOIN city c ON b.CityId = c.Id";

            if (!allTransaction) sql += " WHERE " + name + " = '" + id + "'";

            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            while (results.Read() == true)
            {
                months.Add(results.GetString(0));
            }
            return months;
        }

        private static List<int> GetAvailableYear(string name, int id, bool allTransaction)
        {
            List<int> years = new List<int>();
            string sql = "SELECT DISTINCT YEAR(t.TransactionDateDate) FROM transaction t INNER JOIN branch b ON t.BranchId = b.Id INNER JOIN city c ON b.CityId = c.Id";

            if (!allTransaction) sql += " WHERE " + name + " = '" + id + "'";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            while (results.Read() == true)
            {
                years.Add(results.GetInt32(0));
            }
            return years;
        }

        public static double GetRevenueDailyAverage(string name, int id, bool allTransaction)
        {
            double spent = 0;
            foreach (DateTime time in GetAvailableDate(name, id, allTransaction))
            {
                List<Transaction> ts = null;
                if (allTransaction)
                {
                    ts = Get("", "");
                }
                else
                {
                    if (name == "c.Id")
                        ts = Get("date;bc;" + id, time.ToString("yyyy-MM-dd"));
                    else if (name == "t.ClientId")
                        ts = Get("clientdate;" + id, time.ToString("yyyy-MM-dd"));
                    else if (name == "t.BranchId")
                        ts = Get("branchdate;" + id, time.ToString("yyyy-MM-dd"));
                }
                int total = 0;
                foreach (Transaction t in ts)
                {
                    total = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        total += d.Qty * d.Price;
                    }
                    spent += total;
                }
                if (ts.Count > 0)
                    spent = (double)(spent / (double)ts.Count);
            }
            spent = (double)(spent / (double)GetAvailableDate(name, id, allTransaction).Count);
            return spent;
        }
        public static double GetRevenueMonthlyAverage(string name, int id, bool allTransaction)
        {
            double spent = 0;
            foreach (string month in GetAvailableMonth(name, id, allTransaction))
            {
                List<Transaction> ts = null;
                if (allTransaction)
                {
                    ts = Get("", "");
                }
                else
                {
                    if (name == "c.Id")
                        ts = Get("datemonth;bc;" + id, month);
                    else if (name == "t.ClientId")
                        ts = Get("clientdatemonth;" + id, month);
                    else if (name == "t.BranchId")
                        ts = Get("branchdatemonth;" + id, month);
                }
                int total = 0;
                foreach (Transaction t in ts)
                {
                    total = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        total += d.Qty * d.Price;
                    }
                    spent += total;
                }
                if (ts.Count>0)
                    spent = (double)(spent / (double)ts.Count);
            }
            spent = (double)(spent / (double)GetAvailableMonth(name, id, allTransaction).Count);
            return spent;
        }
        public static double GetRevenueYearlyAverage(string name, int id, bool allTransaction)
        {
            double spent = 0;
            foreach (int year in GetAvailableYear(name, id, allTransaction))
            {
                List<Transaction> ts = null;
                if (allTransaction)
                {
                    ts = Get("", "");
                }
                else
                {
                    if (name == "c.Id")
                        ts = Get("dateyear;bc;" + id, year.ToString());
                    else if (name == "t.ClientId")
                        ts = Get("clientdateyear;" + id, year.ToString(""));
                    else if (name == "t.BranchId")
                        ts = Get("branchdateyear;" + id, year.ToString(""));
                }
                int total = 0;
                foreach (Transaction t in ts)
                {
                    total = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        total += d.Qty * d.Price;
                    }
                    spent += total;
                }
                if (ts.Count > 0)
                    spent = (double)(spent / (double)ts.Count);
            }
            spent = (double)(spent / (double)GetAvailableYear(name,id, allTransaction).Count);
            return spent;
        }
        public static double CalculateTotalRevenue(string name, int id, bool allTransaction)
        {
            List<Transaction> ts = RetrieveTransactions(name, id, allTransaction);
            double total = 0;
            foreach(Transaction t in ts)
            {
                foreach(TransactionDetail td in t.Details)
                {
                    total += td.Price * td.Qty;
                }
            }
            return total;
        }

        public static int GetDailyAverageNumber(string name, int id, bool allTransaction)
        {
            int count = 0;
            foreach (DateTime time in GetAvailableDate(name, id, allTransaction))
            {
                List<Transaction> ts = null;
                if (allTransaction) ts = Get("date", time.ToString("yyyy-MM-dd"));
                else
                {
                    if (name == "c.Id")
                        ts = Get("date;bc;" + id, time.ToString("yyyy-MM-dd"));
                    else if (name == "t.BranchId")
                        ts = Get("branchdate;" + id, time.ToString("yyyy-MM-dd"));
                }
                count += ts.Count;
            }
            count = (int)Math.Ceiling((double)count / (double)GetAvailableDate(name,id, allTransaction).Count);
            return count;
        }

        public static int GetMonthlyAverageNumber(string name, int id, bool allTransaction)
        {
            int count = 0;
            foreach (string month in GetAvailableMonth(name, id, allTransaction))
            {
                List<Transaction> ts = null;
                if (allTransaction)
                {
                        ts = Get("datemonth", month);
                }
                else
                {
                    if (name == "c.Id")
                        ts = Get("datemonth;bc;" + id, month);
                    else if (name == "t.ClientId")
                        ts = Get("clientdatemonth;" + id, month);
                    else if (name == "t.BranchId")
                        ts = Get("branchdatemonth;" + id, month);
                }
                count += ts.Count;
            }
            count = (int)Math.Ceiling((double)count / (double)GetAvailableMonth(name, id, allTransaction).Count);
            return count;
        }

        public static int GetYearlyAverageNumber(string name, int id, bool allTransaction)
        {
            int count = 0;
            foreach (int year in GetAvailableYear(name, id, allTransaction))
            {
                List<Transaction> ts = null;
                if (allTransaction) ts = Get("dateyear", year.ToString());
                else
                {
                    if (name == "c.Id")
                        ts = Get("dateyear;bc;" + id, year.ToString());
                    else if (name == "t.ClientId")
                        ts = Get("clientdateyear;" + id, year.ToString());
                    else if (name == "t.BranchId")
                        ts = Get("branchdateyear;" + id, year.ToString());
                }
                count += ts.Count;
            }
            count = (int)Math.Ceiling((double)count / (double)GetAvailableYear(name, id,allTransaction).Count);
            return count;
        }
        public static int CalculateTotalNumber(string name, int id, bool allTransaction)
        {
            List<Transaction> ts = RetrieveTransactions(name, id, allTransaction);
            return ts.Count;
        }
        // City and Client
        public static string GetCommonPetTypes(string name, int id, bool allTransaction)
        {
            List<Transaction> ts = RetrieveTransactions(name, id, allTransaction);
            List<PetType> petTypes = PetType.Get("", "");
            int total=0;
            int[] counts = new int[petTypes.Count];
            string[] names = new string[petTypes.Count];
            bool[] containedPet = new bool[petTypes.Count];
            for(int i=0;i<petTypes.Count;i++)
            {
                names[i] = petTypes[i].Name;
                containedPet[i] = false;
                counts[i] = 0;
            }
            foreach (Transaction t in ts)
            {
                foreach (TransactionDetail d in t.Details)
                {
                    for (int i = 0; i < petTypes.Count; i++)
                    {
                        if (d.PetType!=null && d.PetType.Id == petTypes[i].Id)
                        {
                            counts[i] += 1;
                            break;
                        }
                    }
                    if (d.PetType != null)
                    {
                        total++;
                        if (name == "t.ClientId")
                        {
                            for(int j=0;j<petTypes.Count;j++)
                            {
                                if (petTypes[j].Name == d.PetType.Name)
                                    containedPet[j] = true;
                            }
                        }
                    }
                }
            }
            int max = Array.FindIndex(counts, x => x == counts.Max());
            if (name == "t.ClientId")
            {
                string res = "";
                for(int i = 0; i < containedPet.Count(); i++)
                {
                    if (containedPet[i])
                        res += petTypes[i].Name + ", ";
                }
                return res.TrimEnd(new char[] { ',', ' ' });
            }
            else
                return names[max] + " " + Math.Round((double)((double)counts[max]/(double)total),2)*100+"%";
        }

        // Branch - Period
        public static string GetCommonPetTypes(string type, int id, DateTime period)
        {
            List<Transaction> ts = new List<Transaction>();
            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.ToString("yyyy"));
            }
            List<PetType> petTypes = PetType.Get("", "");
            int total = 0;
            int[] counts = new int[petTypes.Count];
            string[] names = new string[petTypes.Count];

            for (int i = 0; i < petTypes.Count; i++)
            {
                names[i] = petTypes[i].Name;
                counts[i] = 0;
            }
            foreach (Transaction t in ts)
            {
                foreach (TransactionDetail d in t.Details)
                {
                    for (int i = 0; i < petTypes.Count; i++)
                    {
                        if (d.PetType != null && d.PetType.Id == petTypes[i].Id)
                        {
                            counts[i] += 1;
                            break;
                        }
                    }
                    if (d.PetType != null)
                    {
                        total++;
                    }
                }
            }
            int max = Array.FindIndex(counts, x => x == counts.Max());
            return names[max] + " " + Math.Round((double)((double)counts[max] / (double)total), 2) * 100 + "%";
        }

        // City and Client
        public static string GetCommonService(string name, int id, bool allTransaction)
        {
            List<Transaction> ts = RetrieveTransactions(name, id, allTransaction);
            List<ServiceType> serviceTypes = ServiceType.Get("", "");
            int[] counts = new int[serviceTypes.Count];
            string[] names = new string[serviceTypes.Count];
            for (int i = 0; i < serviceTypes.Count; i++)
            {
                names[i] = serviceTypes[i].Name;
                counts[i] = 0;
            }
            foreach (Transaction t in ts)
            {
                for (int i = 0; i < serviceTypes.Count; i++)
                {
                    if (t.Service != null && t.Service.Id == serviceTypes[i].Id)
                    {
                        counts[i] += 1;
                        break;
                    }
                }
            }
            int max = Array.FindIndex(counts, x => x == counts.Max());
            return names[max] + " " + Math.Round((double)((double)counts[max] / (double)ts.Count), 2) * 100 + "%"; ;
        }

        // Branch - Period
        public static string GetCommonService(string type, int id, DateTime period)
        {
            List<Transaction> ts = new List<Transaction>();
            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.ToString("yyyy"));
            }
            List<ServiceType> serviceTypes = ServiceType.Get("", "");
            int[] counts = new int[serviceTypes.Count];
            string[] names = new string[serviceTypes.Count];
            for (int i = 0; i < serviceTypes.Count; i++)
            {
                names[i] = serviceTypes[i].Name;
                counts[i] = 0;
            }
            foreach (Transaction t in ts)
            {
                for (int i = 0; i < serviceTypes.Count; i++)
                {
                    if (t.Service != null && t.Service.Id == serviceTypes[i].Id)
                    {
                        counts[i] += 1;
                        break;
                    }
                }
            }
            int max = Array.FindIndex(counts, x => x == counts.Max());
            return names[max] + " " + Math.Round((double)((double)counts[max] / (double)ts.Count), 2) * 100 + "%"; ;
        }

        // City and Client
        public static string GetCommonTreatment(string name, int id, bool allTransaction)
        {
            List<Transaction> ts = RetrieveTransactions(name, id, allTransaction);
            List<Treatment> treatments = Treatment.Get("", "");
            int[] counts = new int[treatments.Count];
            string[] names = new string[treatments.Count];
            int total = 0;
            for (int i = 0; i < treatments.Count; i++)
            {
                names[i] = treatments[i].Name;
                counts[i] = 0;
            }
            foreach (Transaction t in ts)
            {
                foreach (TransactionDetail d in t.Details)
                {
                    for (int i = 0; i < treatments.Count; i++)
                    {
                        if (d.Treatment != null && d.Treatment.Id == treatments[i].Id)
                        {
                            counts[i] += 1;
                            break;
                        }
                    }
                    if (d.Treatment != null)
                        total++;
                }
            }
            int max = Array.FindIndex(counts, x => x == counts.Max());
            if (total != 0)
                return names[max] + " " + Math.Round((double)((double)counts[max] / (double)total), 2) * 100 + "%";
            else return "Not found!";
        }
        // Branch - Period
        public static string GetCommonTreatment(string type, int id, DateTime period)
        {
            List<Transaction> ts = new List<Transaction>();
            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.ToString("yyyy"));
            }
            List<Treatment> treatments = Treatment.Get("", "");
            int[] counts = new int[treatments.Count];
            string[] names = new string[treatments.Count];
            int total = 0;
            for (int i = 0; i < treatments.Count; i++)
            {
                names[i] = treatments[i].Name;
                counts[i] = 0;
            }
            foreach (Transaction t in ts)
            {
                foreach (TransactionDetail d in t.Details)
                {
                    for (int i = 0; i < treatments.Count; i++)
                    {
                        if (d.Treatment != null && d.Treatment.Id == treatments[i].Id)
                        {
                            counts[i] += 1;
                            break;
                        }
                    }
                    if (d.Treatment != null)
                        total++;
                }
            }
            int max = Array.FindIndex(counts, x => x == counts.Max());
            if (total != 0)
                return names[max] + " " + Math.Round((double)((double)counts[max] / (double)total), 2) * 100 + "%";
            else return "Not found!";
        }

        public static int GetCityRank(string name, int id)
        {
            List<City> cities = City.Get("", "");

            // score = 80% * monthly revenue avg + 20% * total number of transaction
            Dictionary<string, double> dict = new Dictionary<string, double>();
            double[] scores = new double[cities.Count];
            for(int i = 0; i < cities.Count; i++)
            {
                double score = ((double)(0.8 * GetRevenueMonthlyAverage(name, cities[i].Id, false)) + (double)(0.2 * CalculateTotalNumber(name, cities[i].Id, false)));
                dict.Add(cities[i].Id.ToString(),score);
            }
            var sorted = dict.OrderByDescending(pair => pair.Value)
               .ToDictionary(pair => pair.Key, pair => pair.Value);

            return sorted.Keys.ToList().IndexOf(id.ToString()) + 1;
        }
        public static int GetClientRank(string name, int id)
        {
            List<Client> clients = Client.Get("", "");

            // score = 80% * monthly revenue avg + 20% * total number of transaction
            Dictionary<string, double> dict = new Dictionary<string, double>();
            double[] scores = new double[clients.Count];
            for (int i = 0; i < clients.Count; i++)
            {
                double score = ((double)(0.8 * GetRevenueMonthlyAverage(name, clients[i].Id, false)) + (double)(0.2 * CalculateTotalNumber(name, clients[i].Id,false)));
                dict.Add(clients[i].Id.ToString(), score);
            }
            var sorted = dict.OrderByDescending(pair => pair.Value)
               .ToDictionary(pair => pair.Key, pair => pair.Value);

            return sorted.Keys.ToList().IndexOf(id.ToString()) + 1;
        }
        public static int GetBranchRank(string name, int id)
        {
            List<Branch> branches = Branch.Get("", "");

            // score = 80% * monthly revenue avg + 20% * total number of transaction
            Dictionary<string, double> dict = new Dictionary<string, double>();
            double[] scores = new double[branches.Count];
            for (int i = 0; i < branches.Count; i++)
            {
                double score = ((double)(0.8 * GetRevenueMonthlyAverage(name, branches[i].Id, false)) + (double)(0.2 * CalculateTotalNumber(name, branches[i].Id, false)));
                dict.Add(branches[i].Id.ToString(), score);
            }
            var sorted = dict.OrderByDescending(pair => pair.Value)
               .ToDictionary(pair => pair.Key, pair => pair.Value);

            return sorted.Keys.ToList().IndexOf(id.ToString()) + 1;
        }
        public static double GetHighestAmount(int id)
        {
            double res = 0;
            string sql = "SELECT SUM(d.Price*d.Qty) AS sum FROM transaction t INNER JOIN transactiondetail d ON t.Id = d.TransactionId WHERE t.ClientId = '"+id+"' GROUP BY t.Id ORDER BY sum DESC";
            MySql.Data.MySqlClient.MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            while (results.Read() == true)
            {
                res = results.GetDouble(0);
                break;
            }
            return res;
        }

        public static double GetAverageRevenue(bool allBranch, int id, string type, DateTime period, out double Total)
        {
            List<Transaction> ts = new List<Transaction>();

            if (allBranch)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date", period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth", period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear", period.ToString("yyyy"));
                }
            }
            else
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;"+id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;"+id, period.ToString("yyyy"));
                }
            }

            double spent = 0;
            int total = 0;
            foreach (Transaction t in ts)
            {
                total = 0;
                foreach (TransactionDetail d in t.Details)
                {
                    total += d.Qty * d.Price;
                }
                spent += total;
            }
            Total = spent;
            spent = (double)(spent / (double)Branch.Get("", "").Count);

            return spent;
        }

        public static double GetHighestRevenue(string type, DateTime period, out string branchName)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            List<double> revenues = new List<double>();

            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;"+branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }

                double spent = 0;
                int total = 0;
                foreach (Transaction t in ts)
                {
                    total = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        total += d.Qty * d.Price;
                    }
                    spent += total;
                }
                revenues.Add(spent);
            }
            
            int max = Array.FindIndex(revenues.ToArray(), x => x == revenues.Max());

            branchName = branches[max].Name;
            return revenues[max];
        }

        public static double GetLowestRevenue(string type, DateTime period, out string branchName)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            List<double> revenues = new List<double>();

            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }

                double spent = 0;
                int total = 0;
                foreach (Transaction t in ts)
                {
                    total = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        total += d.Qty * d.Price;
                    }
                    spent += total;
                }
                if (spent!=0)
                    revenues.Add(spent);
            }

            int min = Array.FindIndex(revenues.ToArray(), x => x == revenues.Min());

            branchName = branches[min].Name;
            return revenues[min];
        }

        public static double GetAverageTransaction(string type, DateTime period, out int Total)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            int total = 0;
            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }

                total += ts.Count;
            }
            Total = total;
            total = total / branches.Count;

            return total;
        }
        public static double GetHighestTransaction(string type, DateTime period, out string branchName)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            List<int> counts = new List<int>();
            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }
                counts.Add(ts.Count);
            }

            int max = Array.FindIndex(counts.ToArray(), x => x == counts.Max());
            branchName = branches[max].Name;
            return counts[max];
        }
        public static double GetLowestTransaction(string type, DateTime period, out string branchName)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            List<int> counts = new List<int>();
            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }
                counts.Add(ts.Count);
            }

            int min = Array.FindIndex(counts.ToArray(), x => x == counts.Min());
            branchName = branches[min].Name;
            return counts[min];
        }

        public static double GetIncreaseSales(string type, DateTime period)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            int total = 0, totalPrev = 0;
            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }

                total += ts.Count;
            }

            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.AddDays(-1).ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.AddMonths(-1).ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.AddYears(-1).ToString("yyyy"));
                }
                
                totalPrev += ts.Count;
            }

            double res = (double)((double)(total - totalPrev) / (double)totalPrev);

            if (totalPrev == 0) return 0;
            else
                return res;
        }

        public static double GetIncreaseSales(string type, DateTime period, int id)
        {
            List<Transaction> ts = new List<Transaction>();
            int total = 0, totalPrev = 0;
            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.ToString("yyyy"));
            }
            total += ts.Count;

            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.AddDays(-1).ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.AddMonths(-1).ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.AddYears(-1).ToString("yyyy"));
            }
            totalPrev += ts.Count;

            double res = (double)((double)(total - totalPrev) / (double)totalPrev);

            if (totalPrev == 0) return 0;
            else
                return res;
        }

        public static double GetIncreaseRevenue(string type, DateTime period)
        {
            List<Transaction> ts = new List<Transaction>();
            List<Branch> branches = Branch.Get("", "");
            double total = 0, totalPrev = 0;
            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.ToString("yyyy"));
                }

                foreach (Transaction t in ts)
                {
                    double spent = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        spent += d.Qty * d.Price;
                    }
                    total += spent;
                }
            }

            for (int i = 0; i < branches.Count; i++)
            {
                if (type == "day")
                {
                    ts = Transaction.Get("date;b;" + branches[i].Id, period.AddDays(-1).ToString("yyyy-MM-dd"));
                }
                else if (type == "month")
                {
                    ts = Transaction.Get("datemonth;b;" + branches[i].Id, period.AddMonths(-1).ToString("yyyy-MM"));
                }
                else if (type == "year")
                {
                    ts = Transaction.Get("dateyear;b;" + branches[i].Id, period.AddYears(-1).ToString("yyyy"));
                }

                foreach (Transaction t in ts)
                {
                    double spent = 0;
                    foreach (TransactionDetail d in t.Details)
                    {
                        spent += d.Qty * d.Price;
                    }
                    totalPrev += spent;
                }
            }

            double res = (double)((double)(total - totalPrev) / (double)totalPrev);

            if (totalPrev == 0) return 0;
            else
                return res;
        }
        public static double GetIncreaseRevenue(string type, DateTime period, int id)
        {
            List<Transaction> ts = new List<Transaction>();
            double total = 0, totalPrev = 0;
            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.ToString("yyyy"));
            }

            foreach (Transaction t in ts)
            {
                double spent = 0;
                foreach (TransactionDetail d in t.Details)
                {
                    spent += d.Qty * d.Price;
                }
                total += spent;
            }

            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.AddDays(-1).ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.AddMonths(-1).ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.AddYears(-1).ToString("yyyy"));
            }

            foreach (Transaction t in ts)
            {
                double spent = 0;
                foreach (TransactionDetail d in t.Details)
                {
                    spent += d.Qty * d.Price;
                }
                totalPrev += spent;
            }

            double res = (double)((double)(total - totalPrev) / (double)totalPrev);

            if (totalPrev == 0) return 0;
            else
                return res;
        }

        public static double GetTotalOfItems(string type, DateTime period, int id, out double totalPet, out double totalCage, out double totalTreatment, out double total)
        {
            double res = 0;
            total = 0;
            totalPet = 0;
            totalCage = 0;
            totalTreatment = 0;
            List<Transaction> ts = new List<Transaction>();
            if (type == "day")
            {
                ts = Transaction.Get("date;b;" + id, period.ToString("yyyy-MM-dd"));
            }
            else if (type == "month")
            {
                ts = Transaction.Get("datemonth;b;" + id, period.ToString("yyyy-MM"));
            }
            else if (type == "year")
            {
                ts = Transaction.Get("dateyear;b;" + id, period.ToString("yyyy"));
            }

            foreach (Transaction t in ts)
            {
                foreach (TransactionDetail d in t.Details)
                {
                    if (d.PetType!=null)
                        totalPet += d.Qty * d.Price;
                    else if (d.Cage!=null)
                        totalCage += d.Qty * d.Price;
                    else if (d.Treatment!=null)
                        totalTreatment += d.Qty * d.Price;

                    res += d.Qty * d.Price;
                }
            }
            total = ts.Count;
            return res;
        }

        private static List<Transaction> RetrieveTransactions(string name, int id, bool allTransaction)
        {
            List<Transaction> ts = null;
            if (allTransaction) ts = Get("", "");
            else
            {
                if (name == "c.Id")
                    ts = Get("city", id.ToString());
                else if (name == "t.ClientId")
                    ts = Get("client", id.ToString());
                else if (name == "t.BranchId")
                    ts = Get("branch", id.ToString());
            }
            return ts;
        }
        public static bool Print(string searchCriteria, string criteriaValue, string fileName, Font fontType, out string path)
        {
            List<Transaction> transactions = Get(searchCriteria, criteriaValue);

            StreamWriter f = new StreamWriter(fileName);
            foreach (Transaction t in transactions)
            {
                f.WriteLine("");
                f.WriteLine("<16><b><center>Pet Mover Company");
                f.WriteLine("");
                f.WriteLine("<center>Transaction #: " + t.Id.ToString("00000"));
                f.WriteLine("<center>Transaction Date: " + t.TransactionDate.ToShortDateString());
                f.WriteLine("<center>Created by: " + t.CreatedBy.Name + " (staff code: "+t.CreatedBy.Id+")");

                f.WriteLine("");
                f.WriteLine("Client: ".PadLeft(15,' ') + t.Client.Name.PadRight(25, ' ') + "Phone: ".PadLeft(13, ' ') + t.Client.PhoneNumber.PadRight(13, ' '));
                f.WriteLine(t.Client.Address.PadLeft(15+t.Client.Address.Length, ' ') + ",");
                f.WriteLine(t.Client.City.Name.PadLeft(15+t.Client.City.Name.Length, ' '));
                f.WriteLine(t.Client.City.Province.PadLeft(15 +t.Client.City.Province.Length, ' '));
                f.WriteLine("Branch Origin: ".PadLeft(15, ' ') + (t.Branch.Id + "-" + t.Branch.Address).PadRight(25, ' ') + "Destination: ".PadLeft(13, ' ') + (t.DestinationAddress+", "+t.DestinationCity.Name).PadRight(13, ' '));
                f.WriteLine(t.Branch.City.Name.PadLeft(15+t.Branch.City.Name.Length, ' ') + t.DestinationCity.Province.PadLeft(53-15+ t.Branch.City.Name.Length, ' '));
                f.WriteLine("Type: ".PadLeft(15, ' ') + t.Service.Name.PadRight(25, ' ') + "Expected Arrival: ".PadLeft(13, ' ') + (t.ExpectedArrival.ToShortDateString() + " (" + t.ExpectedArrival.Subtract(t.TransactionDate).TotalDays +" days)").PadRight(13, ' '));
                
                f.WriteLine("<b>_".PadRight(80, '_'));
                f.WriteLine("");
                f.WriteLine("<center><b><14>Transaction Details");
                f.WriteLine("<b>_".PadRight(80, '_'));
                f.WriteLine("");
                f.Write("<b>Type".PadRight(18, ' '));
                f.Write("Description".PadRight(25, ' '));
                f.Write("Price".PadLeft(13, ' '));
                f.Write("Quantity".PadLeft(11, ' '));
                f.Write("Sub Total".PadLeft(13, ' '));
                f.WriteLine("");
                f.WriteLine("_".PadRight(77, '_'));
                f.WriteLine("");
                int grandTotal = 0;
                foreach (TransactionDetail d in t.Details)
                {
                    string type = "";
                    if (d.PetType != null) type = d.PetType.Name;
                    else if (d.Cage != null) type = "Cage";
                    else if (d.Treatment != null) type = "Treatment";
                    string desc = d.Description;
                    desc = desc.Substring(0, Math.Min(27, desc.Length));
                    type = type.Substring(0, Math.Min(15, type.Length));
                    int qty = d.Qty;
                    int price = d.Price;
                    int subtotal = qty * price;
                    grandTotal += subtotal;
                    f.Write(type.PadRight(15, ' '));
                    f.Write(desc.PadRight(25, ' '));
                    f.Write(price.ToString("C0").PadLeft(13, ' '));
                    f.Write(qty.ToString().PadLeft(11, ' '));
                    f.Write(subtotal.ToString("C0").PadLeft(13, ' '));
                    f.WriteLine("");
                    f.WriteLine("_".PadRight(77, '_'));
                    f.WriteLine("");
                }
                f.WriteLine("<b>TOTAL".PadLeft(67,' ') + grandTotal.ToString("C0").PadLeft(13, ' '));

            }
            f.Close();
            CustomPrint p = new CustomPrint(fontType, fileName, 20, 20, 10, 10);

            bool isPrinted = p.SendToPrinter();
            path = p.FileName;
            return isPrinted;
        }

        public static bool Print(Transaction t, string fileName, Font fontType, out string path)
        {
            StreamWriter f = new StreamWriter(fileName);
            f.WriteLine("");
            f.WriteLine("<16><b><center>Pet Mover Company");
            f.WriteLine("");
            f.WriteLine("<center>Transaction #: " + t.Id.ToString("00000"));
            f.WriteLine("<center>Transaction Date: " + t.TransactionDate.ToShortDateString());
            f.WriteLine("<center>Created by: " + t.CreatedBy.Name + " (staff code: " + t.CreatedBy.Id + ")");

            f.WriteLine("");
            f.WriteLine("Client: ".PadLeft(15, ' ') + t.Client.Name.PadRight(25, ' ') + "Phone: ".PadLeft(13, ' ') + t.Client.PhoneNumber.PadRight(13, ' '));
            f.WriteLine(t.Client.Address.PadLeft(15 + t.Client.Address.Length, ' ') + ",");
            f.WriteLine(t.Client.City.Name.PadLeft(15 + t.Client.City.Name.Length, ' '));
            f.WriteLine(t.Client.City.Province.PadLeft(15 + t.Client.City.Province.Length, ' '));
            f.WriteLine("Branch Origin: ".PadLeft(15, ' ') + (t.Branch.Id + "-" + t.Branch.Address).PadRight(25, ' ') + "Destination: ".PadLeft(13, ' ') + (t.DestinationAddress + ", " + t.DestinationCity.Name).PadRight(13, ' '));
            f.WriteLine(t.Branch.City.Name.PadLeft(15 + t.Branch.City.Name.Length, ' ') + t.DestinationCity.Province.PadLeft(53 - 15 + t.Branch.City.Name.Length, ' '));
            f.WriteLine("Type: ".PadLeft(15, ' ') + t.Service.Name.PadRight(25, ' ') + "Expected Arrival: ".PadLeft(13, ' ') + (t.ExpectedArrival.ToShortDateString() + " (" + t.ExpectedArrival.Subtract(t.TransactionDate).TotalDays + " days)").PadRight(13, ' '));

            f.WriteLine("<b>_".PadRight(80, '_'));
            f.WriteLine("");
            f.WriteLine("<center><b><14>Transaction Details");
            f.WriteLine("<b>_".PadRight(80, '_'));
            f.WriteLine("");
            f.Write("<b>Type".PadRight(18, ' '));
            f.Write("Description".PadRight(25, ' '));
            f.Write("Price".PadLeft(13, ' '));
            f.Write("Quantity".PadLeft(11, ' '));
            f.Write("Sub Total".PadLeft(13, ' '));
            f.WriteLine("");
            f.WriteLine("_".PadRight(77, '_'));
            f.WriteLine("");
            int grandTotal = 0;
            foreach (TransactionDetail d in t.Details)
            {
                string type = "";
                if (d.PetType != null) type = d.PetType.Name;
                else if (d.Cage != null) type = "Cage";
                else if (d.Treatment != null) type = "Treatment";
                string desc = d.Description;
                desc = desc.Substring(0, Math.Min(27, desc.Length));
                type = type.Substring(0, Math.Min(15, type.Length));
                int qty = d.Qty;
                int price = d.Price;
                int subtotal = qty * price;
                grandTotal += subtotal;
                f.Write(type.PadRight(15, ' '));
                f.Write(desc.PadRight(25, ' '));
                f.Write(price.ToString("C0").PadLeft(13, ' '));
                f.Write(qty.ToString().PadLeft(11, ' '));
                f.Write(subtotal.ToString("C0").PadLeft(13, ' '));
                f.WriteLine("");
                f.WriteLine("_".PadRight(77, '_'));
                f.WriteLine("");
            }
            f.WriteLine("<b>TOTAL".PadLeft(67, ' ') + grandTotal.ToString("C0").PadLeft(13, ' '));
            f.Close();
            CustomPrint p = new CustomPrint(fontType, fileName, 20, 20, 10, 10);
            bool isPrinted = p.SendToPrinter();
            path = p.FileName;
            return isPrinted;
        }

        public static bool PrintCityReport(string fileName, Font fontType, string city, string revDailyAvg, string revMonthlyAvg, string revYearlyAvg, string totalRev, string numDailyAvg, string numMonthlyAvg, string numYearlyAvg, string totalNum, string mostPet, string mostService, string mostTreatment, string rank, out string path)
        {
            StreamWriter f = new StreamWriter(fileName);
            f.WriteLine("<center><b><16>Sales Performance in " + city);
            f.WriteLine("");
            f.WriteLine("");
            f.WriteLine("<b><14>Revenue:");
            f.WriteLine("");
            f.WriteLine("Daily Average".PadRight(30, ' ') + ":  " +revDailyAvg) ;
            f.WriteLine("Monthly Average".PadRight(30, ' ') + ":  " + revMonthlyAvg);
            f.WriteLine("Yearly Average".PadRight(30, ' ') + ":  " + revYearlyAvg);
            f.WriteLine("<b>Total Revenue".PadRight(33, ' ') + ":  " + totalRev.Split()[2]);
            f.WriteLine("");

            f.WriteLine("<b><14>Number of Transactions:");
            f.WriteLine("");
            f.WriteLine("Daily Average".PadRight(30, ' ') + ":  " + numDailyAvg);
            f.WriteLine("Monthly Average".PadRight(30, ' ') + ":  " + numMonthlyAvg);
            f.WriteLine("Yearly Average".PadRight(30, ' ') + ":  " + numYearlyAvg);
            f.WriteLine("<b>Total Transaction".PadRight(33, ' ') + ":  " + totalNum.Split()[2]);
            f.WriteLine("");

            f.WriteLine("<b><14>Additional Information:");
            f.WriteLine("");
            f.WriteLine("Common Pet Type".PadRight(30, ' ') + ":  " + mostPet);
            f.WriteLine("Most Service Used".PadRight(30, ' ') + ":  " + mostService);
            f.WriteLine("Most Treatment Ordered".PadRight(30, ' ') + ":  " + mostTreatment);
            f.WriteLine("");
            f.WriteLine("<b><14>RANK"+ ":  " + rank.Split()[2]);

            f.Close();
            CustomPrint p = new CustomPrint(fontType, fileName, 20, 20, 20, 10);
            bool isPrinted = p.SendToPrinter();
            path = p.FileName;
            return isPrinted;
        }

        public static bool PrintClientReport(string fileName, Font fontType, string client, string highestAmount, string revMonthlyAvg, string revYearlyAvg, string totalRev, string numMonthlyAvg, string numYearlyAvg, string totalNum, string pets, string mostService, string mostTreatment, string rank, out string path)
        {
            StreamWriter f = new StreamWriter(fileName);
            f.WriteLine("<center><b><16>Sales Performance for Client " + client);
            f.WriteLine("");
            f.WriteLine("");
            f.WriteLine("<b><14>Revenue:");
            f.WriteLine("");
            f.WriteLine("Highest Amount Spent".PadRight(30, ' ') + ":  " + highestAmount);
            f.WriteLine("Monthly Average".PadRight(30, ' ') + ":  " + revMonthlyAvg);
            f.WriteLine("Yearly Average".PadRight(30, ' ') + ":  " + revYearlyAvg);
            f.WriteLine("<b>Total Revenue".PadRight(33, ' ') + ":  " + totalRev.Split()[2]);
            f.WriteLine("");

            f.WriteLine("<b><14>Number of Transactions:");
            f.WriteLine("");
            f.WriteLine("Monthly Average".PadRight(30, ' ') + ":  " + numMonthlyAvg);
            f.WriteLine("Yearly Average".PadRight(30, ' ') + ":  " + numYearlyAvg);
            f.WriteLine("<b>Total Transaction".PadRight(33, ' ') + ":  " + totalNum.Split()[2]);
            f.WriteLine("");

            f.WriteLine("<b><14>Additional Information:");
            f.WriteLine("");
            f.WriteLine("Pet Types Owned".PadRight(30, ' ') + ":  " + pets);
            f.WriteLine("Most Service Used".PadRight(30, ' ') + ":  " + mostService);
            f.WriteLine("Most Treatment Ordered".PadRight(30, ' ') + ":  " + mostTreatment);
            f.WriteLine("");
            f.WriteLine("<b><14>RANK" + ":  " + rank.Split()[2]);

            f.Close();
            CustomPrint p = new CustomPrint(fontType, fileName, 20, 20, 20, 10);
            bool isPrinted = p.SendToPrinter();
            path = p.FileName;
            return isPrinted;
        }

        public static bool PrintBranchReport(string type, string fileName, Font fontType, string title, string subtitle1, string subtitle2, string subtitle3, string out1, string out2, string out3, string out4, string out5, string out6, string out7, string out8, string out9, string lastOut1, string lastOut2, string lastOut3, out string path)
        {
            StreamWriter f = new StreamWriter(fileName);
            f.WriteLine("<center><b><16>" + title);
            f.WriteLine("");
            f.WriteLine("");
            f.WriteLine("<b><14>"+subtitle1+":");
            f.WriteLine("");

            if (type.Contains("all/period"))
            {
                f.WriteLine("Daily Average".PadRight(30, ' ') + ":  " + out1);
                f.WriteLine("Monthly Average".PadRight(30, ' ') + ":  " + out2);
                f.WriteLine("Yearly Average".PadRight(30, ' ') + ":  " + out3);
                f.WriteLine("<b>Total Revenue".PadRight(33, ' ') + ":  " + lastOut1.Split()[2]);
                f.WriteLine("");

                f.WriteLine("<b><14>" + subtitle2 + ":");
                f.WriteLine("");
                f.WriteLine("Daily Average".PadRight(30, ' ') + ":  " + out4);
                f.WriteLine("Monthly Average".PadRight(30, ' ') + ":  " + out5);
                f.WriteLine("Yearly Average".PadRight(30, ' ') + ":  " + out6);
                f.WriteLine("<b>Total Transaction".PadRight(33, ' ') + ":  " + lastOut2.Split()[2]);
                f.WriteLine("");

                f.WriteLine("<b><14>" + subtitle3 + ":");
                f.WriteLine("");
                f.WriteLine("Common Pet Type".PadRight(30, ' ') + ":  " + out7);
                f.WriteLine("Most Service Used".PadRight(30, ' ') + ":  " + out8);
                f.WriteLine("Most Treatment Ordered".PadRight(30, ' ') + ":  " + out9);
                f.WriteLine("");

                if (type.Split(';').Count()>1)
                {
                    f.WriteLine("<b><14>RANK" + ":  " + lastOut3.Split()[2]);
                }
                else
                {
                    string ranking = "";
                    List<Branch> bs = Branch.Get("", "");
                    List<int> ranks = new List<int>();
                    foreach (Branch b in bs)
                    {
                        ranks.Add(GetBranchRank("t.BranchId", b.Id));
                    }

                    for (int i = 0; i < ranks.Count; i++)
                    {
                        for (int j = 0; j < ranks.Count; j++)
                        {
                            if (ranks[j] == i + 1)
                            {
                                ranking += "(#" + (i + 1) + ") " + bs[j].Name + ", ";
                                break;
                            }
                        }
                    }

                    f.WriteLine("<b><14>BRANCH RANKING" + ":");
                    f.WriteLine("");
                    f.WriteLine(ranking.TrimEnd(new char[] { ',', ' ' }));
                }
            }
            else if (type == "allBranch")
            {
                f.WriteLine("Average Among Branches".PadRight(30, ' ') + ":  " + out1);
                f.WriteLine("Lowest".PadRight(30, ' ') + ":  " + out2);
                f.WriteLine("Highest".PadRight(30, ' ') + ":  " + out3);
                f.WriteLine("<b>Total Revenue".PadRight(33, ' ') + ":  " + lastOut1.Split()[2]);
                f.WriteLine("");

                f.WriteLine("<b><14>" + subtitle2 + ":");
                f.WriteLine("");
                f.WriteLine("Average Among Branches".PadRight(30, ' ') + ":  " + out4);
                f.WriteLine("Lowest".PadRight(30, ' ') + ":  " + out5);
                f.WriteLine("Highest".PadRight(30, ' ') + ":  " + out6);
                f.WriteLine("<b>Total Transaction".PadRight(33, ' ') + ":  " + lastOut2.Split()[2]);
                f.WriteLine("");

                f.WriteLine("<b><14>" + subtitle3 + ":");
                f.WriteLine("");
                f.WriteLine("Sales Changes (in %)".PadRight(30, ' ') + ":  " + out7);
                f.WriteLine("Revenue Changes (in %)".PadRight(30, ' ') + ":  " + out8);
                f.WriteLine("");
            }
            else
            {
                f.WriteLine("Total from Pets".PadRight(30, ' ') + ":  " + out1);
                f.WriteLine("Total from Cages".PadRight(30, ' ') + ":  " + out2);
                f.WriteLine("Total from Treatments".PadRight(30, ' ') + ":  " + out3);
                f.WriteLine("<b>Total Revenue".PadRight(33, ' ') + ":  " + lastOut1.Split()[2]);
                f.WriteLine("");

                f.WriteLine("<b><14>" + subtitle2 + ":");
                f.WriteLine("");
                f.WriteLine("Sales Changes (in %)".PadRight(30, ' ') + ":  " + out4);
                f.WriteLine("Revenue Changes (in %)".PadRight(30, ' ') + ":  " + out5);
                f.WriteLine("<b>Total Transaction".PadRight(33, ' ') + ":  " + lastOut2.Split()[2]);
                f.WriteLine("");

                f.WriteLine("<b><14>" + subtitle3 + ":");
                f.WriteLine("");
                f.WriteLine("Common Pet Type".PadRight(30, ' ') + ":  " + out7);
                f.WriteLine("Most Service Used".PadRight(30, ' ') + ":  " + out8);
                f.WriteLine("Most Treatment Ordered".PadRight(30, ' ') + ":  " + out9);
                f.WriteLine("");
            }

            f.Close();
            CustomPrint p = new CustomPrint(fontType, fileName, 20, 20, 20, 10);
            bool isPrinted = p.SendToPrinter();
            path = p.FileName;
            return isPrinted;
        }
        #endregion
    }
}
