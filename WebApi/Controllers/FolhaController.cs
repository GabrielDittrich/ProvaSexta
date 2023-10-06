namespace WebApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Utilities;

[ApiController]
[Route("api/folha")]
public class FolhaController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public FolhaController(AppDataContext context)
    {
        _ctx = context;
    }

    // GET: api/categoria/listar
    [HttpGet]
    [Route("folha/listar")]
    public ActionResult Listar()
    {
        try
        {
            List<Folha> folhas = _ctx.Folhas.ToList();
            return folhas.Count == 0 ? NotFound() : Ok(folhas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/categoria/buscar/{nome}
    [HttpGet]
    [Route("folha/buscar/{cpf}/{mes}/{ano}")]
    public ActionResult Buscar([FromRoute] string cpf, [FromRoute] string mes, [FromRoute] string ano)
    {
        try
        {
            // Agora você pode usar cpf, mes e ano para buscar na base de dados.
            Folha? folhaCadastrada = _ctx.Folhas.FirstOrDefault(x => x.cpf == cpf && x.mes == mes && x.ano == ano);
            if (folhaCadastrada != null)
            {
                return Ok(folhaCadastrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    // POST: api/categoria/cadastrar
    [HttpPost]
    [Route("folha/cadastrar")]
    public ActionResult Cadastrar([FromBody] Folha folha)
    {
        try
        {

            // Calcular o salário bruto
            folha.SalarioBruto = CalculadoraSalario.CalcularSalarioBruto(folha.HorasTrabalhadas, folha.ValorHora);

            // Calcular o IR
            folha.IR = CalculadoraSalario.CalcularIR(folha.SalarioBruto);

            // Calcular o INSS
            folha.INSS = CalculadoraSalario.CalcularINSS(folha.SalarioBruto);

            // Calcular o FGTS
            folha.FGTS = CalculadoraSalario.CalcularFGTS(folha.SalarioBruto);

            // Calcular o salário líquido
            folha.SalarioLiquido = CalculadoraSalario.CalcularSalarioLiquido(folha.SalarioBruto);


            _ctx.Folhas.Add(folha);
            _ctx.SaveChanges();
            return Created("", folha);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
   