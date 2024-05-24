using System.ComponentModel.DataAnnotations;

namespace Modelo_Vista_Controlador.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por Favor escribe un Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Por Favor escribe un Apellido")]
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }
        [Required(ErrorMessage = "Por Favor escribe un Teléfono")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Por Favor escribe un E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por Favor escribe una Fecha")]
        public DateTime date { get; set; }
    }
}