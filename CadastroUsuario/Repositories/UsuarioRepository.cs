using CadastroUsuario.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext context;

        public UsuarioRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
           await context.Usuarios.AddAsync(usuario);
           await context.SaveChangesAsync();
           return await context.Usuarios.FindAsync(usuario.Id);
        }

        public async Task Delete(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Get(string id)
        {
            return await context.Usuarios.FindAsync(id);
        }

        public async Task Update(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
