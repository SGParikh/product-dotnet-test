using System;
using System.Web.Mvc;
using Product.Services;
using System.Collections.Generic;
using Product.DomainObjects.Models;

namespace ProductWeb.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // GET
        public ActionResult Index()
        {
            return View(_materialService.GetAll());
        }

        // GET
        public ActionResult View(Int32 id)
        {

            ViewBag.Materials = new SelectList(_materialService.GetAllExceptThisID(id), "MaterialId", "Name");
            return View(_materialService.GetById(id));
        }

        [HttpPost]
        public ActionResult View(Int32 MaterialId, FormCollection collection)
        {
            string strDDLValue = collection["ddlMaterials"].ToString();
            if (strDDLValue != "")
            {
                _materialService.Merge(MaterialId,Convert.ToInt32(strDDLValue));
            }
            return RedirectToAction("Index", "Material",null);
        }
    }
}