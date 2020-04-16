using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Models;
using System.IO;
using System.Net;
using System.Data.Entity;

namespace ElectronicStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ElectronicStoreEntities obj = new ElectronicStoreEntities();

        [HttpGet]
        public ActionResult ProductList()
        {
            return View(obj.Product_Table.ToList());
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase file,Product_Table prod)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/ProductImage/"), _filename);
            prod.Image = "~/ProductImage/" + _filename;
            if (extension.ToLower()==".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png") {

                if (file.ContentLength <= 1000000)
                {

                    obj.Product_Table.Add(prod);
                    if (obj.SaveChanges() > 0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "Record added ";
                        ModelState.Clear();
                    }
                }
                else {
                    ViewBag.msg = "Sizeis In valid  ";
                }
            }
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var img = obj.Product_Table.Find(id);
            Session["imgPath"] = img.Image;
            if (img==null) {
                return HttpNotFound();
            }
            return View(img);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFile file,Product_Table prod)
        {
            if (ModelState.IsValid) {

                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extension = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/ProductImage/"), _filename);
                    prod.Image = "~/ProductImage/" + _filename;
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {

                        
                        if (file.ContentLength <= 1000000)
                        {

                            obj.Entry(prod).State = EntityState.Modified;
                            string oldImgPath = Request.MapPath(Session["imgPath"].ToString());

                            if (obj.SaveChanges() > 0)
                            {
                                file.SaveAs(path);
                                if (System.IO.File.Exists(oldImgPath)) {
                                    System.IO.File.Delete(oldImgPath);
                                }
                                TempData["msg"] = "Record Updated ";

                            }
                        }
                        else
                        {
                            ViewBag.msg = "Sizeis In valid  ";
                        }
                    }


                }
                else {
                    prod.Image = Session["imgPath"].ToString();
                    obj.Entry(prod).State = EntityState.Modified;
                    if (obj.SaveChanges()>0) {
                        TempData["msg"] = "Data Updated ";
                        return RedirectToAction("ProductList");
                    }
                }
            }



            return View();



        }


        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult Delete(Product_Table IdToDelete)
        {
            var d = obj.Product_Table.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            obj.Product_Table.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("ProductList");

        }

        // POST: Customer/Delete/5
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