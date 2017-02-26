using FileEngine.DataTypes.Concrete.Entities;
using FileEngine.DataTypes.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FileEngine.DataAccess.Concrete
{
    public class FileReader<T>
    {
        private static string[] columnOrder;


        public static Tuple<List<T>, List<string>> ReadFromFileByType(Type entity, string path)
        {
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
            if (entity.Name == "Sievo")
            {
                List<Sievo> listSievo = new List<Sievo>();

                int row = 0;
                try
                {
                    foreach (string line in File.ReadLines(path))
                    {

                        if (!line.StartsWith("/*") && !line.StartsWith("#"))
                        {
                            row++;
                            string[] splitContent = line.Split("\t".ToCharArray());
                            if (row == 1)
                            {
                                columnOrder = splitContent;
                            }
                            else if (row > 1)
                            {
                                Sievo s = new Sievo();
                                for (int i = 0; i < splitContent.Length; i++)
                                {

                                    if (columnOrder[i].ToString() == "Project") s.ProjectID = Convert.ToInt16(splitContent[i]);
                                    else if (columnOrder[i].ToString() == "Description") s.Description = splitContent[i];
                                    else if (columnOrder[i].ToString() == "Start date")
                                    {
                                        DateTime value;
                                        if (DateTime.TryParse(splitContent[i], out value)) s.StartDate = value;
                                        else throw new Exception("Start Date Format is invalid.");
                                    }
                                    else if (columnOrder[i].ToString() == "Category") s.Category = splitContent[i];
                                    else if (columnOrder[i].ToString() == "Responsible") s.Responsible = splitContent[i];
                                    else if (columnOrder[i].ToString() == "Savings amount")
                                    {
                                        decimal result;
                                        if (splitContent[i] == "NULL") s.SavingsAmount = null;
                                        else
                                        {
                                            if (decimal.TryParse(splitContent[i], NumberStyles.AllowDecimalPoint, provider, out result))
                                                s.SavingsAmount = result;
                                            else throw new Exception("Savings Amount Format is invalid.");
                                        }

                                    }
                                    else if (columnOrder[i].ToString() == "Currency") s.Currency = splitContent[i];
                                    else if (columnOrder[i].ToString() == "Complexity")
                                    {
                                        if (splitContent[i] == "Hazardous")
                                            s.Complexity = Complexity.Hazardous;
                                        else if (splitContent[i] == "Moderate")
                                            s.Complexity = Complexity.Moderate;
                                        else if (splitContent[i] == "Simple")
                                            s.Complexity = Complexity.Simple;
                                        else
                                            throw new Exception("Given complexity value is not in the list");
                                    }

                                }

                                listSievo.Add(s);

                            }
                        }
                    }
                    return Tuple.Create(listSievo.Cast<T>().ToList(), columnOrder.ToList());
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                return null;
            }

        }
    }
}