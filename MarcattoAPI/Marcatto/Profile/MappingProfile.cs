using Marcatto.Model;
using Marcatto.Resources;

namespace Marcatto.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<IncomeResource, Income>();
            CreateMap<Income, Transaction>()
                .ForMember(t => t.BankId, opt => opt.MapFrom(i => i.BankAccountId))
                .ForMember(t => t.Amount, opt => opt.MapFrom(i => i.Amount))
                .ForMember(t => t.Description, opt => opt.MapFrom(i => i.Description))
                .ForMember(t => t.Date, opt => opt.MapFrom(i => i.Date.ToShortDateString()))
                .ForMember(t => t.BankName, opt => opt.MapFrom(i => i.BankAccount.Name));

        }
    }
}
