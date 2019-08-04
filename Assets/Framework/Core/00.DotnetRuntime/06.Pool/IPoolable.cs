
namespace Framework
{
    /// <summary>
    /// 可回收接口
    /// </summary>
    public interface IPoolable
    {
        //回收前操作
        void OnRecycle();

        //是否已回收，避免重复回收
        bool IsRecycled { get; set; }
    }
}
