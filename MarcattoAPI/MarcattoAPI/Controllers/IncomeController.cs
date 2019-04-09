using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marcatto.Model;
using Marcatto.Repository;
using Marcatto.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarcattoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public IncomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(IncomeResource income)
        {
            var incomeEntity = mapper.Map<Income>(income);
            incomeEntity.AddedDateTime = DateTime.Now;
            await unitOfWork.IncomeRepository.AddAsync(incomeEntity);
            await unitOfWork.DoneAsync();
            return Ok(unitOfWork.IncomeRepository.LastAddedObject);
        }
    }
}
