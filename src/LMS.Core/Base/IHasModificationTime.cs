using System;

namespace LMS.Base
{
    public interface IHasModificationTime
    {
        /// <summary>
        /// ʵ��������ʱ��.
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}