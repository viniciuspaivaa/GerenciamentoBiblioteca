using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Usuario
{
    public string Nome {get; set;}
    public string Senha {get; set;}
    public List<string> LivrosEmprestados {get; set;} = new List<string>();
    public static List<Usuario> usuarios = new List<Usuario>();

    public Usuario()
    {
        usuarios = new List<Usuario>();
    }    

    public Usuario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    public void AdicionarUsuario(string nome, string senha)
    {
        usuarios = new List<Usuario>();
        usuarios.Add(new Usuario(nome, senha));
        Console.Clear();
        Console.WriteLine("Usuário cadastrado com sucesso!\n");
    }

    public void ExibirUsuarios()
    {
        Console.Clear();
        foreach(var usuario in usuarios)
        {
            Console.WriteLine($"Nome: {usuario.Nome}\n");
            foreach(string emprestados in LivrosEmprestados)
            {
                Console.WriteLine($"Emprestados: {emprestados}");
            }
            Console.Write("\n");
        }
    }

    public static List<Usuario> ProcurarUsuarios()
    {
        return usuarios;
    }
}

class Livro
{
    public string Titulo {get; set;}
    public string Autor {get; set;}
    public string Genero {get; set;}
    public int Quantidade {get; set;}
    List<Livro> livros;
    Livro livroExistente;

    public Livro()
    {
        livros = new List<Livro>();
    }

    public Livro(string titulo, string autor, string genero, int quantidade)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Quantidade = quantidade;
    }

    public void ExibirLivros()
    {
        Console.Clear();
        foreach(var livro in livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}\nAutor: {livro.Autor}\nGênero: {livro.Genero}\nQuantidade disponível: {livro.Quantidade}\n");
        }
    }

    public void EmprestarLivro(string titulo, string usuario)
    {
        livroExistente = livros.Find(l => l.Titulo == titulo);
        Usuario usuarioExistente = Usuario.ProcurarUsuarios().Find(u => u.Nome == usuario);
        Console.Write(usuarioExistente);

        if(livroExistente != null)
        {
            if(usuarioExistente.LivrosEmprestados.Count >= 3)
            {
                Console.Clear();
                Console.Write("Usuário já atingiu o limite de 3 livros emprestados!");
                return;
            }

            if(livroExistente.Quantidade == 0)
            {
                Console.Clear();
                Console.WriteLine("Todas cópias já emprestadas!\n");
                return;
            }

            if(usuarioExistente == null)
            {
                Console.Clear();
                Console.WriteLine("Usuário inexistente!");
                return;
            }

            usuarioExistente.LivrosEmprestados.Add(livroExistente.Titulo);
            livroExistente.Quantidade -= 1;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Você não possui este livro para emprestar!\n");
        }
    }

    public void AdicionarLivro(string titulo, string autor, string genero, int quantidade)
    {
        livroExistente = livros.Find(l => l.Titulo == titulo);

        if(livroExistente != null)
        {
            Console.Clear();
            Console.WriteLine("Você já possui este livro, adicionando a nova quantidade.\n");
            livroExistente.Quantidade += quantidade;
        }
        else
        {
            livros.Add(new Livro(titulo, autor, genero, quantidade));
            Console.Clear();
            Console.WriteLine("Livro adicionado com sucesso!\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Livro livros = new Livro();
        Usuario usuarios = new Usuario();
        int opcao;
        bool administrador = true;
        string permissao = administrador ? "administrador" : "usuario";

        do
        {
            Console.WriteLine($"Bem-vindo {permissao}\n");
            Console.Write("1. Exibir livros\n2. Emprestar livro\n3. Devolver livro\n4. Livros emprestados\n5. Cadastrar usuario\n6. Usuários cadastrados\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("7. Adicionar livro\n");
            Console.ResetColor();

            Console.Write("0.Sair\n\nDigite o que deseja: ");

            while(!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 7)
            {
                Console.Write("Número inválido! Tente novamente: ");
            }

            switch(opcao)
            {
                case 1:
                    livros.ExibirLivros();
                    break;
                case 2:
                    Console.Write("Digite o livro deseja emprestar: ");
                    string tituloLivro = Console.ReadLine().ToLower();

                    Console.Write("Digite o usuario que o livro será emprestado: ");
                    string nomeUsuario = Console.ReadLine().ToLower();
                    
                    livros.EmprestarLivro(tituloLivro, nomeUsuario);
                    break;
                case 3:
                    //DevolverLivro();
                    break;
                case 4:
                    //LivrosEmprestados();
                    break;
                case 5:
                    Console.Write("Digite o nome do novo usuário: ");
                    string usuario = Console.ReadLine().ToLower();

                    Console.Write("Digite a senha: ");
                    string senha = Console.ReadLine();

                    usuarios.AdicionarUsuario(usuario, senha);
                    break;
                case 6:
                    usuarios.ExibirUsuarios();
                    break;
                case 7:
                    if(!administrador)
                    {
                        Console.Clear();
                        Console.WriteLine("\nVocê não possui acesso como administrador!\n");
                    }
                    else
                    {
                        Console.Write("Digite o título do livro: ");
                        string t = Console.ReadLine().ToLower();

                        Console.Write("Digite o autor do livro: ");
                        string a = Console.ReadLine().ToLower();

                        Console.Write("Digite o gênero do livro: ");
                        string g = Console.ReadLine().ToLower();

                        Console.Write("Digite a quantidade adicionada deste livro: ");
                        if(!int.TryParse(Console.ReadLine(), out int q))
                        {
                            Console.Write("Número inválido!");
                        }
                        
                        livros.AdicionarLivro(t, a, g, q);
                    }
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
