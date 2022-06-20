using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace exemplosMongodb
{
    class conectandoMongoDB
    {
        public const string STRCONEXAO = "mongodb://localhost:27017";
        public const string NOME_BASE = "Biblioteca";
        public const string COLECAO = "Livros";

        private static IMongoClient _cliente;
        private static IMongoDatabase _BaseDeDados;

        static conectandoMongoDB()
        {
            _cliente = new MongoClient(STRCONEXAO);
            _BaseDeDados = _cliente.GetDatabase(NOME_BASE);
        }

    }
}
