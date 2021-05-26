using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDePrestamos.Shared.Entidates
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de cliente")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Celular { get; set; }

        [Display(Name = "Dirección Casa")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }

        public string Foto { get; set; }
    }
}
