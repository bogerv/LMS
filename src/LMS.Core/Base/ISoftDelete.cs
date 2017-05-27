namespace LMS.Base
{
    public interface ISoftDelete
    {
        /// <summary>
        /// 删除标识. 
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
