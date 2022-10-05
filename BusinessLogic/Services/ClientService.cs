using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;
using ISRDataAccess.Services;


namespace BusinessLogic.Services
{
    public class ClientService :IClientService
    {
        private readonly IClientDal _clientdal;

        public ClientService(IClientDal clientDal)
        {
            _clientdal = clientDal;
        }

        public ServiceResponse<int> AddClient(ClientModel client)
        {
            var allJobs = _clientdal.SaveClinet(client);
            return new ServiceResponse<int>(allJobs);
        }




    }
}
