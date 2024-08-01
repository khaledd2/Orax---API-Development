using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer;
using AutoMapper;
using PresentationLayer.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Product>>> AddProduct([FromBody] ProductDTO product)
        {
            // if product doesn't exists 
            if (product == null)
            {
                return BadRequest(new BaseResponse<Product>(data: null, message: "لم يتم العثور على العنصر", errors: [], success: false));
            }

            // to only accept data required 
            var _product = _mapper.Map<Product>(product);

            var newProduct = await _productService.AddProductAsync(_product);
            return Ok(new BaseResponse<Product>(data: _product, message: "تمت الاضافة بنجاح !", errors: [], success: true));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Product>>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            // if product doesn't exists 
            if (product == null)
            {
                return NotFound(new BaseResponse<Product>(data: null, message: "لم يتم العثور على العنصر", errors: [], success: false));
            }

            return Ok(new BaseResponse<Product>(data: product, message: "تم جلب العنصر بنجاح !", errors: [], success: true));
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Product>>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(new BaseResponse<IEnumerable<Product>>(data: products, message: "تم جلب البيانات بنجاح !", errors: [], success: true));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Product>>> UpdateProduct(int id, [FromBody] Product product)
        {
            // if the id requested doesn't match product id
            if (id != product.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateProductAsync(product);
            if (updatedProduct == null)
            {
                return NotFound(new BaseResponse<Product>(data: null, message: "حدث خطأ", errors: [], success: false));
            }

            return Ok(new BaseResponse<Product>(data: updatedProduct, message: "تم تحديث العنصر بنجاح !", errors: [], success: true));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Product>>> DeleteProduct(int id)
        {
            var success = await _productService.DeleteProductAsync(id);

            // if delete didn't succeed 
            if (!success)
            {
                return NotFound(new BaseResponse<Product>(data: null, message: "لم يتم العثور على العنصر", errors: [], success: false));
            }
            return NoContent();
        }
    }
}
