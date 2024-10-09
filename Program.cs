//Adicionar livro
//Emprestar livro
//Retornar livro
//Cadastrar usuário
//Cadastrar administrador

//Classe Usuários
//Classe Admins
//Classe Biblioteca

class Admins
{
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
    public string Nome {get; set;}
    public string Senha {get; set;}

    public void NovoUsuario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Admins> admins = new List<Admins>();
        List<Usuarios> usuarios = new List<Usuarios>();

        
    }
}