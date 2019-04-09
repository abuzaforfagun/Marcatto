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
        }
    }
}
