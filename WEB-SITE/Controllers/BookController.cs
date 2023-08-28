using Microsoft.AspNetCore.Mvc;
using WEB_SITE.data;
using WEB_SITE.Models.Domain;
using Microsoft.EntityFrameworkCore;
using WEB_SITE.Models;

namespace WEB_SITE.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext mvcApplicationDbContext;
		public BookController(ApplicationDbContext mvcApplicationDbContext)
		{
			this.mvcApplicationDbContext = mvcApplicationDbContext;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var book = await mvcApplicationDbContext.Book.ToListAsync();
			return View(book);
		}
		// su dung phuong thuc 
		[HttpGet]
		public IActionResult Add()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddBookViewModel addBookRequest)
		{
			var book = new Book()
			{
				Id = addBookRequest.Id,
				Name = addBookRequest.Name,
				Nxb = addBookRequest.Nxb,
				Specialized = addBookRequest.Specialized,
				Image = addBookRequest.Image,
				DayCreate = addBookRequest.DayCreate,
			};

			await mvcApplicationDbContext.Book.AddAsync(book);
			await mvcApplicationDbContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}


		[HttpGet]
		public async Task<IActionResult> View(int Id)
		{
			var book = await mvcApplicationDbContext.Book.FirstOrDefaultAsync(S => S.Id == Id);
			if (book != null)
			{
				var viewModel = new UpdateBookViewModel()
				{
					Id = book.Id,
					Name = book.Name,
					Nxb = book.Nxb,
					Specialized = book.Specialized,
					Image = book.Image,
					DayCreate = book.DayCreate,
					DayUpdate = book.DayUpdate,
				};
				return await Task.Run(() => View("View", viewModel));
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> View(UpdateBookViewModel model)
		{
			var book = await mvcApplicationDbContext.Book.FindAsync(model.Id);
			if (book != null)
			{
				book.Name = model.Name;
				book.Nxb = model.Nxb;
				book.Specialized = model.Specialized;
				book.Image = model.Image;
				book.DayCreate = model.DayCreate;
				book.DayUpdate = model.DayUpdate;

				await mvcApplicationDbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(UpdateBookViewModel model)
		{
			var book = await mvcApplicationDbContext.Book.FindAsync(model.Id);
			if (book != null)
			{
				mvcApplicationDbContext.Book.Remove(book);
				await mvcApplicationDbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}
	}
}
