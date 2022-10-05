using DataMigrations.DataModels;
using ISRDataAccess.Models;

namespace BusinessLogic
{
    public static class ClinetExtenion
    {
        public static ClientModel ToClientModel(this Client client)
        {
            var ds = new ClientModel
            {
                //ClientId = client.ClientId,
                ClientName = client.Name,
                UUID = client.UUID,
              
            };

            return ds;
        }

        public static Client ToClient(this ClientModel clientModel)
        {
            var ds = new Client
            {
                //Id = clientModel.ClientId,
                Name = clientModel.ClientName,
                UUID = clientModel.UUID,
             
            };
            return ds;

        }
    }
}
