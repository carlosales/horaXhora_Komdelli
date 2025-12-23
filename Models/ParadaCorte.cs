using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hora_Komdelli.Models;

[Table("parada_corte")]
public class ParadaCorte
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Hora de início é obrigatória")]
    [StringLength(10)]
    public required string HoraInicio { get; set; }
    
    [Required(ErrorMessage = "Hora final é obrigatória")]
    [StringLength(10)]
    public required string HoraFinal { get; set; }
    
    [Required(ErrorMessage = "Processo é obrigatório")]
    [StringLength(100)]
    public required string Processo { get; set; }
    
    [StringLength(100)]
    public string? Ordem { get; set; }
    
    [Required(ErrorMessage = "Justificativa é obrigatória")]
    [StringLength(500)]
    public required string Justificativa { get; set; }
    
    [StringLength(20)]
    public string? Duracao { get; set; }
    
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
