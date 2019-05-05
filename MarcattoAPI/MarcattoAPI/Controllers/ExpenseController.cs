using AutoMapper;
using Marcatto.Model;
using Marcatto.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Marcatto.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarcattoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ExpenseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseResource transaction)
        {
            var entity = mapper.Map<Expense>(transaction);
            entity.AddedDateTime = DateTime.Now;
            unitOfWork.ExpenseRepository.Add(entity);
            await unitOfWork.DoneAsync();
            return Ok(unitOfWork.IncomeRepository.LastAddedObject);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var expenses = await unitOfWork.ExpenseRepository.GetAsync();

            return Ok(GenerateTransactionResource(expenses));
        }

        [HttpGet]
        [Route("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var expenses = await unitOfWork.ExpenseRepository.GetAsync(date);
            
            return Ok(GenerateTransactionResource(expenses));
        }

        private TransactionResource GenerateTransactionResource(IEnumerable<Expense> transactionList)
        {
            var transactions = mapper.Map<IEnumerable<Expense>, List<Transaction>>(transactionList);
            var transactionResource = new TransactionResource();
            var banks = transactionList.Where(i => i.BankAccount != null).Select(i => i.BankAccount.Name).Distinct();
            transactionResource.Transactions = transactions;
            transactionResource.AvailableColumns.AddRange(banks);
            return transactionResource;
        }
    }
}
