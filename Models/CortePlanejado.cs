using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hora_Komdelli.Models;

[Table("corte_planejado")]
public class CortePlanejado
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100)]
    public string? Hora1 { get; set; }
    
    [StringLength(100)]
    public string? Hora2 { get; set; }
    
    [StringLength(100)]
    public string? Hora3 { get; set; }
    
    [StringLength(100)]
    public string? Hora4 { get; set; }
    
    [StringLength(100)]
    public string? Hora5 { get; set; }
    
    [StringLength(100)]
    public string? Hora6 { get; set; }
    
    [StringLength(100)]
    public string? Hora7 { get; set; }
    
    [StringLength(100)]
    public string? Hora8 { get; set; }
    
    [StringLength(100)]
    public string? Hora9 { get; set; }
    
    [StringLength(100)]
    public string? Hora10 { get; set; }
    
    [StringLength(100)]
    public string? Hora11 { get; set; }
    
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
