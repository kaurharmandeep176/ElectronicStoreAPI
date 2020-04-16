using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        ElectronicStoreEntities obj = new ElectronicStoreEntities();

        public ActionResult SalaryDetails()
        {
            return View(obj.Salary_Table.ToList());
        }

        // GET: Salary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Salary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salary/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Salary_Table db)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Salary_Table.Add(db);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("SalaryDetails");

        }

        // GET: Salary/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Salary_Table where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Salary/Edit/5
        [HttpPost]
        public ActionResult Edit(Salary_Table IdToEdit)
        {
            var orignalRecord = (from m in obj.Salary_Table where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("SalaryDetails");


        }

        // GET: Salary/Delete/5
        public ActionResult Delete(Salary_Table IdToDel)
        {
            var d = obj.Salary_Table.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj.Salary_Table.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("SalaryDetails");
        }

        // POST: Salary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
