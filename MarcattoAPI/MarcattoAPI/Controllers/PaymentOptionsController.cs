using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marcatto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarcattoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOptionsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentOptionsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await unitOfWork.PaymentOptionsRepository.GetPaymentOptionsAsync());
        }
    }
}