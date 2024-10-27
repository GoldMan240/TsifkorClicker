using UnityEngine.Pool;

namespace Code.Extensions
{
    public static class ObjectPoolExtensions
    {
        public static void WarmUp<T>(this ObjectPool<T> objectPool, int count) where T : class
        {
            T[] elements = new T[count];
            
            for (int i = 0; i < count; i++)
            {
                elements[i] = objectPool.Get();
            }
            
            for (int i = 0; i < count; i++)
            {
                objectPool.Release(elements[i]);
            }
        }
    }
}