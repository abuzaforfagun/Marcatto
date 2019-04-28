using System.Collections.Generic;
using Marcatto.Model;
using Marcatto.Resources;

namespace Marcatto.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<IncomeResource, Income>();
            //    .ForMember(dest => dest.PaymentOption,
            //        opts => opts.MapFrom(src => new PaymentOption() { Id = src.PaymentOptionId }))
            //    .ForMember(dest => dest.BankAccount, opts => opts.MapFrom(src => new BankAccount() { Id = src.BankAccountId }));
            CreateMap<Income, Transaction>()
                .ForMember(t => t.BankId, opt => opt.MapFrom(i => i.BankAccountId))
                .ForMember(t => t.Amount, opt => opt.MapFrom(i => i.Amount))
                .ForMember(t => t.Description, opt => opt.MapFrom(i => i.Description))
                .ForMember(t => t.Date, opt => opt.MapFrom(i => i.Date))
                .ForMember(t => t.BankName, opt => opt.MapFrom(i => i.BankAccount.Name));

            //CreateMap<IEnumerable<Income>, List<Transaction>>();
        }
    }
}
