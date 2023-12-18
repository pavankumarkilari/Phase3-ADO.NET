using System;
using System.Data.SqlClient;
using System.Data;


namespace ConAppAS07
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static string constr = "server=LAPTOP-T7MCP4KU;database=LibraryDB;trusted_connection=true;";
        static SqlDataAdapter adapter;
        static DataSet ds;
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1.Retrive data into dataset \n 2.Display \n 3.Add new book \n 4.Update Book Quantity");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("select BookId,Title,Author,Genre,Quantity from Books", con);


                                con.Open();
                                adapter = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                adapter.Fill(ds);
                                con.Close();
                                int noBooks = ds.Tables[0].Rows.Count;
                                Console.WriteLine("Number of books are: " + noBooks);
                                Console.WriteLine("BookId \t  Title \t \t   Author \t \t  Genre \t \t  Quantity");
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    Console.Write(dr[0] + "\t ");
                                    Console.Write(dr[1] + "\t \t  ");
                                    Console.Write(dr[2] + "\t \t ");
                                    Console.Write(dr[3] + "\t \t ");
                                    Console.Write(dr[4]);

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
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("Select * from Books", con);
                                adapter = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                adapter.Fill(ds, "Books");
                                con.Close();
                                Console.WriteLine("BookId \t  Title \t \t   Author \t \t  Genre \t \t  Quantity");
                                foreach (DataRow row in ds.Tables["Books"].Rows)
                                {

                                    Console.Write(row[0] + "\t");
                                    Console.Write(row[1] + "\t \t");
                                    Console.Write(row[2] + "\t \t");
                                    Console.Write(row[3] + "\t \t ");
                                    Console.Write(row[4]);

                                    Console.WriteLine("\n");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                Console.ReadKey();
                            }
                            break;
                        }

                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("select * from Books", con);
                                adapter = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                adapter.Fill(ds, "Books");
                                DataTable dt = ds.Tables["Books"];
                                DataRow dr = dt.NewRow();
                                Console.WriteLine("enter book id");
                                dr["BookId"] = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter Book title");
                                dr["Title"] = Console.ReadLine();
                                Console.WriteLine("enter book author");
                                dr["Author"] = (Console.ReadLine());
                                Console.WriteLine("enter book genre");
                                dr["Genre"] = (Console.ReadLine());
                                Console.WriteLine("enter book quantity");
                                dr["Quantity"] = int.Parse(Console.ReadLine());

                                dt.Rows.Add(dr);
                                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds, "Books");
                                Console.WriteLine("Books record inserted !!!");
                                con.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("error!!!" + ex.Message);
                            }
                            finally
                            {
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand("select * from Books", con);
                                adapter = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                adapter.Fill(ds, "Books");
                                Console.WriteLine("Enter book title to update book quantity");
                                string title = Console.ReadLine();
                                DataRow dr = null;
                                foreach (DataRow row in ds.Tables["Books"].Rows)
                                {
                                    if ((string)row["Title"] == title)
                                    {
                                        dr = row;
                                        break;
                                    }
                                }
                                if (dr == null)
                                {
                                    Console.WriteLine($"No such Customer {title} exist in books table");
                                }
                                else
                                {
                                    Console.WriteLine("Enter new Quantity");
                                    dr["Quantity"] = Console.ReadLine();
                                }

                                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds, "Books");
                                Console.WriteLine(" record updated !!!");
                                con.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("error!!!" + ex.Message);
                            }
                            finally
                            {
                                Console.ReadKey();
                            }
                            break;
                        }
                }

                Console.WriteLine("Do you wanna continue press ....y");
                choice = Console.ReadLine();
            } while (choice == "y");

        }
    }
}