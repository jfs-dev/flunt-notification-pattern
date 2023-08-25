using flunt_notification_pattern;

var peterParker = new Cliente("Peter Benjamin Parker", "peter.parker@marvel.com", 23);

Print(peterParker);

peterParker.EditarNome("");
peterParker.EditarEmail("peter.parker@");
peterParker.EditarIdade(17);

Print(peterParker);

static void Print(Cliente cliente)
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    if (cliente.IsValid)
    {
        Console.WriteLine("\nCliente válido:");
        Console.WriteLine("===============");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Id: {cliente.Id} - Nome: {cliente.Nome} - e-mail: {cliente.Email} - Idade: {cliente.Idade}");
    }
    else
    {
        Console.WriteLine("\nCliente inválido:");
        Console.WriteLine("=================");

        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var notification in cliente.Notifications)
        {
            Console.WriteLine(notification.Message);
        }
    }
}
