using AutoMapper;
using Nekram.App.Areas.Branches.ViewModels;
using Nekram.App.ViewModels;
using Nekram.Models.Application;

namespace Nekram.App {
    public class AutoMapProfile :Profile {

        public AutoMapProfile() {

            #region Branch

            CreateMap<Branch, BranchViewModel>()
                .ForMember(b => b.Created, t => t.Ignore())
                .ForMember(b => b.Modified, t => t.Ignore())
                .ForMember(b => b.Id, m => m.MapFrom(s => s.Id));
            CreateMap<BranchViewModel, Branch>();

            CreateMap<Appconfig, AppconfigViewModel>()
                .ForMember(a => a.BranchId, t => t.Ignore())
                .ForMember(a => a.Id, m => m.MapFrom(s => s.Id));
            CreateMap<AppconfigViewModel, Appconfig>();

            CreateMap<Branch, SetupViewModel>()
                .ForMember(s => s.LegalName, t => t.MapFrom(b => b.LegalName))
                .ForMember(s => s.Alias, t => t.MapFrom(b => b.Alias))
                .ForMember(s => s.Email, t => t.MapFrom(b => b.Email))
                .ForMember(s => s.PostalAddress, t => t.MapFrom(b => b.PostalAddress))
                .ForMember(s => s.Contact, t => t.MapFrom(b => b.Telephone))
                .ForMember(s => s.BranchId, t => t.Ignore());

            CreateMap<SetupViewModel, Branch>()
                .ForMember(b => b.LegalName, t => t.MapFrom(s => s.LegalName))
                .ForMember(b => b.Alias, t => t.MapFrom(s => s.Alias))
                .ForMember(b => b.Email, t => t.MapFrom(s => s.Email))
                .ForMember(b => b.PostalAddress, t => t.MapFrom(s => s.PostalAddress))
                .ForMember(b => b.Telephone, t => t.MapFrom(s => s.Contact))
                .ForMember(b => b.City, t => t.Ignore())
                .ForMember(b => b.Mobil, t => t.Ignore())
                .ForMember(b => b.Logo, t => t.Ignore())
                .ForMember(b => b.Website, t => t.Ignore())
                .ForMember(b => b.Country, t => t.Ignore())
                .ForMember(b => b.IsMain, t => t.Ignore())
                .ForMember(b => b.IsParent, t => t.Ignore())
                .ForMember(b => b.Id, t => t.Ignore())
                .ForMember(b => b.Created, t => t.Ignore())
                .ForMember(b => b.Modified, t => t.Ignore())
                .ForMember(b => b.Users, t => t.Ignore())
                .ForMember(b => b.Audits, t => t.Ignore())
                .ForMember(b => b.Taxes, t => t.Ignore())
                .ForMember(b => b.Configurations, t => t.Ignore())
                .ForMember(b => b.Branches, t => t.Ignore())
                .ForMember(b => b.GeneralConfigurations, t => t.Ignore())
                .ForMember(b => b.ParentId, t => t.Ignore());

            #endregion

            #region Nusers

            #endregion

        }
    }
}