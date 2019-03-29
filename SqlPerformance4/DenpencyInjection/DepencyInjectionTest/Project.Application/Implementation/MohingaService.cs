using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using Project.Dat.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Project.Data.Entities;

namespace Project.Application.Implementation
{
    public class MohingaService : IMohingaService
    {

        private readonly IBoilEggTableRepository _boilEggTableRepository;
        private readonly IBoilNoddleTableRepository _boilNoddleTableRepository;

        

        public MohingaService(
            IBoilEggTableRepository boilEggTableRepository,
            IBoilNoddleTableRepository boilNoddleTableRepository)
        {

            _boilEggTableRepository = boilEggTableRepository;
            _boilNoddleTableRepository = boilNoddleTableRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<MohingaViewModel>> MakeMohinga()
        {
            var egg = new EggTable()
            {
                name = "egg",
                value = 1
            };
            _boilEggTableRepository.Add(egg);

            var noddleTable = new NoddleTable()
            {
                noddleName = "7 eleven",
                value = 1
            };


            _boilNoddleTableRepository.Add(noddleTable);

            Save();



            

            var temp = await (from eggs in _boilEggTableRepository.FindAll()
                        join noddle in _boilNoddleTableRepository.FindAll() on eggs.Id equals noddle.Id
                       select new MohingaViewModel()
                       {
                           ID = eggs.Id,
                           eggStr = eggs.name,
                           noddleStr = noddle.noddleName
                       }).ToListAsync();



            return temp.ToList();
        }

        public void Save()
        {
            _boilEggTableRepository.Commit();
            _boilNoddleTableRepository.Commit();
        }
    }
}
