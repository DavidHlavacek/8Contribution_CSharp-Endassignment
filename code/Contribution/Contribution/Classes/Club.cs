using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace Contribution.Classes
{
    internal static class Club
    {
        #region Fields

        private static float _juniorFee = 75;
        private static float _seniorFee = 150;
        private static float _playingFee = 45;
        private static float _yearsDiscount = 7;
        private static float _percentDiscount = 5;
        private static ArrayList _contracts = new ArrayList();
        //private static List<Contract> _contracts = new List<Contract>
        #endregion

        #region Properties
    
        public static float JuniorFee
        {
            get { return _juniorFee; }
            private set { _juniorFee = value; }
        }

        public static float SeniorFee
        {
            get { return _seniorFee; }
            private set { _seniorFee = value; }
        }

        public static float PlayingFee
        {
            get { return _playingFee; }
            private set { _playingFee = value; }
        }

        public static float YearsDiscount
        {
            get { return _yearsDiscount; }
            private set { _yearsDiscount = value; }
        }

        public static float PercentDiscount
        {
            get { return _percentDiscount; }
            private set { _percentDiscount = value; }
        }

        public static ArrayList Contracts
        {
            get { return _contracts; }
            private set { _contracts = value; }
        }

        #endregion


        #region Methods

        //public static public SaveList()
        //{
        //    try
        //    {
        //        StreamWriter writer = new StreamWriter("contracts.txt");
        //        foreach (Contract c in _contracts)
        //        {
        //            writer.WriteLine(c.Member.Name + "|" + c.Contribution);
        //        }
        //        writer.Close();
        //    }
        //    catch { }
        //}

        //public static public LoadList()
        //{
        //    try
        //    {
        //        _contracts.Clear();
        //        StreamReader reader = new StreamReader("contacts.txt");
        //        string line = reader.ReadLine();
        //        while(line!=null)
        //        {
        //            string[] parts = line.Split('|');
        //            AddContract(parts[0], parts[1]);
        //            line = reader.ReadLine();
        //        }
        //        reader.Close();
        //    }
        //    catch { }
        //}

        public static double TotalContribution()
        {
            double total = 0;
            foreach (Contract contract in Contracts)
            {
                total += contract.Contribution();
            }
            return total;
        }

        public static float AverageMembershipDuration()
        {
            float totalContribution = 0;
            int totalMembers = 0;
            foreach (Contract contract in _contracts)
            {
                totalContribution += contract.MembershipDuration();
                totalMembers++;
            }
            totalContribution = (float)totalContribution / totalMembers;
            return totalContribution;
        }

        public static Member YoungestMember()
        {
            Member youngestMember = null;
            int minAge = int.MaxValue;
            foreach (Contract contract in _contracts)
            {
                int age = contract.MemberAge();
                if (age < minAge)
                {
                    minAge = age;
                    youngestMember = contract.Member;
                }
            }
            return youngestMember;
        }

        public static void AddContract(Contract contract)
        {
            Contracts.Add(contract);

        }

        public static void Populate()
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contribution;MultipleActiveResultSets=True;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Contracts";

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var indexOfColumn1 = reader.GetOrdinal("memberID");
                        Member newMember = null;
                        while (reader.Read())
                        {
                            var value1 = reader.GetValue(indexOfColumn1);

                            using (var command2 = connection.CreateCommand())
                            {
                                command2.CommandText = "SELECT * FROM Members WHERE ID=(@value1)";
                                command2.CommandType = System.Data.CommandType.Text;
                                command2.Parameters.AddWithValue("@value1", value1);
                                command2.ExecuteNonQuery();

                                using (var reader2 = command2.ExecuteReader())
                                {
                                    var column1 = reader2.GetOrdinal("name");
                                    var column2 = reader2.GetOrdinal("birthDate");
                                    var column3 = reader2.GetOrdinal("joinDate");
                                    var column4 = reader2.GetOrdinal("isPlaying");

                                    //MessageBox.Show(value1.ToString());
                                    if (reader2.Read())
                                    {

                                        //string name = dr2.GetString(dr2.GetOrdinal("name"));
                                        //DateTime birthDate = DateTime.ParseExact(dr2.GetString(dr2.GetOrdinal("birthDate")), "dd/MM/yyyy", null);
                                        //DateTime joinDate = DateTime.ParseExact(dr2.GetString(dr.GetOrdinal("joinDate")), "dd/MM/yyyy", null);
                                        //bool isPlaying = (dr2.GetInt32(dr2.GetOrdinal("isPlaying")) == 1 ? true : false);
                                        //newMember = new Member(name, birthDate, joinDate, isPlaying);
                                        //MessageBox.Show(name);
                                        string v1 = reader2.GetValue(column1).ToString();
                                        string v2 = reader2.GetValue(column2).ToString();
                                        string v3 = reader2.GetValue(column3).ToString();
                                        DateTime v22 = DateTime.ParseExact(v2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        DateTime v33 = DateTime.ParseExact(v3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        v22 = v22.Date;
                                        v33 = v33.Date;
                                        bool v4 = (Convert.ToInt32(reader2.GetValue(column4)) == 1);
                                        newMember = new Member(v1, v22.Date, v33.Date, v4);
                                        //MessageBox.Show(newMember.Name);
                                        //MessageBox.Show(newMember.BirthDate.ToString());
                                        //MessageBox.Show(newMember.JoinDate.ToString());
                                        //MessageBox.Show(newMember.IsPlaying.ToString());

                                    }
                                    
                                }
                            }
                            Contract newContract = new Contract(newMember);
                            Club.AddContract(newContract);
                            //MessageBox.Show(newContract.Contribution().ToString());
                            //MessageBox.Show(newContract.MemberAge().ToString());
                            //MessageBox.Show(newContract.MembershipDuration().ToString());
                            

                        }
                       
                    }
                    connection.Close();
                }
            }

        }

        #endregion

    }
}
