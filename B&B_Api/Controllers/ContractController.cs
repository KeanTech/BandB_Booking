using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public ContractController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetContract/{id}")]
        public async Task<ActionResult<DbContract>> GetContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return contract;
        }

        [HttpPost]
        [Route("CreateContract")]
        public async Task<ActionResult<DbContract>> CreateContracts(List<Contract> contracts)
        {
            if (contracts == null)
            {
                return BadRequest();
            }
            else
            {
                foreach (var contract in contracts)
                {
                    DbContract newContract = new DbContract(contract);
                    _context.Add(newContract);
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                    throw;
                }
                return Ok();
            }
        }

        [HttpPost]
        [Route("CreateContract")]
        public async Task<ActionResult<DbContract>> CreateContract(Contract contract)
        {
            var contractCheck = _context.Contracts.Where(x => x.Id == contract.Id).FirstOrDefault();
            if (contractCheck == null)
            {
                return BadRequest();
            }
            else
            {
                DbContract newContract = new DbContract(contract);
                _context.Add(newContract);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                    throw;
                }
                return CreatedAtAction("CreateContract", new { id = newContract.Id }, newContract);
            }
        }

        [HttpPost]
        [Route("DeleteContract")]
        public async Task<ActionResult<DbContract>> DeleteContract(Contract contract)
        {
            var contractToDelete = await _context.Contracts.FindAsync(contract.Id);
            if (contractToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(contractToDelete);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
        }

        [HttpPost]
        [Route("UpdateContract")]
        public async Task<ActionResult<DbContract>> UpdateContract(Contract contract)
        {
            var contractToUpdate = _context.Contracts.Where(x => x.Id == contract.Id).FirstOrDefault();
            if (contractToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                contractToUpdate.FromDate = contract.FromDate;
                contractToUpdate.ToDate = contract.ToDate;
                contractToUpdate.RoomId = contract.RoomId;
                _context.Update(contractToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                    throw;
                }
                return Ok();
            }
        }
    }
}
