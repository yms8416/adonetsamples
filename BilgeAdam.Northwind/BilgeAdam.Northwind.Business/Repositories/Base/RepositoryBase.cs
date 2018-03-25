using BilgeAdam.Northwind.Business.Connection;
using System.Data.SqlClient;

namespace BilgeAdam.Northwind.Business.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase()
        {
            Connection = DataConnection.Connect();
        }
        protected SqlConnection Connection { get; set; }
    }
}