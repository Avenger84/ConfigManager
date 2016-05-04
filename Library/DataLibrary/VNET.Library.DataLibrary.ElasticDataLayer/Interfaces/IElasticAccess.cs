using System;
namespace VNET.Library.DataLibrary.ElasticDataLayer.Interfaces
{
    public interface IElasticAccess
    {
        void CreateDocument(string typeName, object document);
        void DeleteDocument(string typeName, string id);
        void DeleteIndex(string indexName);
    }
}
