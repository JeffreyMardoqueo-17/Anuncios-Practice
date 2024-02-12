using AdsProyect.BussinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.DataAccessLogic
{
    public class AdDAL
    {
        public static async Task<int> CreateAsync(Ad ad)
        {
            int result = 0;
            using (var bdContext = new ContextoDB())
            {
                bdContext.Add(ad);
                await bdContext.SaveChangesAsync();
            }
            return result; 
        }

        public static async Task<int> UpdateAsync(Ad ad)
        {
            int result = 0;
            using (var bdContext = new ContextoDB())
            {
                var adDB = await bdContext.Ad.FirstOrDefaultAsync(a => a.Id == ad.Id);
                if (adDB!= null)
                {
                    adDB.IdCategory = ad.IdCategory;
                    adDB.Title = ad.Title;
                    adDB.Description = ad.Description;
                    adDB.Price = ad.Price;
                    adDB.RegistrationDate = ad.RegistrationDate;
                    adDB.State = ad.State;

                    bdContext.Update(adDB);
                    result = await bdContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Ad ad)
        {
            int result = 0;
            using (var bdContexto = new ContextoDB()) //istancio la coneccion
            {
                var adBD = await bdContexto.Ad.FirstOrDefaultAsync(a => a.Id == ad.Id);
                if(adBD != null)
                {
                    bdContexto.Ad.Remove(adBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Ad> GetByIdAsync(Ad ad)
        {
            var adBD = new Ad();
            using(var bdContexto = new ContextoDB())
            {
                adBD = await bdContexto.Ad.FirstOrDefaultAsync(a => a.Id == ad.Id);
            }
            return adBD;
        }

        public static async Task<List<Ad>> GetAllAsync()
        {
            var ads = new List<Ad>();
            using (var bdContexto = new ContextoDB())
            {
                ads = await bdContexto.Ad.ToListAsync();
            }
            return ads;
        }

        internal static IQueryable<Ad> QuerySelect(IQueryable<Ad> query, Ad ad)
        {
            if (ad.Id > 0)
                query = query.Where(a => a.Id == ad.Id);

            if (ad.IdCategory > 0)
                query = query.Where(a => a.IdCategory == ad.IdCategory);

            if (!string.IsNullOrWhiteSpace(ad.Title))
                query = query.Where(a => a.Title.Contains(ad.Title));

            if (!string.IsNullOrWhiteSpace(ad.Description))
                query = query.Where(a => a.Description.Contains(ad.Description));

            if (ad.Price > 0)
                query = query.Where(a => a.Price == ad.Price);

            if (ad.RegistrationDate.Year > 1900)
            {
                DateTime initialDate = new DateTime(ad.RegistrationDate.Year, ad.RegistrationDate.Month, ad.RegistrationDate.Day, 0, 0, 0);
                DateTime FinalDate = initialDate.AddDays(1).AddMicroseconds(-1);

                query = query.Where(a => a.RegistrationDate > initialDate && a.RegistrationDate <= FinalDate);
            }

            if (!string.IsNullOrWhiteSpace(ad.State))
                query = query.Where(a => a.State.Contains(ad.State));

            query = query.OrderByDescending(a => a.Id).AsQueryable();
            if(ad.Top_Aux > 0)
                query = query.Take(ad.Top_Aux).AsQueryable();

            return query;
        }

    }
}
