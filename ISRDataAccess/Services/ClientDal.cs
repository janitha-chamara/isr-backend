using Data.DataAccess.Services;
using DataMigrations.DataModels;
using ISRDataAccess.Extentions;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;

namespace ISRDataAccess.Services
{
    public class ClientDal : BaseDal, IClientDal
    {
        public int SaveClinet(ClientModel client)
        {
            Client saveclient = client.ToClient();
            var existingemployee = _db.Clients.SingleOrDefault(x => x.UUID == client.UUID);
            
            if (existingemployee != null)
            {
                _db.Clients.Add(saveclient);
                _db.SaveChanges();
            }
            else
            {
                _db.Clients.Update(saveclient);
                _db.SaveChanges();
            }
            return saveclient.ClientId;

        }


    }
}
