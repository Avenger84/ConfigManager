using System;
using System.Data;
namespace VNET.Library.DataLibrary.SqlDataLayer.Interfaces
{
    public interface ISqlAccess:IDisposable
    {
        System.Data.DataSet ExecuteDataSet(string query);
        void ExecuteNonQuery(string query);
        void ExecuteNonQuery(string query, params System.Data.SqlClient.SqlParameter[] parameters);
        object ExecuteScalar(string query);
        object ExecuteScalar(string query, params System.Data.SqlClient.SqlParameter[] parameters);
        DataTable GetDataTable(string query);
        DataTable GetDataTable(string query, params System.Data.SqlClient.SqlParameter[] parameters);
        DataTable GetDataTableSP(string spName, params System.Data.SqlClient.SqlParameter[] parameters);
    }
}
