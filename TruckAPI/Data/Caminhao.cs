using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Caminhao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string AnoModelo { get; set; }
        [Required]
        public string AnoFabricacao { get; set; }   

    }
}
