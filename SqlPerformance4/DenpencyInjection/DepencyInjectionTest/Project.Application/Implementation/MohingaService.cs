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


        public MohingaService(IBoilEggTableRepository boilEggTableRepository)
        {

            _boilEggTableRepository = boilEggTableRepository;
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

            Save();



            

            var temp = await (from eggs in _boilEggTableRepository.FindAll()

                       select new MohingaViewModel()
                       {
                           ID = eggs.Id,
                           eggStr = eggs.name,
                           noddleStr = ""
                       }).ToListAsync();



            return temp.ToList();
        }

        public void Save()
        {
            _boilEggTableRepository.Commit();
        }
    }
}
