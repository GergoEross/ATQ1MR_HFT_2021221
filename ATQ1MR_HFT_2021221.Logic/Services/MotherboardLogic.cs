using ATQ1MR_HFT_2021221.Logic.Intefaces;
using ATQ1MR_HFT_2021221.Logic.Models;
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
            var v = _motherboardRepository.Read(entity.Id);
            if (v == null)
            {
                var result = _motherboardRepository.Create(entity);
                return result;
            }
            else
            {
                throw new Exception("Already exists!");
            }
        }
        public Motherboard Update(Motherboard entity)
        {
            var v = _motherboardRepository.Read(entity.Id);
            if (v != null)
            {
                var result = _motherboardRepository.Update(entity);
                return result;
            }
            else
            {
                throw new Exception("No entity found!");
            }
        }
        public void Delete(int id)
        {
            _motherboardRepository.Delete(id);
        }

        public IEnumerable<MotherboardWhitProcessorsModel> MotherboardsWhitItsProcessors()
        {
            var processors = _processorRepository.ReadAll();
            var motherboards = _motherboardRepository.ReadAll();
            var mBrands = _mBrandRepository.ReadAll();

            var result = from motherboar in motherboards
                         join brand in mBrands
                         on motherboar.BrandId equals brand.Id
                      join processor in processors
                      on motherboar.Socket equals processor.Socket
                      select new MotherboardWhitProcessorsModel
                      {
                          Chipset = motherboar.Chipset,
                          Type = motherboar.Type,
                          Brand = brand.Name,
                          Processors = processors.OrderByDescending(x => x.Price).ToList()
                      };

            return result;
        }
    }
}
