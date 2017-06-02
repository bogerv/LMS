using System.Collections.Generic;
using Abp.Localization;

namespace LMS.Web.Areas.Mpa.Models.Layout
{
    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}