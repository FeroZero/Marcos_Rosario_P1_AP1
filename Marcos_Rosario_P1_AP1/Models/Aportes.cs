using System.ComponentModel.DataAnnotations;

namespace Marcos_Rosario_P1_AP1.Models
{
    public class Aportes
    {
		[Key]
        public int AporteId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo Caracteres Alfabeticos.")]
        [StringLength(50, ErrorMessage = "Limite Excedido.")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Campo Obligatorio.")]
        [StringLength(100)]
		public string Observacion {  get; set; }
		[Required(ErrorMessage = "Campo Obligatorio.")]
        [Range(0.01, 1000000, ErrorMessage = "Cantidad Excedida.")]
		public double Monto { get; set; }
	}
}
