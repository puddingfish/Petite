namespace Petite.Core
{
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 检查Entity是否是临时的（没有持久化到数据库，没有Id）
        /// </summary>
        /// <returns>是临时Entity，则为true</returns>
        bool IsTransient();
    }
}
