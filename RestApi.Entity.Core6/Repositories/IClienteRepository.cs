using RestApi.Entity.Core6.Modelos;

namespace RestApi.Entity.Core6.Repositories
{
    public interface IClienteRepository
    {
        Clientes GetById(int id);

       List< Clientes> Get();

        bool PostClientes(ClientePostRequest clientes);

        bool Update(ClientePutRequest clientes);

        bool Delete(int id);
    }
}
