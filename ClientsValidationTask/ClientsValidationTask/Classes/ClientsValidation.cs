using ClientsValidationTask.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsValidationTask.Classes
{
    internal static class ClientsValidation
    {
        public static List<Client> GetValidClients(IEnumerable<Client> clients)
        {
            var validClients = new List<Client>();

            foreach (var client in clients)
            {
                if (IsValidClient(client))
                    validClients.Add(client);
            }

            return validClients;
        }

        public static bool IsValidClient(Client client)
        {
            return !string.IsNullOrEmpty(client.FIO) &&
                client.RegNumber != 0 &&
                client.DiasoftID != 0 &&
                !string.IsNullOrEmpty(client.Registrator);
        }

        public static InvalidClientsSummary GetInvalidClientsSummary(List<Client> clients)
        {
            var invalidClientsSummary = new InvalidClientsSummary();

            foreach (var client in clients)
            {
                if (string.IsNullOrEmpty(client.FIO))
                    invalidClientsSummary.InvalidFioAmount++;
                if (client.RegNumber == 0)
                    invalidClientsSummary.InvalidRegNumberAmount++;
                if (client.DiasoftID == 0)
                    invalidClientsSummary.InvalidDiasoftIDAmount++;
                if (string.IsNullOrEmpty(client.Registrator))
                    invalidClientsSummary.InvalidRegistratorAmount++;

                if (!IsValidClient(client))
                    invalidClientsSummary.InvalidClientsAmount++;
            }

            return invalidClientsSummary;
        }
    }
}
