using System.Diagnostics;
using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Controllers;

public class DashbardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashbardController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult CreateNewHotel(Hotel hotels)
    {
        if (ModelState.IsValid)
        {
            _context.hotel.Add(hotels);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        var hotel = _context.hotel.ToList();
        return View("Index", hotel);
        
    }
    public IActionResult Delete(int Id)
    {
        var hoteldelete = _context.hotel.SingleOrDefault(x => x.Id == Id);
        _context.hotel.Remove(hoteldelete);
        _context.SaveChanges();
        return RedirectToAction("Index");

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
    [HttpPost]
    public IActionResult Index(string city)
    {
        var hotel = _context.hotel.Where(x=>x.City.Equals(city));
        return View(hotel);

    }
    public IActionResult Index()
    {
        var hotel = _context.hotel.ToList();
        return View(hotel);

    }
    public IActionResult Rooms()
    {
        var hotel = _context.hotel.ToList();
        ViewBag.hotel = hotel;
        var rooms = _context.rooms.ToList();
        return View(rooms);

    }
    public IActionResult RoomDetails()
    {
        var hotel = _context.hotel.ToList();
        ViewBag.hotel = hotel;
        var rooms = _context.rooms.ToList();
        ViewBag.rooms = rooms;
        var roomDetails = _context.roomDetails.ToList();

        return View(roomDetails);

    }

    public IActionResult CreateNewRooms(Rooms rooms)
    {
        _context.rooms.Add(rooms);
        _context.SaveChanges();
        return RedirectToAction("Rooms");

    }
    public IActionResult CreateNewRoomDetails(RoomDetails roomDetails)
    {
        _context.roomDetails.Add(roomDetails);
        _context.SaveChanges();
        return RedirectToAction("RoomDetails");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

