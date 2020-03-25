using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 2 caracteres...")
                .HasMaxLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 40 caracteres...")
                .HasMinLen(lastName, 3, "Name.lastName", "Sobrenome deve conter pelo menos 2 caracteres...")
                .HasMaxLen(lastName, 3, "Name.lastName", "Sobrenome deve conter pelo menos 40 caracteres...")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}