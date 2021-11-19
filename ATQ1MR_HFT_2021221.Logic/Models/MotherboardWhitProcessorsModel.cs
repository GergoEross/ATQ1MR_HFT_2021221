using ATQ1MR_HFT_2021221.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Logic.Models
{
    public class MotherboardWhitProcessorsModel
    {
        public string Type;
        public string Chipset;
        public string Brand;
        public List<Processor> Processors;
    }
}
