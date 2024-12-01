using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportPit.Models;
using SportPit.Repositories.Interfaces;

namespace SportPit.Controllers;

public class ProductsController(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor) : Controller
{
    public async Task<IActionResult> Index()
    {
        if ((bool)!httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        if (!(bool)(httpContextAccessor.HttpContext?.User.IsInRole(UserRoles.Admin)))
        {
            return RedirectToAction("Login", "Account");
        }

        var products = await productRepository.GetAllAsync();

        return View(products);
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await productRepository.GetByIdAsync(id.Value);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Img,Price,Description")] Product product)
    {
        if (ModelState.IsValid)
        {
            await productRepository.AddAsync(product);

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await productRepository.GetByIdAsync(id.Value);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Img,Price,Description")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await productRepository.UpdateAsync(product);
            }
            catch(Exception ex)
            {
                if (ex is Exception)
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await productRepository.GetByIdAsync(id.Value);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await productRepository.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}