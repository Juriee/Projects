using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }
        
        //Get /api/customers
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }
        //Get /api/customers/1
        [HttpGet]
        public CustomerDTO GetCustomer(byte id)
        {
            return Mapper.Map<Customer,CustomerDTO>(_context.Customers.SingleOrDefault(c => c.Id == id));
        }
        //Post api/customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerDto.Id = customer.Id;
                return customerDto;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        //Put /api/customers/1
        [HttpPut]
        public void UpdateCustomers(int id, CustomerDTO customerDto)
        {
            if (ModelState.IsValid)
            {

              
                var getCustomerInDb=   _context.Customers.SingleOrDefault(c => c.Id == id);
                
                if (getCustomerInDb!=null)
                {
                     Mapper.Map(customerDto, getCustomerInDb);

                    _context.SaveChanges();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }
        
        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (ModelState.IsValid)
            {

                var getCustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (getCustomerInDb != null)
                {

                    _context.Customers.Remove(getCustomerInDb);
                    _context.SaveChanges();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
