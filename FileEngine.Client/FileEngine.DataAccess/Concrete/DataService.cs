using FileEngine.DataAccess.Abstract;
using FileEngine.DataTypes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FileEngine.DataAccess.Concrete
{
    public class DataService<T> : IDataService<T>
        where T : TEntity
    {

        //This function is generic so whatever the file type is it can read the file 
        //apply the filter
        public Tuple<List<T>, List<string>> ReadFromFile(string path,
         Expression<Func<T, bool>> filter,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {

            if (string.IsNullOrEmpty(path)) return null;

            Tuple<List<T>, List<string>> entityTuple = FileReader<T>.ReadFromFileByType(typeof(T), path);
            IQueryable<T> query = entityTuple.Item1.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return Tuple.Create(query.ToList(), entityTuple.Item2);

        }
        public void WriteToFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
