using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdsPoject.BussinessLogic;
using AdsProyect.BussinessEntities;

namespace AdsProject.UserInterfacee.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBL categoryBL = new CategoryBL();
        
        // GET: CategoryController ---muestra el listado de la categoria
        public async Task<IActionResult> Index(Category category = null)
        {
            if(category == null)
                category = new Category();

            if (category.Top_Aux == 0)
                category.Top_Aux = 10; //esto es el numero de categorias a mostrar
            else if (category.Top_Aux == -1)
                category.Top_Aux = 0;
                                                      //le paso el parametro que configure anteriormente
            var categories = await categoryBL.SearchAsync(category);
            ViewBag.Top = category.Top_Aux;

            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
