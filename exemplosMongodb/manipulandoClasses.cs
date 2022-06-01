using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace exemplosMongodb
{
    class manipulandoClasses
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            {
                Console.WriteLine("inicio documento LIVRO");
                Livro livro = new Livro();
                livro.Titulo = "Sob a redoma";
                livro.Autor = "Stephen King";
                livro.Ano = 2012;
                livro.Paginas = 679;

                List<string> listaAssuntos = new List<string>();
                listaAssuntos.Add("Ficção Científica");
                listaAssuntos.Add("Terror");
                listaAssuntos.Add("Ação");
                livro.Assunto = listaAssuntos;

                // acesso ao servidor do MongoDB

                string strConexao = "mongodb://localhost:27017";
                IMongoClient cliente = new MongoClient(strConexao);

                // acesso ao banco de dados

                IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

                // acesso a coleção

                IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

                //incluindo documento

                await colecao.InsertOneAsync(livro);
                Console.WriteLine("Documento Incluido");
            }
        }
    }
}
