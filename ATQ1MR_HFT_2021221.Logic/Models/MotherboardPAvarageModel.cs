using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Logic.Models
{
    public class MotherboardPAvarageModel
    {
        public string Type;
        public string Chipset;
        public string Brand;
        public double Avarage;
        public override bool Equals(object obj)
        {
            var other = obj as MotherboardPAvarageModel;
            if (other == null)
            {
                return false;
            }
            else
            {
                return other.Brand == Brand && other.Chipset == Chipset && other.Type == Type && other.Avarage == Avarage;
            }
        }
    }
}
