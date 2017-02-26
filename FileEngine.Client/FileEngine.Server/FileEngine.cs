using System.Collections.Generic;
using System.Linq;
using System;
using FileEngine.Server.DependencyInjection;
using System.IO;
using System.ServiceModel;
using FileEngine.Shared;
using FileEngine.DataAccess.Abstract;
using FileEngine.DataTypes.Concrete.Entities;

namespace FileEngine.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FileEngine : IFileEngine
    {
        private readonly IDataService<Sievo> _dataService;
        private string _path;
        public FileEngine()
        {
            _dataService = InstanceFactory<IDataService<Sievo>>.GetInstance();
        }

        public string Path
        {
            get
            {
                if (_path != null) return _path;
                else return null;
            }
            set
            {
                _path = value;
            }
        }

        public Tuple<List<Sievo>, List<string>> ReadFile(string path)
        {
            try
            {
                this.Path = path;
                return _dataService.ReadFromFile(this.Path);
            }
            catch (FileNotFoundException e)
            {
                this.Path = null;
                throw new FaultException(e.Message);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }



        }
        public Tuple<List<Sievo>, List<string>> Project(int projectID)
        {
            try
            {
                return _dataService.ReadFromFile(this.Path,
                       filter: x => x.ProjectID == projectID
                       );
            }
            catch (Exception)
            {
                throw;

            }
        }


        public Tuple<List<Sievo>, List<string>> SortByStartDate()
        {
            return _dataService.ReadFromFile(this.Path,
                orderBy: o => o.OrderBy(s => s.StartDate)
                );
        }

        public string GetPath()
        {
            return Path;
        }
    }
}
