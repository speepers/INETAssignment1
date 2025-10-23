using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using INETAssignment1.Data;
using INETAssignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INETAssignment1.Controllers
{
    [Authorize]
    public class ConcertsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly INETAssignment1Context _context;
        private readonly BlobContainerClient _containerClient;

        public ConcertsController(IConfiguration configuration, INETAssignment1Context context)
        {
            _context = context;
            _config = configuration;

            var connectionString = _config.GetConnectionString("AzureStorage");
            var containerName = "concerthub-photo-uploads";
            _containerClient = new BlobContainerClient(connectionString, containerName);
        }

        // GET: Concerts
        public async Task<IActionResult> Index()
        {
            var iNETAssignment1Context = _context.Concert.Include(c => c.concertLocation).Include(c => c.headliningBand);
            return View(await iNETAssignment1Context.ToListAsync());
        }

        // GET: Concerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concert
                .Include(c => c.concertLocation)
                .Include(c => c.headliningBand)
                .FirstOrDefaultAsync(m => m.concertID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // GET: Concerts/Create
        public IActionResult Create()
        {
            ViewData["locationID"] = new SelectList(_context.Location, "locationID", "locationName");
            ViewData["bandID"] = new SelectList(_context.Band, "bandID", "bandName");
            return View();
        }

        // POST: Concerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("concertID,concertName,tourName,bandID,locationID,concertTime, FormFile")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                if (concert.FormFile != null)
                {
                    //string filename = Guid.NewGuid().ToString() + Path.GetExtension(concert.FormFile.FileName);
                    //concert.filename = filename;
                    //string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", filename);

                    //using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Create)) {
                    //    await concert.FormFile.CopyToAsync(fileStream);
                    //}

                    string blobName = Guid.NewGuid().ToString() + Path.GetExtension(concert.FormFile.FileName);
                    IFormFile fileUpload = concert.FormFile;
                    var blobClient = _containerClient.GetBlobClient(blobName);

                    using (var stream = fileUpload.OpenReadStream())
                    {
                        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = fileUpload.ContentType });
                    }

                    string blobURL = blobClient.Uri.ToString();
                    concert.filename = blobURL;
                }
                _context.Add(concert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationID"] = new SelectList(_context.Location, "locationID", "locationName", concert.locationID);
            ViewData["bandID"] = new SelectList(_context.Band, "bandID", "bandName", concert.bandID);
            return View(concert);
        }

        // GET: Concerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concert.FindAsync(id);
            if (concert == null)
            {
                return NotFound();
            }
            ViewData["locationID"] = new SelectList(_context.Location, "locationID", "locationName", concert.locationID);
            ViewData["bandID"] = new SelectList(_context.Band, "bandID", "bandName", concert.bandID);
            return View(concert);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("concertID,concertName,tourName,bandID,locationID,concertTime, FormFile")] Concert concert)
        {
            if (id != concert.concertID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (concert.FormFile != null)
                {
                    string blobName = Guid.NewGuid().ToString() + Path.GetExtension(concert.FormFile.FileName);
                    IFormFile fileUpload = concert.FormFile;
                    var blobClient = _containerClient.GetBlobClient(blobName);

                    using (var stream = fileUpload.OpenReadStream())
                    {
                        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = fileUpload.ContentType });
                    }

                    string blobURL = blobClient.Uri.ToString();
                    concert.filename = blobURL;
                }

                try
                {
                    _context.Update(concert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertExists(concert.concertID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["locationID"] = new SelectList(_context.Location, "locationID", "locationName", concert.locationID);
            ViewData["bandID"] = new SelectList(_context.Band, "bandID", "bandName", concert.bandID);
            return View(concert);
        }

        // GET: Concerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concert
                .Include(c => c.concertLocation)
                .Include(c => c.headliningBand)
                .FirstOrDefaultAsync(m => m.concertID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // POST: Concerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concert = await _context.Concert.FindAsync(id);
            if (concert != null)
            {
                _context.Concert.Remove(concert);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertExists(int id)
        {
            return _context.Concert.Any(e => e.concertID == id);
        }
    }
}