using Microsoft.Data.SqlClient;
using MyWorkerService_Core.Entities;
using MyWorkerService_Data.Abstract;
using MyWorkerService_Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkerService_Data.Concrete
{
    public class UrunRepository : IUrunRepository
    {
        private readonly DbContext _db;

        public UrunRepository(DbContext db)
        {
            _db = db;
        }

        public List<Urun> GetDeletedProductsWithImages()
        {
            var list = new List<Urun>();

            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand("sp_UrunSilinmis_ResimleriGetir", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int urunId = reader.GetInt32(reader.GetOrdinal("UrunID"));

                var urun = list.FirstOrDefault(x => x.UrunID == urunId);
                if (urun == null)
                {
                    urun = new Urun
                    {
                        UrunID = urunId,
                        Silindi = true
                    };
                    list.Add(urun);
                }

                var resim = new Resim
                {
                    ResimID = reader.GetInt32(reader.GetOrdinal("ResimID")),
                    UrunID = urunId,
                    Silindi = reader.GetBoolean(reader.GetOrdinal("ResimSilindi"))
                };

                urun.Resimler.Add(resim);
            }

            return list;
        }

        public void UpdateResimSilindi(int resimId)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand("UPDATE Resim SET Silindi = 1 WHERE ResimID = @ResimID", conn);
            cmd.Parameters.AddWithValue("@ResimID", resimId);

            cmd.ExecuteNonQuery();
        }
    }
}
