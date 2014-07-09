using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TDS.Domain;
using Web.DataAccess;

namespace Web.Areas.Administration.Controllers
{
    public class LevelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/Levels
        public async Task<ActionResult> Index()
        {
            return View(await db.Levels.ToListAsync());
        }

        // GET: Administration/Levels/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = await db.Levels.FindAsync(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // GET: Administration/Levels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Levels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LevelID,Name,Height,Width")] Level level)
        {
            if (ModelState.IsValid)
            {
                level.LevelID = Guid.NewGuid();
                db.Levels.Add(level);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(level);
        }

        // GET: Administration/Levels/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = await db.Levels.FindAsync(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // POST: Administration/Levels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LevelID,Name,Height,Width")] Level level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(level).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(level);
        }

        // GET: Administration/Levels/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = await db.Levels.FindAsync(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // POST: Administration/Levels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Level level = await db.Levels.FindAsync(id);
            db.Levels.Remove(level);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
