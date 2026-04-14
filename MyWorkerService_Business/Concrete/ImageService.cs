using Microsoft.Extensions.Options;
using MyWorkerService_Business.Abstract;
using MyWorkerService_Core.Options;
using MyWorkerService_Data.Abstract;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkerService_Business.Concrete
{
    public class ImageService : IImageService
    {


        private readonly IUrunRepository _urunRepository;
        private readonly WorkerSettings _settings;




        public ImageService(
        IUrunRepository urunRepository,
        IOptions<WorkerSettings> settings)
        {
            _urunRepository = urunRepository;
            _settings = settings.Value;
        }

        public void CleanImages()
        {
            var policy = Policy
                .Handle<Exception>()
                .Retry(_settings.RetryCount);

            policy.Execute(() =>
            {
                var urunler = _urunRepository.GetDeletedProductsWithImages();

                foreach (var urun in urunler)
                {
                    if (!urun.Silindi) continue;

                    foreach (var resim in urun.Resimler)
                    {
                        if (!resim.Silindi)
                        {
                            _urunRepository.UpdateResimSilindi(resim.ResimID);
                        }
                    }
                }
            });
        }
    }
}
