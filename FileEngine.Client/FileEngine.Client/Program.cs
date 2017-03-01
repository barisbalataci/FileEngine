using FileEngine.Client.Helper;
using FileEngine.DataTypes.Concrete.Entities;
using FileEngine.Shared;
using System;
using System.Collections.Generic;

namespace FileEngine.Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            string _path = WcfHelper<IFileEngine>.CreateChannel().GetPath();
            Tuple<List<Sievo>, List<string>> tupleData = null;
            try
            {
                // Necessary argument controls
                if (args.Length != 0)
                {
                    if (args.Length == 1)
                    {
                        if (args[0] == "SortByStartDate")
                        {
                            if (string.IsNullOrEmpty(_path))
                            {
                                Console.WriteLine("First File <Path> command must be executed!");
                                return;
                            }
                            else tupleData = WcfHelper<IFileEngine>.CreateChannel().SortByStartDate();
                        }
                        else if (args[0] == "File")
                        {
                            Console.WriteLine("This command needs a <path> argument!");
                            return;
                        }
                        else if (args[0] == "Project")
                        {
                            Console.WriteLine("This command needs a <ID> argument!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Undefined Command!");
                            return;
                        }
                    }
                    else if (args.Length == 2)
                    {
                        if (args[0] == "File")
                        {
                            tupleData = WcfHelper<IFileEngine>.CreateChannel().File(args[1]);
                            _path = WcfHelper<IFileEngine>.CreateChannel().GetPath();
                        }
                        else if (args[0] == "Project")
                        {
                            if (string.IsNullOrEmpty(_path))
                            {
                                Console.WriteLine("First File <Path> command must be executed!");
                                return;
                            }
                            else tupleData = WcfHelper<IFileEngine>.CreateChannel().Project(int.Parse(args[1]));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unsupported command!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Necessary commands for this program : File <path>, SortByStartDate, Project <id>");
                    return;
                }

                WriteToConSole(tupleData);

            }
            catch (Exception e)
            {

                Console.Write(e.Message + "\nPress any key to exit.");

            }


        }
        //The WriteToConSole function is used for giving the final output related with the commands
        private static void WriteToConSole(Tuple<List<Sievo>, List<string>> tupleData)
        {
            tupleData.Item2.ForEach(o =>
            {
                Console.Write(o + "\t");
            });
            Console.Write("\n");
            tupleData.Item1.ForEach(row =>
            {
                tupleData.Item2.ForEach(col =>
                {
                    if (col == "Project") Console.Write(row.ProjectID + "\t");
                    else if (col == "Description") Console.Write(row.Description + "\t");
                    else if (col == "Start date") Console.Write(row.StartDate.ToString("MM/dd/yyyy HH:mm:ss.fff") + "\t");
                    else if (col == "Category") Console.Write(row.Category + "\t");
                    else if (col == "Responsible") Console.Write(row.Responsible + "\t");
                    else if (col == "Savings amount") Console.Write(row.SavingsAmount == null ? string.Empty + "\t"
                        : row.SavingsAmount.ToString().Replace(',', '.') + "\t");
                    else if (col == "Currency") Console.Write(string.IsNullOrEmpty(row.Currency) ? string.Empty + "\t" : row.Currency + "\t");
                    else if (col == "Complexity") Console.Write(row.Complexity + "\t");

                });

                Console.Write("\n");
            });
        }
    }
}
