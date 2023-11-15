using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hotels.Models;
using Hotels.Data;

namespace Hotels.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult CreateNewRecord(Hotel hotel)
    {
        _context.hotel.Add(hotel);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int Id)
    {
        var hoteldelete = _context.hotel.SingleOrDefault(x => x.Id == Id);
        _context.hotel.Remove(hoteldelete);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    public IActionResult fillter(string city)
    {
        var findhotels = _context.hotel.Where(x => x.City.Contains(city));
        return View(findhotels);

    }

    public IActionResult Edit(int Id)
    {
        var hotleedit = _context.hotel.SingleOrDefault(x => x.Id == Id);
        return View(hotleedit);
    }
    public IActionResult Update(Hotel hotel)
    {
        _context.hotel.Update(hotel);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        var hotel = _context.hotel.ToList();
        return View(hotel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

