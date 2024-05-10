using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.DTOs;
using TodoList.UiWeb.Data;

namespace TodoList.UiWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly TodoListUiWebContext _context;

        public DashboardController(TodoListUiWebContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDoListDTO.ToListAsync());
        }

        // GET: Dashboard/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoListDTO = await _context.ToDoListDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoListDTO == null)
            {
                return NotFound();
            }

            return View(toDoListDTO);
        }

        // GET: Dashboard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,StartDate,EndDate,Status,Id")] ToDoListDTO toDoListDTO)
        {
            if (ModelState.IsValid)
            {
                toDoListDTO.Id = Guid.NewGuid();
                _context.Add(toDoListDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoListDTO);
        }

        // GET: Dashboard/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoListDTO = await _context.ToDoListDTO.FindAsync(id);
            if (toDoListDTO == null)
            {
                return NotFound();
            }
            return View(toDoListDTO);
        }

        // POST: Dashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Description,StartDate,EndDate,Status,Id")] ToDoListDTO toDoListDTO)
        {
            if (id != toDoListDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoListDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListDTOExists(toDoListDTO.Id))
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
            return View(toDoListDTO);
        }

        // GET: Dashboard/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoListDTO = await _context.ToDoListDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoListDTO == null)
            {
                return NotFound();
            }

            return View(toDoListDTO);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var toDoListDTO = await _context.ToDoListDTO.FindAsync(id);
            if (toDoListDTO != null)
            {
                _context.ToDoListDTO.Remove(toDoListDTO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListDTOExists(Guid id)
        {
            return _context.ToDoListDTO.Any(e => e.Id == id);
        }
    }
}
