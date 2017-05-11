using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Areas.Mpa.Models.Common.Modals
{
    public class ModalHeaderViewModel
    {
        public string Title { get; set; }

        public ModalHeaderViewModel(string title)
        {
            Title = title;
        }
    }
}