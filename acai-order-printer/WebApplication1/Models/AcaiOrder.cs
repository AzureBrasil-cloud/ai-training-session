namespace WebApplication1.Models;

public class AcaiOrder
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public Pagamento Pagamento { get; set; } = new();
    public bool ParaViagem { get; set; }
    public string Tamanho { get; set; }
    public string TipoAcai { get; set; }
    public List<string> Adicionais { get; set; } = new();
    public List<string> Frutas { get; set; } = new();
    public List<string> Caldas { get; set; } = new();
    public List<string> AdicionaisEspeciais { get; set; } = new();

    public List<string> ToReceipt()
    {
        var result = new List<string>
        {
            $"Nome: {Nome}",
            $"Telefone: {Telefone}",
            $"Pagamento: {Pagamento.Metodo} / Troco: {Pagamento.Troco}",
            $"Para viagem: {ParaViagem}",
            $"Tamanho: {Tamanho}",
            $"Tipo de açaí: {TipoAcai}",
            "----------",
            "",
            "",
            $"Adicionais: {string.Join(", ", Adicionais)}",
            "",
            "",
            $"Frutas: {string.Join(", ", Frutas)}",
            "",
            "",
            $"Caldas: {string.Join(", ", Caldas)}",
            "",
            "",
            $"Especiais: {string.Join(", ", AdicionaisEspeciais)}"
        };

        return result;
    }
}

public class Pagamento
{
    public string Metodo { get; set; }
    public bool Troco { get; set; }
}