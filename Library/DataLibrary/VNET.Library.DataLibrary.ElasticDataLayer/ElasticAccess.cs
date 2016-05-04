using Nest;
using System;
using VNET.Library.DataLibrary.ElasticDataLayer.Interfaces;

namespace VNET.Library.DataLibrary.ElasticDataLayer
{
    public class ElasticAccess : IElasticAccess
    {
        private readonly string _elasticServerUrl;
        private ElasticClient _elasticClient;
        private string _indexName;
        private string _applicationName;

        public ElasticAccess(string elasticServerUrl, string indexName, string applicationName)
        {
            _elasticServerUrl = elasticServerUrl;
            _indexName = indexName;
            _applicationName = applicationName;

            GetElasticClient();
        }

        private ElasticClient GetElasticClient()
        {
            var node = new Uri(_elasticServerUrl);

            var settings = new ConnectionSettings(
                node,
                defaultIndex: _indexName
            );

            return _elasticClient = new ElasticClient(settings);
        }

        public void DeleteIndex(string indexName)
        {
            var result = _elasticClient.DeleteIndex(indexName);
        }

        public void DeleteDocument(string typeName, string id)
        {
            var req = new DeleteRequest(_indexName, typeName, id);

            _elasticClient.Delete(req);
        }

        public void CreateDocument(string typeName, object document)
        {
            var result = _elasticClient.Index(document, p => p
                    .Index(_indexName)
                    .Type(typeName)
                    .Refresh()
                    .Id(Guid.NewGuid().ToString())
                    );

        }
    }
}
