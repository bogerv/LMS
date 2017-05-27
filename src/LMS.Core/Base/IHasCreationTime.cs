using System;

namespace LMS.Base
{
    public interface IHasCreationTime
    {
        /// <summary>
        /// 实体创建时间.
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
