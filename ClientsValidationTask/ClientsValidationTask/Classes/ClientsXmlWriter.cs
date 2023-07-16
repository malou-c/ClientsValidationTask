using ClientsValidationTask.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientsValidationTask.Classes
{
    internal class ClientsXmlWriter : XmlWriterBase
    {
        public void Write(List<Client> clients, string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                throw new DirectoryNotFoundException(Path.GetDirectoryName(filePath));

            using var writer = XmlWriter.Create(filePath, _xmlWriterSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Clients");

            foreach (var client in clients)
            {
                writer.WriteStartElement("Client");
                writer.WriteElementString("FIO", client.FIO);
                writer.WriteElementString("RegNumber", client.RegNumber.ToString());
                writer.WriteElementString("DiasoftID", client.DiasoftID.ToString());
                writer.WriteElementString("Registrator", client.Registrator);
                writer.WriteElementString("RegistratorID", client.RegistratorID.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
}
