using System.ComponentModel.DataAnnotations;

namespace TaskMasterAPI.Models.Entities;

public class TaskItem
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres")]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [FutureDate(ErrorMessage = "A data deve ser futura")]
    public DateTime DueDate { get; set; }
    
    public bool IsCompleted { get; set; }
    
    [Range(1, 3, ErrorMessage = "A prioridade deve ser entre 1 (Baixa) e 3 (Alta)")]
    public int Priority { get; set; }

    public int UserId { get; set; }
}

// Validador customizado para data futura
public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value is DateTime date && date > DateTime.Now;
    }
}
