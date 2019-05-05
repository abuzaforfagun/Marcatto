using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Marcatto.Repository;
using Marcatto.Resources;
using Microsoft.AspNetCore.Mvc;

namespace MarcattoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DashboardController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var income = await unitOfWork.IncomeRepository.GetCurrentMonthSummery();
            var expense = await unitOfWork.ExpenseRepository.GetCurrentMonthSummery();
            var bankBalance = (await unitOfWork.IncomeRepository.GetTotalBank()) -
                              (await unitOfWork.ExpenseRepository.GetTotalBank());

            var cashBalance = (await unitOfWork.IncomeRepository.GetTotalCash()) -
                              (await unitOfWork.ExpenseRepository.GetTotalCash());
            var result = new DashboardSummeryResource
            {
                Expense = expense,
                Income = income,
                BankBalance = bankBalance,
                CashBalance = cashBalance
            };

            return Ok(result);
        }
    }
}