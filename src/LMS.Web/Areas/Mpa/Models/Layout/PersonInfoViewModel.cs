namespace LMS.Web.Areas.Mpa.Models.Layout
{
    public class PersonInfoViewModel
    {
        public bool IsMultiTenancyEnabled { get; set; }

        public string GetShownLoginName()
        {
            //var userName = "<span id=\"HeaderCurrentUserName\">" + User.UserName + "</span>";

            //if (!IsMultiTenancyEnabled)
            //{
            //    return userName;
            //}

            return "";
        }
        
        /// <summary>
        /// 在线状态
        /// </summary>
        public string OnlineStatus { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
    }
}