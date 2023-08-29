using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace B_B_api.Controllers
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
        [Route("GetUserContracts{id}")]
        public ActionResult<List<Contract>> GetUserContracts(int id)
        {
            var contractsFromDb = _context.Contracts.Where(x => (x.UserId == id) && (x.State == ContractState.Approved)).ToList();
            if (contractsFromDb != null)
            {
                List<Contract> contractsForFrontend = new List<Contract>();
                foreach (var contract in contractsFromDb)
                {
                    Contract contractConv = new Contract(contract);
                    contractsForFrontend.Add(contractConv);
                }
                return Ok(contractsForFrontend);
            }
            return NotFound("No contracts found");
        }

        [HttpGet]
        [Route("GetPendingContracts{id}")]
        public async Task<ActionResult<List<Contract>>> GetPendingContracts(int id)
        {
            var pendingContracts = _context.Contracts.Where(x => (x.UserId == id) && (x.State == ContractState.Pending)).ToList();
            if (pendingContracts != null)
            {
                List<Contract> frontendConctacts = new List<Contract>();
                foreach (var contract in pendingContracts)
                {
                    Contract frontendContract = new Contract(contract);
                    frontendConctacts.Add(frontendContract);
                }
                return frontendConctacts;
            }
            return NotFound("No pending contracts");
        }

        [HttpGet]
        [Route("GetRejectedContracts{id}")]
        public async Task<ActionResult<List<Contract>>> GetRejectedContracts(int id)
        {
            var pendingContracts = _context.Contracts.Where(x => (x.UserId == id) && (x.State == ContractState.Rejected)).ToList();
            if (pendingContracts != null)
            {
                List<Contract> frontendConctacts = new List<Contract>();
                foreach (var contract in pendingContracts)
                {
                    Contract frontendContract = new Contract(contract);
                    frontendConctacts.Add(frontendContract);
                }
                return frontendConctacts;
            }
            return NotFound("No pending contracts");
        }


        [HttpPost]
        [Route("CreateContracts")]
        public async Task<ActionResult> CreateContracts(List<Contract> contracts)
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
                    _context.Contracts.Add(newContract);
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok("Contracts created");
            }
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
