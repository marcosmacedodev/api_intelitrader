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
    public class UsuariosController: ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            IEnumerable<Usuario> usuarios = await usuarioRepository.Get();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            Usuario usuario = await usuarioRepository.Get(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuario)
        {

            return await usuarioRepository.Create(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Update(string id, [FromBody] Usuario usuario)
        {

            if (usuario.Id.Equals(id))
            {
                await usuarioRepository.Update(usuario);
                return Ok(usuario);
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(string id)
        {
            Usuario usuario = await usuarioRepository.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }


            await usuarioRepository.Delete(usuario);
            return Ok(usuario);
        }
    }
}
