using FileEngine.DataTypes.Abstract;
using FileEngine.DataTypes.Concrete.Enums;
using System;

namespace FileEngine.DataTypes.Concrete.Entities
{
    public class Sievo : TEntity
    {
        public Sievo()
        {

        }
        public int ProjectID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Category { get; set; }
        public string Responsible { get; set; }
        public decimal? SavingsAmount { get; set; }
        public string Currency { get; set; }
        public Complexity Complexity { get; set; }


    }
}