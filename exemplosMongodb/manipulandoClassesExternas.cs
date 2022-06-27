using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;


namespace exemplosMongodb
{
    class manipulandoClassesExternas
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
                Livro livro = new Livro();
                livro.Titulo = "Star Wars Legends";
                livro.Autor = "Timothy Zahn";
                livro.Ano = 2010;
                livro.Paginas = 245;
                List<string> lista_Assuntos = new List<string>();
                lista_Assuntos.Add("Ficção Científica");
                lista_Assuntos.Add("Ação");
                livro.Assunto = lista_Assuntos;

                //Acessando através da classe de conexão
                var conexaoBiblioteca = new conectandoMongoDB();

                //incluindo documento

                await conexaoBiblioteca.Livros.InsertOneAsync(livro);
                Console.WriteLine("Documento Incluido");
            }
        }
    }
}
