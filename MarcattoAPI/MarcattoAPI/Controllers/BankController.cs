using System.Threading.Tasks;
using Marcatto.Model;
using Marcatto.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarcattoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BankController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BankAccount> Add(BankAccount bankAccount)
        {
            this.unitOfWork.BankRepository.Add(bankAccount);
            await this.unitOfWork.DoneAsync();
            return this.unitOfWork.BankRepository.LastAddedObject;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.unitOfWork.BankRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Terminate(BankAccount bankAccount)
        {
            await this.unitOfWork.BankRepository.TerminateAsync(bankAccount);
            await this.unitOfWork.DoneAsync();
            return Ok();
        }
    }
}
