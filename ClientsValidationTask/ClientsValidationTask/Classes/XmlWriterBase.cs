using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientsValidationTask.Classes
{
    internal abstract class XmlWriterBase
    {
        protected XmlWriterSettings _xmlWriterSettings;

        public XmlWriterBase()
        {
            _xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                NewLineChars = "\n",
                IndentChars = "\t"
            };
        }
    }
}
