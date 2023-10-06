namespace WebApi.Models;

public class Folha 
{

    public string cpf { get; set; }
    public int valor { get; set; }
    public int quantidade { get; set; }
    public string mes { get; set; }
    public string ano { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    public decimal SalarioLiquido { get; set; }
    public decimal HorasTrabalhadas { get; set; }
    public decimal ValorHora { get; set; }
    public decimal SalarioBruto { get; set; }
    public decimal IR { get; set; }
    public decimal INSS { get; set; }
    public decimal FGTS { get; set; }


}