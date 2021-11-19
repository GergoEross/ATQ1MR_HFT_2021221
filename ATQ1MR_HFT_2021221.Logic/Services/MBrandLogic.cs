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
    public class MBrandLogic : IMBrandLogic
    {
        IMBrandRepository _mBrandRepository;
        IMotherboardRepository _motherboardRepository;
        IProcessorRepository _processorRepository;

        public MBrandLogic(IMBrandRepository mBrandRepository, IMotherboardRepository motherboardRepository, IProcessorRepository processorRepository)
        {
            _mBrandRepository = mBrandRepository;
            _motherboardRepository = motherboardRepository;
            _processorRepository = processorRepository;
        }

        public IList<MBrand> ReadAll()
        {
            return _mBrandRepository.ReadAll().ToList();
        }
        public MBrand Read(int id)
        {
            return _mBrandRepository.Read(id);
        }
        public MBrand Create(MBrand entity)
        {
            var v = _mBrandRepository.Read(entity.Id);
            if (v == null)
            {
                var result = _mBrandRepository.Create(entity);
                return result;
            }
            else
            {
                throw new Exception("Already exists!");
            }
        }
        public MBrand Update(MBrand entity)
        {
            var v = _mBrandRepository.Read(entity.Id);
            if (v != null)
            {
                var result = _mBrandRepository.Update(entity);
                return result;
            }
            else
            {
                throw new Exception("No entity found!");
            }   
        }
        public void Delete(int id)
        {
            _mBrandRepository.Delete(id);
        }
    }
}
