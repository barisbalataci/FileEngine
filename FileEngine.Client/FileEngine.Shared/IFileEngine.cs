using FileEngine.DataTypes.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace FileEngine.Shared
{
    [ServiceContract()]// This satisfies requirements of webservice need. It's optional

    public interface IFileEngine
    {
        [OperationContract()]// This satisfies requirements of webservice need. It's optional
        Tuple<List<Sievo>, List<string>> SortByStartDate();
        [OperationContract()]
        Tuple<List<Sievo>, List<string>> ReadFile(string path);
        [OperationContract()]
        Tuple<List<Sievo>, List<string>> Project(int projectID);
        [OperationContract()]
        string GetPath();

    }
}