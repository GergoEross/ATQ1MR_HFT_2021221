using ATQ1MR_HFT_2021221.Client.Infrastructure;
using ATQ1MR_HFT_2021221.Models.Entities;
using ATQ1MR_HFT_2021221.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATQ1MR_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for server..");
            Console.ReadLine();
            Motherboards();
            Console.WriteLine("*************************************");
            Console.WriteLine("*************************************");
            Console.WriteLine("*************************************");

            

            Console.ReadLine();
        }
        private static void DisplayMotherboardWhitProcessors(List<MotherboardWhitProcessorsModel> motherboardWhitProcessors)
        {
            foreach (var item in motherboardWhitProcessors)
            {
                Console.WriteLine(item);
                Console.WriteLine("************************************************\n");
            }
        }
        private static void DisplayMotherboardProcessorAvaragePrices(List<MotherboardPAvarageModel> motherboardPAvarages)
        {
            foreach (var item in motherboardPAvarages)
            {
                Console.WriteLine(item);
                Console.WriteLine("************************************************\n");
            }
        }
        private static void DisplayBestPricePerPerformace(List<BestPricePerPerformaceModel> bestPricePerPerformaces)
        {
            foreach (var item in bestPricePerPerformaces)
            {
                Console.WriteLine(item);
                Console.WriteLine("************************************************\n");
            }
        }
        private static void DisplayMotherboard(Motherboard motherboard)
        {
            Console.WriteLine("Id: {0}\nType: {1}\nChipset: {2}\nSocket: {3}\nPrice: {4}\nBrandId: {5}\n",
                motherboard.Id, motherboard.Type, motherboard.Chipset, motherboard.Socket, motherboard.Price, motherboard.BrandId);
        }

        private static void DisplayMotherboards(List<Motherboard> motherboards)
        {
            Console.WriteLine();

            foreach (var motherboard in motherboards)
            {
                DisplayMotherboard(motherboard);
            }
        }
        private static void Motherboards()
        {
            var mbHttpService = new HttpService("Motherboard", "http://localhost:51252/api/");

            //Get all
            Console.WriteLine("All motherboards");
            var motherboards = mbHttpService.GetAll<Motherboard>();
            DisplayMotherboards(motherboards);
            Console.WriteLine("************************************************\n");
            //Get one
            Console.WriteLine("Motherboard with Id: 1");
            var motherboard = mbHttpService.Get<Motherboard, int>(1);
            DisplayMotherboard(motherboard);
            Console.WriteLine("************************************************\n");
            //Create
            Console.WriteLine("Create new motherboard");
            var newMotherboard = new Motherboard()
            {
                Type = "PRIME",
                Chipset = "B550",
                Socket = "AM4",
                Price = 25000,
                BrandId = 2
            };
            var result = mbHttpService.Create<Motherboard>(newMotherboard);
            if (result.IsSuccess)
            {
                Console.WriteLine("Creation succsesfull!\n");
            }
            Console.WriteLine("************************************************\n");
            //Check
            motherboards = mbHttpService.GetAll<Motherboard>();
            DisplayMotherboards(motherboards);
            Console.WriteLine("************************************************\n");
            //Update
            Console.WriteLine("Update motherboard");
            var updateMotherboard = motherboards.First();
            updateMotherboard.Price = 32000;
            result = mbHttpService.Update<Motherboard>(updateMotherboard);
            if (result.IsSuccess)
            {
                Console.WriteLine("Update succsesfull!\n");
            }
            Console.WriteLine("************************************************\n");
            //Check
            motherboards = mbHttpService.GetAll<Motherboard>();
            DisplayMotherboards(motherboards);
            Console.WriteLine("************************************************\n");
            //Delete
            Console.WriteLine("Delete motherboard");
            mbHttpService.Delete(motherboards.Last().Id);
            //Check
            motherboards = mbHttpService.GetAll<Motherboard>();
            DisplayMotherboards(motherboards);
            Console.WriteLine("************************************************\n");
            //Get Motherboard Whit Processors
            Console.WriteLine("Motherboards with all of its processors");
            var motherboardWithProcessors = mbHttpService.GetAll<MotherboardWhitProcessorsModel>("GetMotherboardWhitProcessors");
            DisplayMotherboardWhitProcessors(motherboardWithProcessors);
            //Get Motherboard Processor Avarage Prices
            Console.WriteLine("Motherboards with its processors avarage prices");
            var motherboardProcessorAvgPrices = mbHttpService.GetAll<MotherboardPAvarageModel>("GetMotherboardProcessorAvaragePrices");
            DisplayMotherboardProcessorAvaragePrices(motherboardProcessorAvgPrices);
            //Get Best PPP For Motherboard
            Console.WriteLine("Best price/performance processor for motherboard with Id: 1");
            var bestPPPForMotherboard = mbHttpService.GetAll<BestPricePerPerformaceModel, int>(1, "GetBestPPPForMotherboard");
            DisplayBestPricePerPerformace(bestPPPForMotherboard);
        }
        private static void Processors()
        {
            var httpService = new HttpService("Processor", "http://localhost:51252/api/");

            //Get all
            var processors = httpService.GetAll<Processor>();
            DisplayProcessors(processors);
            //Get one
            var processor = httpService.Get<Processor, int>(1);
            DisplayProcessor(processor);
            //Create
            var newProcessor = new Processor() { Name = "Ryzen 7 3700X", BaseClock = 3.6, BoostClock = 4.4, BrandId = 2, 
                Cores = 8, Threads = 16, Socket = "AM4", Price = 114000 };
            var result = httpService.Create<Processor>(newProcessor);
            if (result.IsSuccess)
            {
                Console.WriteLine("Creation succsesfull!\n");
            }
            //Check
            processors = httpService.GetAll<Processor>();
            DisplayProcessors(processors);
            //Update
            var updateProcessor = processors.First();
            updateProcessor.Price = 110000;
            result = httpService.Update(updateProcessor);
            if (result.IsSuccess)
            {
                Console.WriteLine("Update succsesfull!\n");
            }
            //Check
            processors = httpService.GetAll<Processor>();
            DisplayProcessors(processors);
            //Delete
            httpService.Delete(processors.Last().Id);
            processors = httpService.GetAll<Processor>();
            DisplayProcessors(processors);
        }
        private static void DisplayProcessor(Processor processor)
        {
            Console.WriteLine(processor);
        }
        private static void DisplayProcessors(List<Processor> processors)
        {
            Console.WriteLine();
            foreach (var item in processors)
            {
                DisplayProcessor(item);
            }
        }
    }
}
