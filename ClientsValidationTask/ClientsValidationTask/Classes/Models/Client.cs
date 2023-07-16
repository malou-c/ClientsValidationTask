using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsValidationTask.Classes.Models
{
    internal class Client
    {
        public string? FIO { get; set; }
        public int RegNumber { get; set; }
        public long DiasoftID { get; set; }
        public string? Registrator { get; set; }
        public int RegistratorID { get; set; }
    }
}
