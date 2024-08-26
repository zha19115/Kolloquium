using Kolloquium.Data;
using Kolloquium.Models;
using Kolloquium.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Kolloquium.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext dbContext;

        public CustomersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel viewModel)
        {
            var customer = new Customer
            {
                c_name = viewModel.c_name,
                c_phone = viewModel.c_phone,
                c_email = viewModel.c_email,
                c_newsletter = viewModel.c_newsletter
            };

            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customer = await dbContext.Customers.ToListAsync();
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid c_id)
        {
            var customer= await dbContext.Customers.FindAsync(c_id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer viewModel)
        {

            var customer = await dbContext.Customers.FindAsync(viewModel.c_id);

            if (customer is not null)
            {
                customer.c_name = viewModel.c_name;
                customer.c_email = viewModel.c_email;
                customer.c_phone = viewModel.c_phone;
                customer.c_newsletter = viewModel.c_newsletter;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Customers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer viewModel)
        {
            var customer = await dbContext.Customers.FindAsync(viewModel.c_id);
            
            if (customer is null)
            {
             
                return NotFound();
            }


            if (customer is not null)
            {
                dbContext.Customers.Remove(customer);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Customers");
        }
    }
}
