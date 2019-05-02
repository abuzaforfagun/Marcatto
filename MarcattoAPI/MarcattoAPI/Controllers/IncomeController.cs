using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marcatto.Model;
using Marcatto.Repository;
using Marcatto.Resources;
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
            unitOfWork.IncomeRepository.Add(incomeEntity);
            await unitOfWork.DoneAsync();
            return Ok(unitOfWork.IncomeRepository.LastAddedObject);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var incomeList = await unitOfWork.IncomeRepository.GetAsync();
            var transactions = mapper.Map<IEnumerable<Income>, List<Transaction>>(incomeList);
            var transactionResource = new TransactionResource();
            var banks = incomeList.Where(i=>i.BankAccount != null).Select(i=>i.BankAccount.Name).Distinct();
            transactionResource.Transactions = transactions;
            transactionResource.AvailableColumns.AddRange(banks);
            return Ok(transactionResource);
        }

        [HttpGet]
        [Route("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var incomeList = await unitOfWork.IncomeRepository.GetAsync(date);
            var transactions = mapper.Map<IEnumerable<Income>, List<Transaction>>(incomeList);
            return Ok(transactions);
        }
    }
}
