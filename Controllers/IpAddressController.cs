using IpManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IpManagement.Controllers
{
    public class IpAddressController : Controller
    {
        public readonly IpDbcontext _context;

        public IpAddressController(IpDbcontext context)
        {
            _context = context;
        }

        //Get :IpAdress
        public async Task<IActionResult> Index()
        {
            var IpAddresses = await _context.IpAddresses.ToListAsync();
            return View(IpAddresses);
        }

        //GET: IpAddress/Create
        public IActionResult Create () 
        { 
            return View();
        }


        //POST: IpAddress/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (IpAddressModel ipAddressModel)
        {
            if(ModelState.IsValid)
            {
                _context.IpAddresses.Add(ipAddressModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ipAddressModel);
        }

        //POST: IpAddresss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IpAddressModel ipAddressModel)
        {
            if(id != ipAddressModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(ipAddressModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ipAddressModel);
        }

        //GET: IpAddress/Delete/5
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var ipAAddressModel = _context.IpAddresses.Find(id);
            if (ipAAddressModel == null)
            {
                return NotFound();
            }
            return View(ipAAddressModel);
        }


        // GET: Api/IpAddress
        [HttpGet("Api/IpAddress")]
        public async Task<IActionResult> GetAllIpAddresses()
        {
            var ipAddresses = await _context.IpAddresses.ToListAsync();
            return Ok(ipAddresses); // Return the list of IP addresses as JSON
        }


        //POST: IpAddress/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ipAddressModel = _context.IpAddresses.Find(id);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
