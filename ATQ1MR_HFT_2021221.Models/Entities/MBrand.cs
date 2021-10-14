using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Models.Entities
{
    [Table("MotherBoardBrands")]
    public class MBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Motherboard> Motherboards { get; set; }

    }
}
