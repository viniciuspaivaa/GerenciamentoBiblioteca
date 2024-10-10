// public class Admins
// {
//     List<Admins> admins = new List<Admins>();

//     public string NomeAdm {get; set;}
//     public string SenhaAdm {get; set;}

//     public void CriarNovoAdm(string nomeAdm, string senhaAdm)
//     {
//         admins.Add(new Admins{NomeAdm = nomeAdm, SenhaAdm = senhaAdm});
//         Console.Write("Novo administrador criado!");
//     }
// }

// // public class Usuarios
// // {
// //     List<Usuarios> usuarios = new List<Usuarios>();

// //     public string Nome {get; set;}
// //     public string Senha {get; set;}
// //     private List<string> LivrosEmprestados {get; set;} = new List<string>();

// //     public void CriarNovoUsuario(string nome, string senha)
// //     {
// //         usuarios.Add(new Usuarios{Nome = nome, Senha = senha});
// //         Console.Write("Novo Usuário criado!");
// //     }

// //     public void Emprestar(string livroEmprestado)
// //     {
// //         LivrosEmprestados.Add(livroEmprestado);
// //         Console.Write($"Livro {livroEmprestado} emprestado ao usuário {}");
// //     }
// // }

// // public class Livros
// // {
// //     public string Titulo {get; set;}
// //     public string Autor {get; set;}
// //     public string Genero {get; set;}
// //     public int Qntd {get; set;}

// //     public Livros(string titulo, string autor, string genero, int qntd = 1)
// //     {
// //         Titulo = titulo;
// //         Autor = autor;
// //         Genero = genero;
// //         Qntd = qntd;
// //     }
// // }

// // public class Biblioteca
// // {
// //     private List<Livros> livros = new List<Livros>(); 
// //     private List<Livros> livrosEmprestados = new List<Livros>();

// //     public void AdicionarLivros(string titulo, string autor, string genero)
// //     {
// //         Livros livroExistente = livros.Find(l => l.Titulo == titulo);

// //         if(livroExistente != null)
// //         {
// //             Console.Write($"Livro {titulo} já existente na biblioteca, adicionando mais um à sua quantidade");
// //             livroExistente.Qntd += 1;
// //         }
// //         else
// //         {
// //             Livros novoLivro = new Livros(titulo, autor, genero);
// //             livros.Add(novoLivro);
// //             Console.Write($"Livro {titulo} adicionado à biblioteca!");
// //         }
// //     }

// //     public void EmprestarLivros(string titulo, )
// //     {
// //         Livros livroExistente = livros.Find(l => l.Titulo == titulo);

// //         if(livroExistente != null && livroExistente.Qntd > 1)
// //         {
// //             livroExistente.Qntd -= 1;
// //             livrosEmprestados.Add(livroExistente);
// //         }
// //         else if(livroExistente != null && livroExistente.Qntd == 1)
// //         {
// //             livros.Remove(livroExistente);
// //             livrosEmprestados.Add(livroExistente);
// //         }
// //         else
// //         {
// //             Console.Write("A biblioteca não possui este livro!");
// //         }
// //     }

// //     public void ExibirLivros()
// //     {
// //         foreach(var livro in livros)
// //         {
// //             Console.WriteLine($"Nome: {livro.Titulo}\nAutor: {livro.Autor}\nGênero: {livro.Genero}\nQuantidade na estante: {livro.Qntd}\n");
// //         }
// //     }
// // }

// class Program
// {
//     static void Main(string[] args)
//     {
//         int opcao;
//         bool adm = false;
//         string usuarioAtual = adm ? "administrador" : "usuário";

//         //CLASSE USUÁRIO
//         //AdicionarUsuário
//         //ExibirUsuarios
//         //ExibirLivrosEmprestados
//         //EmprestarLivro

//         //CLASSE LIVROS
//         //ExibirLivros
//         //AdicionarLivro

//         //MENU SWITCH CASE:
//         //1. Trocar de conta
//         //3. Pegar livro emprestado
//         //2. Exibir livros
//         //4. Adicionar livro



//         do
//         {
//             Console.Write($"Bem-vindo {usuarioAtual}");
//             Console.Write("");

//             while(!int.TryParse(Console.ReadLine(), out opcao) && opcao > 4)
//             {

//             }

//         }
//         while(opcao != 0);



//     }
// }




using System;
using System.Collections.Generic;
using System.Threading;

class Livro
{
    public List<Livro> livros = new List<Livro>();

    public string Titulo {get; set;}
    public string Autor {get; set;}
    public string Genero {get; set;}
    public int Quantidade {get; set;}

    public Livro(string titulo, string autor, string genero, int quantidade)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Quantidade = quantidade;
    }

    public void AdicionarLivro(string titulo, string autor, string genero, int quantidade)
    {
        Livro livroExistente = livros.Find(l => l.Titulo == titulo);

        if(livroExistente != null)
        {
            Console.Write("Você já possui este livro, adicionando a nova quantidade.");
            livroExistente.Quantidade += quantidade;
        }
        else
        {
            livros.Add(new Livro(titulo, autor, genero, quantidade));
            Console.Write("Livro adicionado com sucesso!");
        }
    }
}


class Usuario
{
    public string Nome {get; set;}
    public string Autor {get; set;}
    public List<string> LivrosEmprestados {get; set;} = new List<string>();
}


class Administrador
{
    public string NomeAdministrador {get; set;}
    public string SenhaAdministrador {get; set;}
}


class Program
{
    static void Main(string[] args)
    {
        int opcao;
        bool administrador = true;
        string permissao = administrador ? "administrador" : "usuario";

        do
        {
            Console.Write($"Bem-vindo {permissao}");
            Console.Write("1. Adicionar livro\n2. Exibir livros\n3. Emprestar livro\n4. Devolver livro\n0. Sair");
            Console.Write("Digite o que deseja: ");

            while(!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 4)
            {
                Console.Write("Número inválido! Tente novamente: ");
            }

            switch(opcao)
            {
                case 1:
                    if(!administrador)
                    {
                        Console.Write("Você não possui acesso como administrador!");
                    }
                    else
                    {
                        Console.Write("Digite o título do livro: ");
                        string t = Console.ReadLine();

                        Console.Write("Digite o autor do livro: ");
                        string a = Console.ReadLine();

                        Console.Write("Digite o gênero do livro: ");
                        string g = Console.ReadLine();

                        Console.Write("Digite a quantidade adicionada deste livro: ");
                        if(!int.TryParse(Console.ReadLine(), out int q))
                        {
                            Console.Write("Número inválido!");
                        }
                        
                        livros.AdicionarLivro(t, a, g, q);
                    }
                    break;
                case 2:
                    //ExibirLivros();
                    break;
                case 3:
                    //EmprestarLivro();
                    break;
                case 4:
                    //DevolverLivro();
                    break;
                case 0:
                    Console.Write("Saindo...");
                    Thread.Sleep(2000);
                    break;
                default:
                    Console.WriteLine("Erro inesperado!");
                    goto case 0;
            }
        }
        while(opcao != 0);
    }
}