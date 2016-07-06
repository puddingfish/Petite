namespace Petite.Core.Events
{
    /// <summary>
    /// 单独泛型参数的事件信息类必须实现此接口，此参数将被继承使用
    /// 例如：
    /// 假设有一个Student类继承自Person类，如果EntityCreatedEventData实现了此接口，
    /// 当触发EntityCreatedEventData{Student} , EntityCreatedEventData{Person}也会被触发
    /// </summary>
    public interface IEventDataWithInheritableGenericArgument
    {
        /// <summary>
        /// 当创建一个类的新实例后获取其参数
        /// </summary>
        /// <returns></returns>
        object[] GetConstructorArgs();
    }
}
