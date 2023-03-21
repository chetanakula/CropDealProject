using CropDealProject.Models;
using CropDealProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public readonly InvoiceService _invoiceService;
        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        #region GetAll
        // [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var invoice = await _invoiceService.GetAll();
            return Ok(invoice);


        }
        #endregion

        #region GetById
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)   // working
        {

            var invoice = await _invoiceService.GetById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);

        }

        #endregion

        #region Add
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([Bind()] Invoice entity)
        {
            
            
                await _invoiceService.Add(entity);
                await _invoiceService.Save();
                return (Ok());
            
           

        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(int id,[FromBody] Invoice invoice)  // not working in swagger but working in postman
        {
            try
            {
                await _invoiceService.Edit(id,invoice);
                await _invoiceService.Save();
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            await _invoiceService.Delete(id);
            return Ok();

        }
        #endregion
    }
}
