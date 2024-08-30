using System.ComponentModel.DataAnnotations;

namespace SGT.Models;

public class Ponto : Entidade
{
    [Key]
    public int id { get; set; }
    public string Nome { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
