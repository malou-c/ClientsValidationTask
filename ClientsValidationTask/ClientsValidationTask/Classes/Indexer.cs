using ClientsValidationTask.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsValidationTask.Classes
{
    internal class Indexer
    {
        public static List<Registrator> GetNumberedRegistrators(IEnumerable<Client> clients)
        {
            var registratorNames = new List<string>();
            var registrators = new List<Registrator>();

            foreach (var client in clients)
            {
                if (!string.IsNullOrEmpty(client.Registrator) && !registratorNames.Contains(client.Registrator))
                    registratorNames.Add(client.Registrator);
            }

            for (var i = 0; i < registratorNames.Count; i++)
            {
                registrators.Add(new Registrator()
                {
                    ID = i,
                    Name = registratorNames[i]
                });
            }

            return registrators;
        }

        public static void IndexClients(IEnumerable<Client> clients)
        {
            var registrators = GetNumberedRegistrators(clients).ToDictionary(key => key.Name!, value => value.ID);

            foreach (var client in clients)
            {
                if (string.IsNullOrEmpty(client.Registrator))
                    continue;

                var registratorID = registrators[client.Registrator];
                client.RegistratorID = registratorID;
            }
        }
    }
}
