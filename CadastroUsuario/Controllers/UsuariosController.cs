using CadastroUsuario.Model;
using CadastroUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UsuariosController> logger;
        public UsuariosController(IUsuarioRepository usuarioRepository, ILogger<UsuariosController> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            logger.LogInformation("Iniciando o metodo GET");
            IEnumerable<Usuario> usuarios = await usuarioRepository.Get();
            logger.LogInformation($"Finalizando o metodo GET com {usuarios.Count()} itens de retorno.");
            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            logger.LogInformation($"Iniciando o metodo GET({id})");
            Usuario usuario = await usuarioRepository.Get(id);
            logger.LogInformation($"Finalizando o metodo GET({id})");
            if (usuario == null)
            {
                logger.LogWarning($"Finalizado o metodo GET({id}) como registro nao encontrado (404)");
                return NotFound();
            }
            logger.LogInformation($"Finalizado o metodo GET({id}) com registro encontrado (200) - {usuario}");
            return Ok(usuario);

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuario)
        {
            logger.LogInformation("Iniciando o metodo POST");
            ActionResult<Usuario> result = await usuarioRepository.Create(usuario);
            logger.LogInformation("Finalizando o metodo POST");
            if (result.Value == null)
            {
                logger.LogWarning("Finalizado metodo POST com retorno sem conteudo (204)");
                return NoContent();
            }
            if (result.Value.Id is null or "")
            {
                logger.LogError("Finalizado metodo POST com ID invalido, nulo ou em branco.");
                throw new ArgumentNullException("ID inválido");
            }
            logger.LogInformation($"Finalizado metodo POST com sucesso (200) - {result.Value}");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Update(string id, [FromBody] Usuario usuario)
        {
            logger.LogInformation($"Iniciando o metodo PUT({id})");
            if (usuario.Id.Equals(id))
            {

                await usuarioRepository.Update(usuario);
                logger.LogInformation($"Finalizado metodo PUT({id}) com sucesso - {usuario}");
                return Ok(usuario);
            }
            logger.LogWarning("Finalizado o metodo PUT, mas retorno sem conteudo (204).");
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(string id)
        {
            logger.LogInformation("Iniciando o metodo DELETE");
            Usuario usuario = await usuarioRepository.Get(id);
            if (usuario == null)
            {
                logger.LogWarning($"Finalizado o metodo DELETE({id}) como registro nao encontrado (404)");
                return NotFound();
            }
            logger.LogInformation($"Finalizando o metodo DELETE({id})");
            await usuarioRepository.Delete(usuario);
            logger.LogInformation($"Finalizado o metodo DELETE({id}) como sucesso (200) - {usuario}");
            return Ok(usuario);
        }
    }
}
