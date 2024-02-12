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
        public static async Task<Category> GetByIdAsync(Category category)
        {
            var categoryDB = new Category();
            using (var bdContexto = new ContextoDB())
            {
                var categoryBD = await bdContexto.Category.FirstOrDefaultAsync(c => c.Id == category.Id); //busco el id
            }
            return categoryDB;
        }
        public static async Task<List<Category>> GetAllAsync()
        {
            var categories = new List<Category>(); //una variable de lo que llevara una lista de Categorias
            using (var bdContexto = new ContextoDB()) //creo el acceso a la BD
            {
                categories = await bdContexto.Category.ToListAsync(); //le digo que categories contenga la lista de categorias, osea lo de l BD
            }
            return categories;
        }

        internal static IQueryable<Category> QuerySelect(IQueryable<Category> query, Category category)//permite hacer consultas el IQueryable 
        {
            if (category.Id > 0)
            {
                query = query.Where(c => c.Id == category.Id);//si el ID de la categorua trae un id mayor  aceroquiere decir que se filtrara por ID
            }
            if (!string.IsNullOrWhiteSpace(category.Name))
            {
                //contains es para que se busque bien
                query = query.Where(c => c.Name.Contains(category.Name));//ahora si es string se filtrara por Nombre
            }
            query = query.OrderByDescending(c => c.Id); //ordenamiento por ID, que los ordene de manera desendente

            if(category.Top_Aux > 0)
            {
                query = query.Take(category.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<Category>> SearchAsync(Category category)
        {
            var categories = new List<Category>();
            using(var bdContext = new ContextoDB())
            {
                //especificamos que seria buscable
                var select = bdContext.Category.AsQueryable();//transformo a las categorias en consultuables
                select = QuerySelect(select, category);//Sleccion mas la clase
                categories = await select.ToListAsync();//mostramos la listaa
            }
            return categories;
        }
    }
}
