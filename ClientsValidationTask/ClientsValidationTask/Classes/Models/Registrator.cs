using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsValidationTask.Classes.Models
{
    internal class Registrator : IEquatable<Registrator>
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public bool Equals(Registrator? other)
        {
            if (other is null)
                return false;

            return Name == other.Name;
        }
    }
}
