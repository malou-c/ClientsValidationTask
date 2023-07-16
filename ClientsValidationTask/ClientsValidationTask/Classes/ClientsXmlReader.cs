using ClientsValidationTask.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientsValidationTask.Classes
{
    internal class ClientXmlReader
    {
        public string FilePath { get; private set; }

        public ClientXmlReader(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            FilePath = filePath;
        }

        public List<Client> Read()
        {
            var сlients = new List<Client>();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(FilePath);

            var clientNodes = xmlDoc.SelectNodes("//Client");

            if (clientNodes is null)
                throw new Exception("Не удалось прочитать xml файл");

            foreach (XmlNode clientNode in clientNodes)
            {
                var client = new Client() 
                {
                    FIO = clientNode.SelectSingleNode("FIO")?.InnerText,
                    RegNumber = Convert.ToInt32(clientNode.SelectSingleNode("RegNumber")?.InnerText),
                    DiasoftID = Convert.ToInt64(clientNode.SelectSingleNode("DiasoftID")?.InnerText),
                    Registrator = clientNode.SelectSingleNode("Registrator")?.InnerText
                };

                сlients.Add(client);
            }

            return сlients;
        }
    }
}