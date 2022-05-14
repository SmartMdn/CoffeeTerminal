using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTerminal.Domain.Models
{
    public class Terminal : DomainObject
    {
        public string? TerminalId { get; set; }
        public DateTime RegistrationDateTime { get; set; }
    }
}
