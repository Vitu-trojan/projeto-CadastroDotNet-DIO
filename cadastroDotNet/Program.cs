using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDotNet
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string decisao = DecisaoUser();

            while(decisao != "6")
            {
                switch(decisao)
                {
                    case "1":
                        AdicionarAnime();
                        break;

                    case "2":
                        ListarAnimes();
                        break;

                    case "3":
                        AtualizarAnime();
                        break;

                    case "4":
                        VerAnime();
                        break;

                    case "5":
                        DeletarAnime();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                decisao = DecisaoUser();
            }
        }

        private static string DecisaoUser()
        {           
            Console.Clear();
            Console.WriteLine("");
            Ciano();
            Console.Write("---- Bem vindo ao"); Roxo(); Console.Write(" MyNimes!"); Ciano(); Console.Write(" ---- \n");
            Verde();
            Console.WriteLine("\n*Dentro de uma opção do menu, sempre que retornar apenas algum texto\n ( sem o [ -> ] que espera que digite) aperte qualquer tecla para continuar*\n");
            Ciano();
            Console.WriteLine("Escolha a opção que deseja:\n");
            Amarelo();
            Console.WriteLine(" _______________________");
            Console.WriteLine("|Opção|     Descrição   |");
            Console.WriteLine("|-----|-----------------|");
            Verde();
            Console.WriteLine("| [1] | Adicionar anime |");
            Azul();
            Console.WriteLine("| [2] | Listar animes   |");
            Ciano();
            Console.WriteLine("| [3] | Atualizar anime |");
            Cinza();
            Console.WriteLine("| [4] | Info anime      |");
            Roxo();
            Console.WriteLine("| [5] | Deletar anime   |");
            Vermelho();
            Console.WriteLine("| [6] | Sair do menu    |");
            Console.WriteLine("|_____|_________________|");
            Console.WriteLine("\n");

            Ciano();           
            Console.Write("->"); string decisao = Console.ReadLine();
            return decisao;
        }

        private static void AdicionarAnime()
        {
            Console.Clear();
            Roxo();
            Console.WriteLine("--- Adicionar Anime ---\n");
            Azul();
            Console.WriteLine("Categorias:\n");
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Ciano();
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }

            Amarelo();
            Console.WriteLine("\n Escolha uma categoria entre as opções acima e digite seu número:");
            Console.Write(" ->"); int categoriaAnime = int.Parse(Console.ReadLine());          

            Console.WriteLine("\n Digite o nome do anime:");
            Console.Write(" ->"); string nomeAnime = Console.ReadLine();

            Console.WriteLine("\n Digite a descrição do anime:");
            Console.Write(" ->"); string descricaoAnime = Console.ReadLine();

            Console.WriteLine("\n Digite o ano do lançamento do anime");
            Console.Write(" ->"); int anoAnime = int.Parse(Console.ReadLine());

            Anime novoAnime = new Anime(id: repositorio.ProximoId(), categoria: (Categoria)categoriaAnime, nome: nomeAnime, descricao: descricaoAnime, ano: anoAnime);
            repositorio.Insere(novoAnime);

            Console.Clear();
            Verde();
            Console.WriteLine("\n--- Adicionado com sucesso! ---");           
            Console.ReadKey();
        }

        private static void ListarAnimes()
        {
            Console.Clear();
            Roxo();
            Console.WriteLine("--- Lista dos Animes ---\n");
            Lista();

            Console.ReadKey();
        }

        private static void AtualizarAnime()
        {
            Console.Clear();
            Roxo();
            Console.WriteLine("--- Atualizar Anime ---\n");
            Verde();
            Console.WriteLine("Os animes já adicionados são:\n");                        
            
            var lista = ListaVazia();
            if(lista == true)
            {
                return;
            }
            
            Amarelo();
            Console.WriteLine("\nDigite o ID do anime.\nOu digite [X] para voltar para o menu.");
            
            var decisao = ValidarId();
            if(decisao == "sair")
            {
                return;
            }
            var idAnime = int.Parse(decisao);

            Console.Clear();
            Roxo();
            Console.WriteLine("--- Atualizar Anime ---\n");

            Azul();
            Console.WriteLine("\nCategorias:\n");
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Ciano();
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }
            
            Amarelo();
            Console.WriteLine("\n Escolha uma categoria entre as opções acima e digite seu número:");
            Console.Write(" ->"); int categoriaAnime = int.Parse(Console.ReadLine());

            Console.WriteLine("\n Digite o nome do anime:");
            Console.Write(" ->"); string nomeAnime = Console.ReadLine();

            Console.WriteLine("\n Digite a descrição do anime:");
            Console.Write(" ->"); string descricaoAnime = Console.ReadLine();

            Console.WriteLine("\n Digite o ano do lançamento do anime");
            Console.Write(" ->"); int anoAnime = int.Parse(Console.ReadLine());

            Anime atualizarAnime = new Anime(id: idAnime, categoria: (Categoria)categoriaAnime, nome: nomeAnime, descricao: descricaoAnime, ano: anoAnime);
            repositorio.Atualiza(idAnime, atualizarAnime);

            Console.Clear();
            Verde();
            Console.WriteLine("\n--- Atualizado com sucesso! ---");            
            Console.ReadKey();
        }

        private static void VerAnime()
        {
            Console.Clear();
            Roxo();
            Console.WriteLine("--- Ver informações de um anime específico ---\n");
            Verde();
            Console.WriteLine("Animes já adicionados:\n");

            var lista = ListaVazia();
            if(lista == true)
            {
                return;
            }

            Amarelo();
            Console.WriteLine("\nDigite o ID do anime.\nOu digite [X] para voltar para o menu.");
            
            var decisao = ValidarId();
            if(decisao == "sair")
            {
                return;
            }
            var verAnime = int.Parse(decisao);         
            
            var anime = repositorio.RetornarPorId(verAnime);
            Ciano();
            Console.WriteLine();
            Console.WriteLine(anime);
            Console.ReadKey();
        }

        private static void DeletarAnime()
        {
            bool deletar = false;
            while(deletar == false)
            {
                Console.Clear();
                Roxo();
                Console.WriteLine("--- Deletar um anime ---\n");

                Verde();
                Console.WriteLine("Animes já adicionados:\n");

                var lista = ListaVazia();
                if(lista == true)
                {
                    return;
                }

                Amarelo();
                Console.WriteLine("\nDigite o ID do anime.\nOu digite [X] para voltar para o menu.");
            
                var decisao = ValidarId();
                if(decisao == "sair")
                {
                    return;
                }
                var id = int.Parse(decisao);

                bool confirmacao = false;
                while(confirmacao == false)
                {
                    Amarelo();
                    Console.WriteLine("\nConfirme se você quer mesmo deletar este anime:");
                    Verde();Console.Write("[1] - Sim"); Amarelo(); Console.Write(" | "); Vermelho(); Console.WriteLine("[2] - Não\n");
                    Amarelo();
                    Console.Write(" ->");int deletarId = int.Parse(Console.ReadLine());
                    if(deletarId != 1 & deletarId != 2)
                    {
                        Vermelho();
                        Console.WriteLine("Opção inválida.");
                    }

                    else if(deletarId == 1)
                    {
                        repositorio.Exclui(id);
                        Console.Clear();
                        Verde();
                        Console.WriteLine("\n--- Anime deletado com sucesso ---");
                        Console.ReadKey();
                        confirmacao = true;
                        deletar = true;
                    }

                    confirmacao = true;
                }               
            }
        }
        
        private static bool Lista()
        {
            var listar = repositorio.Lista();
            
            if (listar.Count == 0)
            {
                Vermelho();
                Console.WriteLine("Nenhum anime adicionado ainda.");
                return false;
            }
            
            foreach (var anime in listar)
            {
                Ciano();
                var excluido = anime.EstaExcluido();
                Console.WriteLine("#{0} - {1}  {2}", anime.RetornarId(), anime.RetornarNome(), (anime.EstaExcluido() ? "*Excluido*" : ""));
            }
            return true;
        }

        private static bool ListaVazia()
        {
            var algunDado = Lista();
            if(algunDado == false)
            {
                Vermelho();
                Console.WriteLine("\nComo não há animes adicionados, não é possível realizar essa operação.");
                Ciano();
                Console.WriteLine("\nVolte ao menu e adicione um anime primeiro.");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        private static string ValidarId()
        {
            Amarelo();
            Console.Write("->");var decisao = Console.ReadLine();
            if(decisao == "X" | decisao == "x" )
            {
                return "sair";
            }
            var retornar = decisao;
            int idAnime = int.Parse(decisao);
            bool validacao = true;
            int aux1 = 0;
            while(validacao == true)
            {                
                var ids = repositorio.Lista();
                for(var aux = 1; aux <= ids.Count; aux++)
                {
                    foreach(var mesmoId in ids)
                    {     
                        if(idAnime == mesmoId.RetornarId())
                        {                        
                            aux1 = 1;                       
                            break;                            
                        }                                        
                    }
                }
                
                if(aux1 == 1)
                {
                    return retornar;                     
                }

                Vermelho();
                Console.WriteLine("\nO ID digitado não corresponde a nenhum anime listado\n");
                    
                Amarelo();
                Console.WriteLine("\nDigite o ID do anime.\nOu digite [X] para voltar para o menu.");
                Console.Write("->"); var decisao1 = Console.ReadLine();
                if(decisao1 == "X" | decisao1 == "x")
                {
                    break;
                }
                
                retornar = decisao1;
                idAnime = int.Parse(decisao1);
            }

            return "sair";
        }

        private static void Ciano()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;      
        }

        private static void Amarelo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private static void Vermelho()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private static void Verde()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void Roxo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        
        private static void Azul()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        private static void Cinza()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}