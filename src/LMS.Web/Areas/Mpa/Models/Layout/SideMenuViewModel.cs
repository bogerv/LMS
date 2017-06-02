using Abp.Application.Navigation;

namespace LMS.Web.Areas.Mpa.Models.Layout
{
    public class SideMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string CurrentPageName { get; set; }
    }
}