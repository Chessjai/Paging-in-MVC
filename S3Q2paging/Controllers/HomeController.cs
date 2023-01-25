using PagedList;
using S3Q2paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace S3Q2paging.Controllers
{
    public class HomeController : Controller
    {
        dbcontext db = new dbcontext();
        studentsrepo Model = new studentsrepo();
        public ActionResult Indexs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var students = from s in db.models
                           orderby s.id
                           select s;
            int pageSize =5;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        //CreateNewStd
        [HttpPost]
        public ActionResult Create(Studentmodel student)
        {
            if (ModelState.IsValid)
            {
                Model.Create(student);
                ViewBag.Msg = "Student is inserted Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg2 = "Somthing Problem";
             return View();
            }

        }
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentmodel student = Model.FinedById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            Studentmodel std = new Studentmodel();
            if (id != null)
            {
                std = Model.FinedById(id);
                if (std != null)
                {
                    return View(std);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        //Conformation Delete

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Model.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentmodel student = Model.FinedById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Studentmodel student)
        {
            if (ModelState.IsValid)
            {
                student = Model.Edit(student);
                ViewBag.Msg = "Data Chenged Successfully";
                // return View(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg2 = "Somthing Problem";
                return View(student);
            }

        }
    } }