using Blogpage.Models;
using Microsoft.AspNetCore.Mvc;
using BasicBlog;

public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly BlogContext _context;
    public HomeController(BlogContext context) { _context = context; }

    public IActionResult Index()
    {
        return View(_context.BlogPosts.ToList());
    }

    public IActionResult Create() => View(new BlogPost());

    [Microsoft.AspNetCore.Mvc.HttpPost]
    public IActionResult Create(BlogPost post)
    {
        if (ModelState.IsValid)
        {
            _context.BlogPosts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(post);
    }
}
