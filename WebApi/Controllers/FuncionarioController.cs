using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data;
using WebApi.Models; 

namespace YourNamespace.Controllers 
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDataContext _ctx; 

        public FuncionariosController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("funcionario/cadastrar")]
        public ActionResult Cadastrar(Funcionario funcionario)
        {
            try
            {
                _ctx.Funcionarios.Add(funcionario);
                _ctx.SaveChanges();
                return Ok("Funcionário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("funcionario/listar")]
        public ActionResult<List<Funcionario>> Listar()
        {
            try
            {
                var funcionarios = _ctx.Funcionarios.ToList();
                return Ok(funcionarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}





