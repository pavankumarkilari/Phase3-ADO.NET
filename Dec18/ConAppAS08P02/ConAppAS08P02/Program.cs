using System;
using System.Data;

namespace ConAppAS08P02
{
    internal class Program
    {
        static DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PId", typeof(int));
            dt.Columns.Add("PName", typeof(string));
            dt.Columns.Add("PPrice", typeof(double));
            dt.Columns.Add("MnfDate", typeof(DateTime));
            dt.Columns.Add("ExpDate", typeof(DateTime));
            dt.PrimaryKey = new DataColumn[]
            { dt.Columns["PId"] };

            return dt;

        }
        static void Insert(DataTable dt, int id, string pn, double price, DateTime mnf, DateTime exp)
        {
            DataRow dr = dt.NewRow();
            dr["PId"] = id;
            dr["PName"] = pn;
            dr["PPrice"] = price;
            dr["MnfDate"] = mnf;
            dr["ExpDate"] = exp;
            dt.Rows.Add(dr);
            Console.WriteLine($"Record inserted for ID{id}!!!!");

        }

        static void Update(DataTable dt, int id, string pn, double price, DateTime mnf, DateTime exp)
        {
            DataRow updateRow = dt.Rows.Find(id);
            if (updateRow != null)
            {
                updateRow["PName"] = pn;
                updateRow["PPrice"] = price;
                updateRow["MnfDate"] = mnf;
                updateRow["ExpDate"] = exp;
            }
            else
            {
                Console.WriteLine($"No such Id{id} exist");
            }
        }

        static void Delete(DataTable dt, int id)
        {
            DataRow delRow = dt.Rows.Find(id);
            if (delRow == null)
            {
                Console.WriteLine($"No such Id {id} exist");
            }
            else
            {
                dt.Rows.Remove(delRow);
                Console.WriteLine($"Record with Id{id} deleted from Table");
            }
        }

        static void Search(DataTable dt, int id)
        {
            DataRow foundRow = dt.Rows.Find(id);
            if (foundRow == null)
            {
                Console.WriteLine($"No such Id {id} exist");
            }
            else
            {
                Console.WriteLine("Record Found details as follows");
                Console.WriteLine($"PId: \t {foundRow["PId"]}");
                Console.WriteLine($"Product Name: \t {foundRow["PName"]}");
                Console.WriteLine($"Product Price: \t {foundRow["PPrice"]}");
                Console.WriteLine($"Manufacturing Date: \t {foundRow["MnfDate"]}");
                Console.WriteLine($"Expiry Date: \t {foundRow["ExpDate"]}");
            }
        }

        static void Display(DataTable dt)
        {
            Console.WriteLine("Stored current data in table");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("PId: \t" + row["PId"]);
                Console.WriteLine("Product Name: \t" + row["PName"]);
                Console.WriteLine("Product Price: \t" + row["PPrice"]);
                Console.WriteLine("Manufacturing Date: \t" + row["MnfDate"]);
                Console.WriteLine("Expiry Date: \t" + row["ExpDate"]);
                Console.WriteLine("------------------------------------------");
            }
        }

        static void Main(String[] args)
        {
            //insert
            DataTable dt = Create();
            Insert(dt, 101, "Laptop", 25000.80, new DateTime(day: 12, month: 04, year: 2018), new DateTime(day: 06, month: 04, year: 2025));
            Insert(dt, 102, "Mobile", 12000.80, new DateTime(day: 04, month: 12, year: 2021), new DateTime(day: 04, month: 12, year: 2027));
            Insert(dt, 103, "Smart Watch", 2500.99, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 11, month: 12, year: 2024));
            Insert(dt, 104, "Earphones", 1000.30, new DateTime(day: 25, month: 01, year: 2020), new DateTime(day: 24, month: 01, year: 2021));
            Insert(dt, 105, "Charger", 1400.30, new DateTime(day: 07, month: 06, year: 2018), new DateTime(day: 05, month: 07, year: 2022));
            Display(dt);

            //Update
            Console.WriteLine("Enter Id to update the data Row");
            int uId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Product Name");
            string newPName = Console.ReadLine();
            Console.WriteLine("Enter New Product price");
            double newPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Manufacturing date");
            DateTime newMnf = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Expiry date");
            DateTime newExp = DateTime.Parse(Console.ReadLine());
            Update(dt, uId, newPName, newPrice, newMnf, newExp);
            Console.WriteLine("**** After update method call ****");
            Display(dt);


            //Delete
            Console.WriteLine("Enter Id to delete the data Row");
            int DelId = int.Parse(Console.ReadLine());
            Delete(dt, DelId);
            Console.WriteLine("Aftre Delete method call Table \n");
            Display(dt);

            //Search
            Console.WriteLine("Enter Id to search the data row");
            int sId = int.Parse(Console.ReadLine());
            Search(dt, sId);

            Console.ReadKey();
        }
    }
}