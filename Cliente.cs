using Flunt.Notifications;
using Flunt.Validations;

namespace flunt_notification_pattern;

public class Cliente : Notifiable<Notification>
{
    public Cliente(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;

        Validate();
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public int Idade { get; private set; }

    public void EditarNome(string nome)
    {
        Nome = nome;

        Clear();
        Validate();
    }

    public void EditarEmail(string email)
    {
        Email = email;

        Clear();
        Validate();
    }

    public void EditarIdade(int idade)
    {
        Idade = idade;

        Clear();
        Validate();
    }

    private void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Nome, nameof(Nome), "Favor informar o nome do cliente!")
            .IsEmail(Email, nameof(Email), "Favor informar um e-mail válido!")
            .IsGreaterThan(Idade, 18, nameof(Idade), "O cliente deve ser maior de 18 anos!"));
    }
}
