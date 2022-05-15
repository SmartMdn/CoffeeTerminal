namespace CoffeeTerminal.Domain.Models;

public class Terminal : DomainObject
{
    public string? TerminalId { get; set; }
    public DateTime RegistrationDateTime { get; set; }
}