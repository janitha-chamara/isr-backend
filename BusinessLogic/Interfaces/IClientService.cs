using BusinessLogic.Models;
using ISRDataAccess.Models;
namespace BusinessLogic.Interfaces
{
    public interface IClientService
    {
        ServiceResponse<int> AddClient(ClientModel client);


    }
}
