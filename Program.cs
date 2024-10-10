public class Admins
{
    List<Admins> admins = new List<Admins>();

    public string NomeAdm {get; set;}
    public string SenhaAdm {get; set}

    public void NovoAdm(string nomeAdm, string senhaAdm)
    {
        admins.Add(new Admins{NomeAdm = nomeAdm, SenhaAdm = senhaAdm});
        Console.Write("Novo administrador criado!");
    }
}

public class Usuarios
{
    List<Usuarios> usuarios = new List<Usuarios>();
    
    public string Nome {get; set;}
    public string Senha {get; set;}
    public string LivroUsuario {get; set;}

    public void NovoUsuario(string nome, string senha)
    {
        usuarios.Add(new Usuarios{Nome = nome, Senha = senha});
        Console.Write("Novo Usuário  criado!");
    }

    public void Emprestados(string livroUsuario)
    {
        LivroUsuario = livroUsuario;
    }
}

public class Livros
{
    public string Titulo {get; set;}
    public string Autor {get; set;}
    public string Genero {get; set;}
    public int Qntd {get; set;}

    public Livros(string titulo, string autor, string genero, int qntd = 1)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Qntd = qntd;
    }
}

public class Biblioteca
{
    private List<Livros> livros = new List<Livros>(); 
    private List<Livros> livrosEmprestados = new List<Livros>();

    public void AdicionarLivros(string titulo, string autor, string genero)
    {
        Livros livroExistente = livros.Find(l => l.Titulo == titulo);

        if(livroExistente != null)
        {
            Console.Write($"Livro {titulo} já existente na biblioteca, adicionando mais um à sua quantidade");
            livroExistente.Qntd += 1;
        }
        else
        {
            Livros novoLivro = new Livros(titulo, autor, genero);
            livros.Add(novoLivro);
            Console.Write($"Livro {titulo} adicionado à biblioteca!");
        }
    }

    public void EmprestarLivros(string titulo)
    {
        Livros livroExistente = livros.Find(l => l.Titulo == titulo);
        
        if(livroExistente != null && livroExistente.Qntd > 1)
        {
            livroExistente.Qntd -= 1;
            livrosEmprestados.Add(livroExistente);
        }
        else if(livroExistente != null && livroExistente.Qntd == 1)
        {
            livros.Remove(livroExistente);
            livrosEmprestados.Add(livroExistente);
        }
        else
        {
            Console.Write("A biblioteca não possui este livro!");
        }
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