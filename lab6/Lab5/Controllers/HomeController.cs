using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesDbContext _context;

        public HomeController(MoviesDbContext context)
        {
            _context = context;
            _context.Movies.Include(x => x.Genre).ToListAsync();

        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            var m = new MovieDto
            {
                AllGenres = _context.Genres.Select(x => x.Name).ToList()
            };
            return View(m);
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Rating,TrailerLink,Genre")] MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            var genre = _context.Genres.FirstOrDefault(x => x.Name == movie.Genre);
            if (genre == null)
            {
                genre = new Genre { Id = 0, Name = movie.Genre };
            }

            Movie m = new Movie
            {
                Id = 0,
                Title = movie.Title,
                Description = movie.Description,
                Rating = movie.Rating,
                TrailerLink = movie.TrailerLink,
                Genre = genre
            };
            _context.Add(m);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            
            var movieDto = new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Rating = movie.Rating,
                TrailerLink = movie.TrailerLink,
                Genre = movie.Genre?.Name,
                AllGenres = _context.Genres.Select(x => x.Name).ToList()
            };
            return View(movieDto);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Rating,TrailerLink,Genre")] MovieDto movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            try
            {
                    var movieToUpdate = await _context.Movies
                        .Include(m => m.Genre)
                        .FirstOrDefaultAsync(m => m.Id == id);
                        var genre = _context.Genres.FirstOrDefault(x => x.Name == movie.Genre);
                        if (genre == null)
                        {
                            genre = new Genre { Name = movie.Genre };
                        }
                        movieToUpdate.Title = movie.Title;
                        movieToUpdate.Description = movie.Description;
                        movieToUpdate.Rating = movie.Rating;
                        movieToUpdate.TrailerLink = movie.TrailerLink;
                        movieToUpdate.Genre = genre;


                        _context.Update(movieToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
