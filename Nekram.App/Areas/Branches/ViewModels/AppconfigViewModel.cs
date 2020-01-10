
using Nekram.Models;

namespace Nekram.App.Areas.Branches.ViewModels {
    public class AppconfigViewModel {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string ApplicationName { get; set; }
        public string Theme { get; set; }
        public string Version { get; set; }
        public AppType Type { get; set; }
        public string Modules { get; set; }
    }
}