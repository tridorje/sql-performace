using Project.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Interfaces
{
    public interface IMohingaService : IDisposable
    {

        Task<List<MohingaViewModel>> MakeMohinga();
        void Save();
    }
}
