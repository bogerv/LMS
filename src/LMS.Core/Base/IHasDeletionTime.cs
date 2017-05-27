using System;

namespace LMS.Base
{
    public interface IHasDeletionTime : ISoftDelete
    {
        /// <summary>
        /// 实体创建时间.
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}
