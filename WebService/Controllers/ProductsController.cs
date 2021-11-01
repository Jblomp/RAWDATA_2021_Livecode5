using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;


namespace WebService.Controllers
{
    
[ApiController]
[Route("api/products")]

    public class ProductsController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public ProductsController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _dataService.GetProducts();
            var model = products.Select(CreateProductViewModel);
            return Ok(model);
        }
        
        private ProductViewModel CreateProductViewModel(Product product)
        {
            var model = _mapper.Map<ProductViewModel>(product);
            model.Url = GetUrl(product);
            return model;
        }
        private string GetUrl(Product product)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetProducts), new { product.Id });
        }
    }
}