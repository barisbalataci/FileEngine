using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileEngine.DataTypes.Concrete.Entities;
using System.Collections.Generic;
using System.Globalization;
using FileEngine.Server;

namespace FileEngine.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void File_Engine_Server_Project_Test()
        {
            string path = @"c:\calisma\sievo\sievo.txt";
            int projectID = 2;
            
            Sievo sievo = new Sievo()
            {
                ProjectID = 2,
                Description = "Harmonize Lactobacillus acidophilus sourcing",
                StartDate = DateTime.Parse("2014-01-01 00:00:00.005", CultureInfo.CreateSpecificCulture("en-US")),
                Category = "Dairy",
                Responsible = "Daisy Milks",
                SavingsAmount = null,
                Currency = null,
                Complexity = DataTypes.Concrete.Enums.Complexity.Simple

            };

            List<Sievo> sievoList = new List<Sievo>();
            sievoList.Add(sievo);
            List<string> columnOrder = new List<string>()
            {
                "Project", "Description", "Start date",  "Category",    "Responsible", "Savings amount",  "Currency",    "Complexity"
            };

            Tuple<List<Sievo>, List<string>> expectedTuple = Tuple.Create(sievoList, columnOrder);
            Server.FileEngine fileEngine = new Server.FileEngine();
            fileEngine.SetPath(path);
            Tuple<List<Sievo>, List<string>> actualTuple = fileEngine.Project(projectID);


           
            Assert.AreEqual(expectedTuple.Item1[0].Description, actualTuple.Item1[0].Description);
            Assert.AreEqual(expectedTuple.Item1[0].Category, actualTuple.Item1[0].Category);
            Assert.AreEqual(expectedTuple.Item1[0].Responsible, actualTuple.Item1[0].Responsible);
            Assert.AreEqual(expectedTuple.Item1[0].Currency, actualTuple.Item1[0].Currency);
            Assert.AreEqual(expectedTuple.Item1[0].ProjectID, actualTuple.Item1[0].ProjectID);
            Assert.AreEqual(expectedTuple.Item1[0].Complexity, actualTuple.Item1[0].Complexity);
            Assert.AreEqual(expectedTuple.Item1[0].SavingsAmount, actualTuple.Item1[0].SavingsAmount);
            Assert.AreEqual(expectedTuple.Item1[0].StartDate, actualTuple.Item1[0].StartDate);


            Assert.AreEqual(expectedTuple.Item2[0].ToString(), actualTuple.Item2[0].ToString());
            Assert.AreEqual(expectedTuple.Item2[1].ToString(), actualTuple.Item2[1].ToString());
            Assert.AreEqual(expectedTuple.Item2[2].ToString(), actualTuple.Item2[2].ToString());
            Assert.AreEqual(expectedTuple.Item2[3].ToString(), actualTuple.Item2[3].ToString());
            Assert.AreEqual(expectedTuple.Item2[4].ToString(), actualTuple.Item2[4].ToString());
            Assert.AreEqual(expectedTuple.Item2[5].ToString(), actualTuple.Item2[5].ToString());
            Assert.AreEqual(expectedTuple.Item2[6].ToString(), actualTuple.Item2[6].ToString());
            Assert.AreEqual(expectedTuple.Item2[7].ToString(), actualTuple.Item2[7].ToString());

        }
    }
}
