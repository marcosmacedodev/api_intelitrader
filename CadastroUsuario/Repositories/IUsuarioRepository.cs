using CadastroUsuario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Repositories
{
    interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(string id);
        Task Create(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(string id);

    }
}
