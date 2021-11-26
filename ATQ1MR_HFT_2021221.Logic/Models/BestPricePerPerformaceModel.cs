using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Logic.Models
{
    public class BestPricePerPerformaceModel
    {
        public string ProcessorName;
        public double PPP;
        public override bool Equals(object obj)
        {
            var other = obj as BestPricePerPerformaceModel;
            if (other == null)
            {
                return false;
            }
            else
            {
                return other.ProcessorName == ProcessorName && other.PPP == PPP;
            }
        }
    }
}
