using FileEngine.DataTypes.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace FileEngine.Shared
{
    [ServiceContract()]

    public interface IFileEngine
    {
        [OperationContract()]
        Tuple<List<Sievo>, List<string>> SortByStartDate();
        [OperationContract()]
        Tuple<List<Sievo>, List<string>> File(string path);
        [OperationContract()]
        Tuple<List<Sievo>, List<string>> Project(int projectID);
        [OperationContract()]
        string GetPath();
        //this contract is written for unit testing (Normally no need to SetPath function when client have a console to set it)
        [OperationContract()]
        void SetPath(string path);// Unit test calls the path

    }
}