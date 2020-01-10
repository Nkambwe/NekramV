using AutoMapper;
using Nekram.App.Areas.Branches.ViewModels;
using Nekram.Models.Application;

namespace Nekram.App {
    public class AutoMapProfile : Profile {

        public AutoMapProfile() {

            #region Branch

            CreateMap<Branch, BranchViewModel>()
                .ForMember(b => b.Created, t => t.Ignore())
                .ForMember(b => b.Modified, t => t.Ignore())
                .ForMember(b => b.Id, m => m.MapFrom(s => s.Id));

            CreateMap<Appconfig, AppconfigViewModel>()
                .ForMember(a => a.BranchId, t => t.Ignore())
                .ForMember(a => a.Id, m => m.MapFrom(s => s.Id));

            #endregion

            #region Nusers

            #endregion

            Mapper.AssertConfigurationIsValid();
        }
    }
}