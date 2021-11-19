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

            var proc = from processor in processors
                       group processor by processor.Socket into g
                       select new
                       {
                           Socket = g.Key,
                           Processors = g.Select(x => x).OrderByDescending(x => x.Price)
                       };

            var result = from motherboar in motherboards
                         join brand in mBrands
                         on motherboar.BrandId equals brand.Id
                      join processor in proc
                      on motherboar.Socket equals processor.Socket
                      select new MotherboardWhitProcessorsModel
                      {
                          Chipset = motherboar.Chipset,
                          Type = motherboar.Type,
                          Brand = brand.Name,
                          Processors = (List<Processor>)processor.Processors
                      };

            return result.ToList();
        }

        public IEnumerable<MotherboardPAvarageModel> MotherboardProcessorAvaragePrices()
        {
            var motherboards = _motherboardRepository.ReadAll();
            var processors = _processorRepository.ReadAll();
            var mBrands = _mBrandRepository.ReadAll();

            var avarages = from processor in processors
                           group processor by processor.Socket into g
                           select new
                           {
                               Socket = g.Key,
                               Avarage = g.Average(x => x.Price)
                           };
            var result = from motherboard in motherboards
                         join brand in mBrands
                         on motherboard.BrandId equals brand.Id
                         join avarage in avarages
                         on motherboard.Socket equals avarage.Socket
                         select new MotherboardPAvarageModel
                         {
                             Chipset = motherboard.Chipset,
                             Type = motherboard.Type,
                             Brand = brand.Name,
                             Avarage = avarage.Avarage
                         };

            return result.ToList();
        }

        public IEnumerable<BestPricePerPerformaceModel> BestPPPForMotherboard(int id)
        {
            var motherboards = _motherboardRepository.ReadAll();
            var processors = _processorRepository.ReadAll();

            var procppps = from processor in processors
                            select new
                            {
                                Socket = processor.Socket,
                                Name = processor.Name,
                                PPP = processor.Price / processor.Cores * (double)((processor.BaseClock + processor.BoostClock) / 2)
                            };
            var ordered = from proc in procppps
                         group proc by proc.Socket into g
                         select new
                         {
                             Socket = g.Key,
                             Name = g.OrderBy(x => x.PPP).Select(x => x.Name).First(),
                             PPP = g.Select(x => x.PPP).OrderBy(x => x).First()
                         };
            var result = from motherboard in motherboards
                         join proc in ordered
                         on motherboard.Socket equals proc.Socket
                         where motherboard.Id == id
                         select new BestPricePerPerformaceModel
                         {
                             ProcessorName = proc.Name,
                             PPP = proc.PPP
                         };


            return result.ToList();
        }
    }
}
