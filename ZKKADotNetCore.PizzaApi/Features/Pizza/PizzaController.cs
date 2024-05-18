using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZKKADotNetCore.PizzaApi.Database;
using ZKKADotNetCore.PizzaApi.Queries;
using ZKKADotNetCore.Shared;

namespace ZKKADotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;
        private readonly DapperService _dapperService;

        public PizzaController()
        {
            _appDbcontext = new AppDbContext();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst =await _appDbcontext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var lst = await _appDbcontext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        [HttpPost("Orders")]
        public  async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbcontext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if (orderRequest.Extras.Length > 0)
            {
                //foreach(var x in orderRequest.Extras)
                //{
                //}

                //select*from Tbl_PizzaExtras where PizzaExtraId in (1,2,3,4)

                var lstExtra  = await _appDbcontext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaOrderDetailModel = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();

            await _appDbcontext.PizzaOrders.AddAsync(pizzaOrderModel);
            await _appDbcontext.PizzaOrderDetails.AddRangeAsync(pizzaOrderDetailModel);
            await _appDbcontext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order! Enjou your pizza!",
                TotalAmount = total
            };
            return Ok(response);
        }

        //Without Query
        /*[HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrderAsync(string invoiceNo)
        {
            var item = await _appDbcontext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);  
            var lst = await _appDbcontext.PizzaOrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();

            return Ok(new 
            {
                Order = item,
                OrderDetail = lst
            });

        }*/

        //With Query Dapper
        [HttpGet("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                (
                PizzaQuery.PizzaOrderQuery,
                new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
                (
                PizzaQuery.PizzaOrderDetailQuery,
                new { PizzaOrderInvoiceNo = invoiceNo }
                );
            //Response
            var model = new PizzaOrderInvoiceResponse
            {
                Order = item,
                OrderDetail = lst
            };
            return Ok(model);       
        }
    }
}
