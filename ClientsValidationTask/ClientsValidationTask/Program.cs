using ClientsValidationTask.Classes;
using System.Reflection;

var clientsDataFilePath = @"Resources\Clients.xml";
var validClientsFilePath = @"Resources\ValidClients.xml";
var registratorsFilePath = @"Resources\Registrators.xml";
var invalidClientsSummaryFilePath = @"Resources\InvalidClientsSummary.txt";

var clientXmlReader = new ClientXmlReader(clientsDataFilePath);
var clients = clientXmlReader.Read();

var validClients = ClientsValidation.GetValidClients(clients);
Indexer.IndexClients(validClients);

var clientXmlWriter = new ClientsXmlWriter();
clientXmlWriter.Write(validClients, validClientsFilePath);

var registratorXmlWriter = new RegistratorXmlWriter();
registratorXmlWriter.Write(Indexer.GetNumberedRegistrators(validClients), registratorsFilePath);

ClientsValidation.GetInvalidClientsSummary(clients).WriteToFile(invalidClientsSummaryFilePath);