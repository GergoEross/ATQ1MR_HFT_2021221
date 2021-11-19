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
    public class MotherboardLogic : IMotherboardLogic
    {
        IMBrandRepository _mBrandRepository;
        IMotherboardRepository _motherboardRepository;
        IProcessorRepository _processorRepository;

        public MotherboardLogic(IMBrandRepository mBrandRepository, IMotherboardRepository motherboardRepository, IProcessorRepository processorRepository)
        {
            _mBrandRepository = mBrandRepository;
            _motherboardRepository = motherboardRepository;
            _processorRepository = processorRepository;
        }

        public IList<Motherboard> ReadAll()
        {
            return _motherboardRepository.ReadAll().ToList();
        }
        public Motherboard Read(int id)
        {
            return _motherboardRepository.Read(id);
        }
        public Motherboard Create(Motherboard entity)
        {
            var result = _motherboardRepository.Create(entity);
            return result;
        }
        public Motherboard Update(Motherboard entity)
        {
            var result = _motherboardRepository.Update(entity);
            return result;
        }
        public void Delete(int id)
        {
            _motherboardRepository.Delete(id);
        }
    }
}
