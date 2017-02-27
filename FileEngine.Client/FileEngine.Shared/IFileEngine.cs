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
        Tuple<List<Sievo>, List<string>> File(string path);
        [OperationContract()]
        Tuple<List<Sievo>, List<string>> Project(int projectID);
        [OperationContract()]
        string GetPath();
        [OperationContract()]//this contract is written for the use of unit testing
        void SetPath(string path);

    }
}