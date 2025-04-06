using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventease.Models;

namespace EventEase.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Event) // Include the event data with the booking
                .ThenInclude(e => e.Venue) // Include the venue data with the event
                .ToListAsync();
            return View(bookings);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Bookings
                .Include(b => b.Event) // Include event details
                .ThenInclude(e => e.Venue) // Include venue details for the event
                .FirstOrDefaultAsync(m => m.BookingID == id);

            if (booking == null) return NotFound();

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            // Populate the dropdown with events from the database
            ViewData["Events"] = new SelectList(_context.Events, "EventID", "Title");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,CustomerName,BookingDate,EventID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking); // Add the new booking to the database
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to the bookings index page
            }

            // If validation fails, pass events back to the view to repopulate the dropdown
            ViewData["Events"] = new SelectList(_context.Events, "EventID", "Title", booking.EventID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            // Pass events to the view for the dropdown
            ViewData["Events"] = new SelectList(_context.Events, "EventID", "Title", booking.EventID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,CustomerName,BookingDate,EventID")] Booking booking)
        {
            if (id != booking.BookingID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking); // Update the booking in the database
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Bookings.Any(b => b.BookingID == booking.BookingID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index)); // Redirect to the bookings index page
            }

            // If validation fails, pass events back to the view to repopulate the dropdown
            ViewData["Events"] = new SelectList(_context.Events, "EventID", "Title", booking.EventID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.Bookings
                .Include(b => b.Event) // Include event details
                .FirstOrDefaultAsync(m => m.BookingID == id);

            if (booking == null) return NotFound();

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking); // Remove the booking from the database
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index)); // Redirect back to bookings index page
        }
    }
}


