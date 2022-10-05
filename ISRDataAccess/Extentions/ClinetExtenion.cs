using DataMigrations.DataModels;
using ISRDataAccess.Models;

namespace ISRDataAccess.Extentions
{
    public static class ClinetExtenion
    {
        public static ClientModel ToClientModel(this Client client)
        {
            var ds = new ClientModel
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                UUID=client.UUID,
              
            };

            return ds;
        }

        public static Client ToClient(this ClientModel clientModel)
        {
            var ds = new Client
            {
                ClientId = clientModel.ClientId,
                ClientName = clientModel.ClientName,
                UUID=clientModel.UUID,
             
            };
            return ds;

        }
    }
}
