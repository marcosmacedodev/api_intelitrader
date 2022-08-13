using CadastroUsuario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task Create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
