using CadastroUsuario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(string id);
        Task<Usuario> Create(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(Usuario usuario);

    }
}
