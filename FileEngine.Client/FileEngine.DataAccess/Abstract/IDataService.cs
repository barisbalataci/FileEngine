using FileEngine.DataTypes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FileEngine.DataAccess.Abstract
{
    //This interface is the only binding point of this layer from outer layer
    public interface IDataService<T> where T : TEntity
    {
        Tuple<List<T>, List<string>> ReadFromFile(string path, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        void WriteToFile(string path);


    }
}
