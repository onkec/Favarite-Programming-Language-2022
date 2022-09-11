using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaveProgrammingLang.Data;
using FaveProgrammingLang.Models;

namespace FaveProgrammingLang.Controllers
{
    public class SurveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
              return _context.Survey != null ? 
                          View(await _context.Survey.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Survey'  is null.");
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,UserName,UserSurname,FaveProgrammingLang")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();

                TempData["ArletMessage"] = "Survey Created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,UserName,UserSurname,FaveProgrammingLang")] Survey survey)
        {
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["ArletMessage"] = "Survey Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Survey == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Survey'  is null.");
            }
            var survey = await _context.Survey.FindAsync(id);
            if (survey != null)
            {
                _context.Survey.Remove(survey);
            }
            
            await _context.SaveChangesAsync();
            TempData["ArletMessage"] = "Survey Deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyExists(int id)
        {
          return (_context.Survey?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
