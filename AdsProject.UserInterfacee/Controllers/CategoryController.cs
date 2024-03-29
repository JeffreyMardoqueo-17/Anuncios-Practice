﻿using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> Details(int id)
        {
            var category = await categoryBL.GetByIdAsync(new Category { Id = id});
            return View(category);
        }

        // GET: CategoryController/Create
        //accion que muerta el formulario para crear una nueva categoria
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }
        //accion que recibe los datos del formulario y los envia a la BD
        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            try
            {
                int result = await categoryBL.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        //accion que muestra el formulario con los datos cargados para modificar
        public async Task<ActionResult> Edit(int id)
        {
            var category = await categoryBL.GetByIdAsync(new Category { Id = id });
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //accion que recibe los datos modificados
        public async Task<ActionResult> Edit(int id, Category category)
        {
            try
            {
                int result = await categoryBL.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var category = await categoryBL.GetByIdAsync(new Category { Id = id });
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Category category)
        {
            try
            {
                int result = await categoryBL.DeleteAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(category);
            }
        }
    }
}
