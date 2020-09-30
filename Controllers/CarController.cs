using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetGarage.Models;



namespace NetGarage.Controllers
{
    public class CarController : Controller
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;
        }

        // GET: Car
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }       

        // GET: Car/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Car());
            else
                return View(_context.Cars.Find(id));
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CarId,Manufacturer,Model,Year,ProductRegion")] Car car)
        {
            if (ModelState.IsValid)
            {
                if(car.CarId==0)
                    _context.Add(car);
                else
                    _context.Update(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        //GET: Car/Delete
        public async Task<IActionResult>Delete(int? id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
