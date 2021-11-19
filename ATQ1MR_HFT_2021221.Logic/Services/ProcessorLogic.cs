using ATQ1MR_HFT_2021221.Logic.Intefaces;
using ATQ1MR_HFT_2021221.Models.Entities;
using ATQ1MR_HFT_2021221.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Logic.Services
{
    public class ProcessorLogic : IProcessorLogic
    {
        IPBrandRepository _pBrandRepository;
        IMotherboardRepository _motherboardRepository;
        IProcessorRepository _processorRepository;
        public IList<Processor> ReadAll()
        {
            return _processorRepository.ReadAll().ToList();
        }
        public Processor Read(int id)
        {
            return _processorRepository.Read(id);
        }
        public Processor Create(Processor entity)
        {
            var result = _processorRepository.Create(entity);
            return result;
        }
        public Processor Update(Processor entity)
        {
            var result = _processorRepository.Update(entity);
            return result;
        }
        public void Delete(int id)
        {
            _processorRepository.Delete(id);
        }
    }
}
