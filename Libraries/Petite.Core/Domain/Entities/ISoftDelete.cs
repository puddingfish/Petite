namespace Petite.Core.Domain.Entities
{
    /// <summary>
    /// 实现此接口的实体在删除时不会做物理删，仅标记其为删除状态
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// 标记一个实体删除状态
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
