using System.ComponentModel.DataAnnotations;

namespace TicketsValidator.Shared.DTOs
{
    public class TicketValidatorDTO
    {
        [Display(Name = "Boleta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Id { get; set; } = string.Empty;
    }
}
