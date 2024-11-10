using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoudiCarApp.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(30)]
        public string Color { get; set; }

        public int FuelTypeId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Kilometerstand { get; set; }

        public int Jaar { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [NotMapped]
        public string FuelType { get; set; }
    }
}
