using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.ViewComponents.Category
{
	public class CategoryList : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public CategoryList(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _categoryService.CategoryList();
			return View(values);
		}
	}
}
