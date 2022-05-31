using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongodb
{
    class acessandoMongodb
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            var doc = new BsonDocument
            {
                {"Título", "Guerra dos Tronos"},
                {"Autor", "George R R Martin"},
                {"Ano", 1999},
                {"Páginas", 856}
            };

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);

            Console.WriteLine(doc);

            //acesso ao servidor Mongodb
            string strConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(strConexao);

            //acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso colecao
            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("Livros");

            //inclusao de documento
            await colecao.InsertOneAsync(doc);

            Console.WriteLine("Documento incluido com sucesso");

        }
    }
}
