namespace WebApi.Utilities;

public class CalculadoraSalario
{
    public static decimal CalcularSalarioBruto(decimal horasTrabalhadas, decimal valorHora)
    {
        return horasTrabalhadas * valorHora;
    }

    public static decimal CalcularIR(decimal salarioBruto)
    {
        if (salarioBruto <= 1903.98M) return 0;
        if (salarioBruto <= 2826.65M) return salarioBruto * 0.075M - 142.80M;
        if (salarioBruto <= 3751.05M) return salarioBruto * 0.15M - 354.80M;
        if (salarioBruto <= 4664.68M) return salarioBruto * 0.225M - 636.13M;
        return salarioBruto * 0.275M - 869.36M;
    }

    public static decimal CalcularINSS(decimal salarioBruto)
    {
        if (salarioBruto <= 1693.72M) return salarioBruto * 0.08M;
        if (salarioBruto <= 2822.90M) return salarioBruto * 0.09M;
        if (salarioBruto <= 5645.80M) return salarioBruto * 0.11M;
        return 621.03M;
    }

    public static decimal CalcularFGTS(decimal salarioBruto)
    {
        return salarioBruto * 0.08M;
    }

    public static decimal CalcularSalarioLiquido(decimal salarioBruto)
    {
        decimal ir = CalcularIR(salarioBruto);
        decimal inss = CalcularINSS(salarioBruto);
        return salarioBruto - ir - inss;
    }
}