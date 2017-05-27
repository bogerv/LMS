using System;

namespace LMS.Base
{
    public interface IHasModificationTime
    {
        /// <summary>
        /// 实体最后更新时间.
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}