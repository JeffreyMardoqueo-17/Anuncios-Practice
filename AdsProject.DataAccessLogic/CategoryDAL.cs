using AdsProyect.BussinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.DataAccessLogic
{
    public class CategoryDAL
    {
        public static async Task<int> CreateAsync(Category category)
        {
            int result = 0;
            using(var dbContexto = new ContextoDB()) //el comando using hace un proceso de ejecucion
            {
                dbContexto.Category.Add(category); //agrego un nuevo categorua
                result = await dbContexto.SaveChangesAsync();//se guarda a la base de datos
            }
            return result;
        }

        public static async Task<int> UpdateAsync(Category category)
        {
            int result = 0;
            using (var bdContexto = new ContextoDB())//hago una instancia de la base de datos
            {
                                                                              //expresion landam
                var categoryBD = await bdContexto.Category.FirstOrDefaultAsync(c => c.Id == category.Id); //lo busco 
                if(categoryBD != null)//verifico que no este nulo
                {
                    categoryBD.Name = category.Name; //actualizo las propiedades
                    bdContexto.Update(categoryBD); //se guarda en memora
                    result = await bdContexto.SaveChangesAsync(); //guardo en la base de datos con SaveChangesAsync
                }
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Category category)
        {
            int result = 0;
            using (var bdContexto = new ContextoDB()) //istancio la coneccion
            {
                var categoryBD = await bdContexto.Category.FirstOrDefaultAsync(c => c.Id == category.Id); //busco el id
                if (categoryBD != null)//verifico que no este nulo
                {
                    bdContexto.Category.Remove(categoryBD);//elimino anivel de memoria la categoria
                    result = await bdContexto.SaveChangesAsync();//le digo a la BD que se elimine y se guarde
                }
            }
            return result;
        }
    }
}
