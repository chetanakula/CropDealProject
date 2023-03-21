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
    public class CropOnSaleController : ControllerBase
    {
        public readonly CropOnSaleService _croponSale;
        public CropOnSaleController(CropOnSaleService croponSale)
        {
            _croponSale = croponSale;
        }

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {


            var result = await _croponSale.GetAll();
            return Ok(result);

        }
        #endregion

        #region GetById
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var result = await _croponSale.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        #endregion

        #region Insert
        [Authorize(Roles = "Farmer")]
        [HttpPost]
        public async Task<IActionResult> Insert([Bind()] CropOnSale entity)
        {

            await _croponSale.Insert(entity);
            await _croponSale.Save();
            return Ok();

        }


        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(int id,[FromBody] CropOnSale entity)
        {
            try
            {
                if (id != entity.CropSaleId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _croponSale.Edit(id, entity);
                // await _croponSale.Save();
                return Ok("Updated Successfully");
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

            await _croponSale.Delete(id);
            return Ok();

        }
        #endregion
    }
}
