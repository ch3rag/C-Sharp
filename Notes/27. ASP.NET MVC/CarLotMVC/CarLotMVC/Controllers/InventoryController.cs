﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoLotDALEF.Models;
using AutoLotDALEF.Repos;
using System.Data.Entity.Infrastructure;

namespace CarLotMVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryRepo repo = new InventoryRepo();

        // GET: Inventory
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = repo.GetOne(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Make,Color,PetName")] Inventory inventory)
            {
            if (!ModelState.IsValid) return View(inventory);
            try {
                repo.Add(inventory);
            } catch(Exception ex) {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(inventory);
            }
            return RedirectToAction("Index");
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = repo.GetOne(id);
            if (inventory == null) 
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Color,PetName,TimeStamp")] Inventory inventory)
        {
            if (!ModelState.IsValid) return View(inventory);
            try {
                repo.Save(inventory);
                
            } catch(DbUpdateConcurrencyException ex) {
                ModelState.AddModelError(string.Empty, $@"Unable to save record. Another user has updated it. {ex.Message}");
                return View(inventory);
            } catch(Exception ex) {
                ModelState.AddModelError(string.Empty, $@"Unable to save record. {ex.Message}");
                return View(inventory);
            }
            return RedirectToAction("Index");
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = repo.GetOne(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete( [Bind(Include = "Id, TimeStamp")]Inventory car)
        {
            try {
                repo.Delete(car);
            } catch(DbUpdateConcurrencyException ex) {
                ModelState.AddModelError(string.Empty, $@"Unable to delete record. Another user has updated it. {ex.Message}");
            } catch(Exception ex) {
                ModelState.AddModelError(string.Empty, $@"Unable to delete record. {ex.Message}");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
