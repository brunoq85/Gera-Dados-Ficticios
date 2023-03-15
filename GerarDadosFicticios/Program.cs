using Bogus;


List<Pessoa> pessoas = new List<Pessoa>();



for (int i = 1; i <= 100; i++)
{
    var faker = new Faker("pt_BR");

    string firstName = faker.Person.FirstName;
    string lastName = faker.Person.LastName;

    pessoas.Add(new Pessoa
    {
        Id = i,
        Nome = $"{firstName} {lastName}",
        Idade = faker.Random.Int(18, 60),
        Email = faker.Internet.Email(firstName, lastName)
    });
}

Console.WriteLine($@"public List<Pessoa> Pessoas = new List<Pessoa>");
Console.WriteLine(@"{");


foreach (Pessoa pessoa in pessoas)
{
    Console.Write(@"new Pessoa(){");
    Console.Write(@$"Id = {pessoa.Id}, Nome = '{pessoa.Nome}', Idade = {pessoa.Idade}, Email = '{pessoa.Email.ToLower()}'");
    Console.Write(@"},");
}

Console.WriteLine(@"}");

Console.ReadKey();

class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
}