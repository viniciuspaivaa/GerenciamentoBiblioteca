//Adicionar livro
//Emprestar livro
//Retornar livro
//Consultar biblioteca
//Cadastrar usuário
//Cadastrar administrador

//Classe Usuários
//Classe Admins
//Classe Biblioteca

class Admins
{
    List<Admins> admins = new List<Admins>();

    public string NomeAdm {get; set;}
    public string SenhaAdm {get; set}

    public void NovoAdm(string nomeAdm, string senhaAdm)
    {
        NomeAdm = nomeAdm;
        SenhaAdm = senhaAdm;
    }
}

class Usuarios
{
    List<Usuarios> usuarios = new List<Usuarios>();
    
    public string Nome {get; set;}
    public string Senha {get; set;}
    public int QntdLivros {get; set;}

    public void NovoUsuario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }
}

class Livros
{

    public string Titulo {get; set;}
    public string Autor {get; set;}
    public string Genero {get; set;}
    public int Qntd {get; set;}

}

class Biblioteca
{
    List<Livros> livros = new List<Livros>(); 

    //AdicionarLivros
    //EmprestarLivros

    public void AdicionarLivros(string titulo, string autor, string genero)
    {
        if(livros.Exists(l => l.Titulo == titulo))
        {
            livros.Qntd ++
        }

        Titulo = titulo;
        Autor = autor;
        Genero = genero;
    }

    public void ExibirLivros()
    {
        foreach(var livro in livros)
        {
            Console.WriteLine($"Nome: {livro.Titulo}\nAutor: {livro.Autor}\nGênero: {livro.Genero}\nQuantidade na estante: {livro.Qntd}\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {


    }
}