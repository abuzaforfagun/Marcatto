﻿using System;
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
            var lastAddedTransaction = unitOfWork.IncomeRepository.LastAddedObject;

            int lastlyAddedBankId = lastAddedTransaction.BankAccountId ?? 0;
            lastAddedTransaction.BankAccount = lastlyAddedBankId != 0
                ? await unitOfWork.BankRepository.GetAsync(lastlyAddedBankId)
                : null;
            var _lastAddedTransaction = mapper.Map<Income, Transaction>(lastAddedTransaction);
            return Ok(_lastAddedTransaction);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var incomeList = await unitOfWork.IncomeRepository.GetAsync();
            return Ok(GenerateTransactionResource(incomeList));

        }

        [HttpGet]
        [Route("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var incomeList = await unitOfWork.IncomeRepository.GetAsync(date);
            
            return Ok(GenerateTransactionResource(incomeList));
        }

        private TransactionResource GenerateTransactionResource(IEnumerable<Income> incomeList)
        {
            var transactions = mapper.Map<IEnumerable<Income>, List<Transaction>>(incomeList);
            var transactionResource = new TransactionResource();
            var banks = incomeList.Where(i => i.BankAccount != null).Select(i => i.BankAccount.Name).Distinct();
            transactionResource.Transactions = transactions;
            transactionResource.AvailableColumns.AddRange(banks);
            return transactionResource;
        }
    }
}
