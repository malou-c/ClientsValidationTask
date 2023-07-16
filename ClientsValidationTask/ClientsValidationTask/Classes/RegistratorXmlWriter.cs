using ClientsValidationTask.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientsValidationTask.Classes
{
    internal class RegistratorXmlWriter : XmlWriterBase
    {
        public void Write(List<Registrator> registrators, string filePath)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath, _xmlWriterSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Registrators");

                foreach (var registrator in registrators)
                {
                    writer.WriteStartElement("Registrator");
                    writer.WriteElementString("ID", registrator.ID.ToString());
                    writer.WriteElementString("Name", registrator.Name);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
