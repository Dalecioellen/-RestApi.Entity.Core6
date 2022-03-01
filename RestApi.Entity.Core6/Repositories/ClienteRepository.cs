using RestApi.Entity.Core6.Modelos;

namespace RestApi.Entity.Core6.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Db_Context _db;

        public ClienteRepository(Db_Context db)
        {
            _db = db;
        }

        public bool PostClientes(ClientePostRequest cliente)
        {
            try
            {
                var clienteDb = new Clientes
                {
                    Nome = cliente.Nome,
                    Data_Nascimento = cliente.Data_Nascimento,
                 
                };
                _db.Add(clienteDb);
                _db.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }


        public bool Update(ClientePutRequest cliente)
        {
            try
            {
                var clienteDb = _db.Clientes.Find(cliente.Id);

           
                clienteDb.Nome = cliente.Nome;

                clienteDb.Data_Nascimento = cliente.Data_Nascimento;
              


                _db.Update(clienteDb);               
                _db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
        public Clientes GetById(int clienteId)
        {
            try
            {
                var response = _db.Clientes.Find(clienteId);
                if(response != null)
                {
                 
                    var idade = DateTime.Now.Year - response.Data_Nascimento.Year;
                    response.Idade = idade.ToString();
                  
                }

                else
                {
                    throw new Exception();
                }

                return response;


            }
            catch (Exception e)
            {

                return new Clientes();
            }
      

        }

        public List<Clientes> Get()
        {
            try
            {
       
               var  response = _db.Clientes.ToList();
               
              
                foreach (var item in response)
                { 
                    var idade = DateTime.Now.Year - item.Data_Nascimento.Year;
                    item.Idade = idade.ToString();
                 

                }
             

                return response;
            }
            catch (Exception e)
            {

                return null;
            }


        }
        public bool Delete(int id)
        {
            try
            {
                var clienteDb = _db.Clientes.Find(id);
       
                _db.Remove(clienteDb);
       
                _db.SaveChangesAsync();
               
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
