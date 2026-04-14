using MyWorkerService_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkerService_Data.Abstract
{
    public interface IUrunRepository
    {
        List<Urun> GetDeletedProductsWithImages();
        void UpdateResimSilindi(int resimId);
    }
}
