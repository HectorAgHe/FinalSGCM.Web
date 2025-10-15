using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class CommonDataDto
    {
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Name { get; set; }

        public string? LastName { get; set; }
        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Telefono es requerido")]
        public int Phone { get; set; }
    }
}
