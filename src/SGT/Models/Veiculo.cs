namespace SGT.Models;

public class Veiculo : Entidade
{
    public string Empresa { get; set; }
    public string LetreiroIda { get; set; }
    public string LetreiroIVolta { get; set; }
    public string Linha { get; set; }
    public bool Ativo { get; set; }
}
