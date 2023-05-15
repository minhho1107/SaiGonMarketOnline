using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BH_Online.Models;
using PagedList.Core;
using System.IO;
using BH_Online.Helpper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BH_Online.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPagesController : Controller
    {
        private readonly BHOnlineContext _context;

        public INotyfService _notyfService { get; }
        public AdminPagesController(BHOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        // GET: Admin/AdminPages
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var lsPages = _context.Pages
                .AsNoTracking()
                .OrderByDescending(x => x.PageId);
            PagedList<Page> models = new PagedList<Page>(lsPages, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/AdminPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageName,Contents,Thumb,Published,Title,MetaDesc,MetaKey,Alias,CreatedDate,Ordering")] Page page, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                //xử lý thumb
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imgname = Utilities.SEOUrl(page.PageName) + extension;
                    page.Thumb = await Utilities.UploadFile(fThumb, @"pages", imgname.ToLower());
                }
                if (string.IsNullOrEmpty(page.Thumb)) page.Thumb = "default.jpg";
                page.Alias = Utilities.SEOUrl(page.PageName);
                _context.Add(page);
                _notyfService.Success("Thêm page thành công");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Admin/AdminPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: Admin/AdminPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,PageName,Contents,Thumb,Published,Title,MetaDesc,MetaKey,Alias,CreatedDate,Ordering")] Page page, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != page.PageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //xử lý thumb
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string imgname = Utilities.SEOUrl(page.PageName) + extension;
                        page.Thumb = await Utilities.UploadFile(fThumb, @"pages", imgname.ToLower());
                    }
                    if (string.IsNullOrEmpty(page.Thumb)) page.Thumb = "default.jpg";
                    page.Alias = Utilities.SEOUrl(page.PageName);
                    _context.Update(page);
                    _notyfService.Success("Cập nhật page thành công");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageId))
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
            return View(page);
        }

        // GET: Admin/AdminPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/AdminPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            _context.Pages.Remove(page);
            _notyfService.Success("Xóa page thành công");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _context.Pages.Any(e => e.PageId == id);
        }
    }
}
