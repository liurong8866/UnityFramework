
using System.Reflection;
using UnityEngine;

namespace Framework
{
    public class TestPool : MonoBehaviour
    {
        private void Start()
        {
            #region SimplePool

            //SimplePool<Bullet> bulletCache = new SimplePool<Bullet>(()=>new Bullet(), 100);

            //Bullet bullet= bulletCache.Allocate();
            //bulletCache.Count.ToString().Log();
            //bullet.print();

            //bulletCache.Recycle(bullet);
            //bulletCache.Count.ToString().Log();

            //bullet.print();

            //bullet = bulletCache.Allocate();
            //bulletCache.Count.ToString().Log();
            //bullet.print();


            //for(int i =0; i<10; i++)
            //{
            //    bulletCache.Allocate();
            //}
            //bulletCache.Count.ToString().Log();

            #endregion

            #region SafePool

            SafePool<Bullet>.Instance.InitPool(100);
            SafePool<Bullet>.Instance.Count.ToString().Log();
            
            Bullet bullet = SafePool<Bullet>.Instance.Allocate();
            SafePool<Bullet>.Instance.Count.ToString().Log();

            SafePool<Bullet>.Instance.Allocate();
            SafePool<Bullet>.Instance.Count.ToString().Log();

            SafePool<Bullet>.Instance.Recycle(bullet);
            SafePool<Bullet>.Instance.Count.ToString().Log();

            SafePool<Bullet>.Instance.Recycle(bullet);
            SafePool<Bullet>.Instance.Count.ToString().Log();

            for (int i = 0; i < 10; i++)
            {
                SafePool<Bullet>.Instance.Allocate();

            }
            SafePool<Bullet>.Instance.Count.ToString().Log();

            for (int i = 0; i < 10; i++)
            {
                SafePool<Bullet>.Instance.Resize(10);
            }
            SafePool<Bullet>.Instance.Count.ToString().Log();

            #endregion
        }

        private class Bullet : IPoolable
        {
            public bool IsRecycled { get; set; }

            public void print()
            {
                Debug.Log("bullet");
            }

            public void OnRecycle()
            {
                
                Debug.Log("recycle");
            }
        }
    }
}
