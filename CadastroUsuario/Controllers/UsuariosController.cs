using CadastroUsuario.Model;
using CadastroUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await usuarioRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            return await usuarioRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuario)
        {
            return await usuarioRepository.Create(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id)
        {
            Usuario usuario = await usuarioRepository.Get(id);
            await usuarioRepository.Update(usuario);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            Usuario usuario = await usuarioRepository.Get(id);
            await usuarioRepository.Delete(usuario);
            return new NoContentResult();
        }
    }
}
