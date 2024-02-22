using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Data;
using OnlineBankingSystem.Models;
using OnlineBankingSystem.Models.Domain;

namespace OnlineBankingSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await mVCDemoDbContext.Customers.ToListAsync();
            return View(customers);

        }



        public CustomerController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addCustomerRequest)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = addCustomerRequest.FirstName,
                LastName = addCustomerRequest.LastName,
                Email = addCustomerRequest.Email,
                Salary = addCustomerRequest.Salary,
                CustomerType = addCustomerRequest.CustomerType
            };
            await mVCDemoDbContext.Customers.AddAsync(customer);
            await mVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var customers = await mVCDemoDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);


            if (customers != null)
            {
                var viewModel = new UpdateCustomerViewModel()
                {
                    Id = customers.Id,
                    FirstName = customers.FirstName,
                    LastName = customers.LastName,
                    Email = customers.Email,
                    Salary = customers.Salary,
                    CustomerType = customers.CustomerType

                };
                return await Task.Run(() => View("View", viewModel));
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateCustomerViewModel model)
        {
            var customer = await mVCDemoDbContext.Customers.FindAsync(model.Id);
            if (customer != null)
            {
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Email = model.Email;
                customer.Salary = model.Salary;
                customer.CustomerType = model.CustomerType; // Use model.CustomerType instead of model.CustomerTypeOptions

                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCustomerViewModel model)
        {
            var customer = await mVCDemoDbContext.Customers.FindAsync(model.Id);
            if(customer!= null)
            {
                mVCDemoDbContext.Customers.Remove(customer); 
                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
