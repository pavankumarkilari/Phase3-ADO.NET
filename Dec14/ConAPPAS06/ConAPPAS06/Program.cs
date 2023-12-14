using System;
using System.Data;
using System.Data.SqlClient;

namespace ConAPPAS06
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string connectionString = "Data Source=Laptop-T7MCP4KU; Initial Catalog =ProductInventoryDB; Integrated Security =True";
        static void Main(string[] args)
        {
            string YesOrNot;
            do
            {
                Console.WriteLine("Choose any one of the operation below: ");
                Console.WriteLine("1. Select all records from Products table \n2. Insert a record into Products table \n3. Update Product table \n4. Delete a record from Products table\n");
                int Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(connectionString);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "select * from Products"
                                };
                                con.Open();
                                reader = cmd.ExecuteReader();
                                Console.WriteLine("ProductId \t  ProductName \t  Price \t Quantity \t  MfDate \t   ExpDate");
                                while (reader.Read())
                                {
                                    Console.Write(reader[0] + "\t ");
                                    Console.Write(reader[1] + "\t \t  ");
                                    Console.Write(reader[2] + "\t ");
                                    Console.Write(reader[3] + "\t ");
                                    Console.Write(reader[4] + "\t ");
                                    Console.Write(reader[5]);
                                    Console.Write("\n");

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            break;
                        }



                    case 2:
                        {
                            try
                            {
                                con = new SqlConnection(connectionString);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "insert into Products(ProductId,ProductName,Price,Quantity,MfDate,ExpDate) values(@id,@pname,@price,@quantity,@mfdate,@expdate)"
                                };
                                Console.WriteLine("Enter Product Id:");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                                Console.WriteLine("Enter Product Name: ");
                                cmd.Parameters.AddWithValue("@pname", Console.ReadLine());
                                Console.WriteLine("Enter Price Name: ");
                                cmd.Parameters.AddWithValue("@price", Console.ReadLine());
                                Console.WriteLine("Enter Quantity: ");
                                cmd.Parameters.AddWithValue("@quantity", Console.ReadLine());

                                Console.WriteLine("Enter manufacuring date: ");
                                cmd.Parameters.AddWithValue("@mfdate", Console.ReadLine());
                                Console.WriteLine("Enter Expiry date: ");
                                cmd.Parameters.AddWithValue("@expdate", Console.ReadLine());
                                con.Open();
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("Record Insertion was successful!!!!");


                            }
                            catch (SqlException se)
                            {
                                Console.WriteLine("Server Error!!!" + se.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("End of program");
                                Console.ReadKey();
                            }
                            break;
                        }



                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(connectionString);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "update products set ProductName=@pname,Price=@price,Quantity=@quantity,MfDate=@mfdate,ExpDate=@expdate where ProductId=@id"
                                };
                                Console.WriteLine("enter product id to update the record: ");
                                int id = int.Parse(Console.ReadLine());
                                cmd.Parameters.AddWithValue("@id", id);
                                Console.WriteLine("Enter product new name: ");
                                cmd.Parameters.AddWithValue("@pname", Console.ReadLine());
                                Console.WriteLine("Enter product new price: ");
                                cmd.Parameters.AddWithValue("@price", Console.ReadLine());
                                Console.WriteLine("Enter product new quantity: ");
                                cmd.Parameters.AddWithValue("@quantity", Console.ReadLine());
                                Console.WriteLine("Enter product new mfdate: ");
                                cmd.Parameters.AddWithValue("@mfdate", Console.ReadLine());
                                Console.WriteLine("Enter product new expdate: ");
                                cmd.Parameters.AddWithValue("@expdate", Console.ReadLine());
                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine($"Record update was successful for id {id} !!!");
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("end of program");
                                Console.ReadKey();
                            }
                            break;
                        }



                    case 4:
                        {
                            try
                            {
                                con = new SqlConnection(connectionString);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "Delete from Products where ProductId=@id"
                                };
                                Console.WriteLine("Enter Product Id:");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine("Deletion was Successful!!!!");
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("End of program");
                                Console.ReadKey();
                            }
                            break;
                        }
                }
                Console.Write("Do you wanna continue (yes/no)?");
                YesOrNot = Console.ReadLine();
            } while (YesOrNot == "yes");
        }
    }
}