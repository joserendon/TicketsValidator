using System.ComponentModel.DataAnnotations;
using TicketsValidator.Shared.Enums;

namespace TicketsValidator.Shared.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? UseDate { get; set; }

        public bool IsUsed { get; set; }

        [Display(Name = "Entrada")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, byte.MaxValue, ErrorMessage = "El campo {0} no es válido.")]
        public Entry? Entry { get; set; }
    }
}
