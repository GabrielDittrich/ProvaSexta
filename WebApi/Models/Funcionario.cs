namespace WebApi.Models;

public class Funcionario{

    public string nome { get; set; }
    public string cpf { get; set; }
    public int FuncionarioId { get; set; }
    public ICollection<Folha> Folhas { get; set; }

}