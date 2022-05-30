using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace exemploMongoDB
{
    class manipulandoDocumentos
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
                {"Ano", "1999"},
                {"Páginas", "856"}
            };

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);

            Console.WriteLine(doc);
        }
    }
}