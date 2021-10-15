using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Models.Entities
{
    [Table("Processors")]
    public class Processor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Socket { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public int Price { get; set; }
        public int BrandId { get; set; }
        [NotMapped]
        public virtual PBrand Brand { get; set; }

    }
}
