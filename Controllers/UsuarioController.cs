using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using ControleDeConteudo.Services;

namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepository = usuarioRepo;
        }

      
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario usuario)
        {
            var x = _usuarioRepository.GetUsuario(usuario);

            if (x == null)
            {
                return NotFound(new { mensagem = "Usuário ou Senha não encontrados" });
            }
            else
            {
                var token = TokenService.GenerateToken(usuario);
                usuario.Password = "";

                return new
                {                  
                    usuario = usuario.Username,  
                    nomeCompleto = x.NomeCompleto ,
                    token = token
                };
            }     
            
        }
    }
}
