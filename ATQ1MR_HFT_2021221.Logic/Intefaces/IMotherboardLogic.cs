using ATQ1MR_HFT_2021221.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Logic.Intefaces
{
    public interface IMotherboardLogic
    {
        IList<Motherboard> ReadAll();
        Motherboard Read(int id);
        Motherboard Create(Motherboard entity);
        Motherboard Update(Motherboard entity);
        void Delete(int id);
    }
}
