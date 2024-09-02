using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Repositories;

namespace ProductManager.Controllers;

public class ProductController : Controller
{
	ProductsRepository _productsRepository = new();
	
	[HttpGet]
	public IActionResult Index()
	{
		return View(_productsRepository.GetProducts());
	}

	[HttpPost]
	public IActionResult RemoveProduct(string Name)
	{
		_productsRepository.RemoveProduct(Name);
		return RedirectToAction("Index");
	}
	
	[HttpGet]
	public IActionResult AddProduct()
	{
		return View();
	}

	[HttpPost]
	public IActionResult AddProduct(Product product)
	{
		_productsRepository.AddProduct(product);
		return RedirectToAction("Index");
	}

}