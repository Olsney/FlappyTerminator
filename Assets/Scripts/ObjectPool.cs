using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectPool<T> where T : PoolableObject<T>
    {
        private T _prefab;
        
        private Queue<T> _pool;

        public ObjectPool(T prefab)
        {
            _pool = new Queue<T>();
            _prefab = prefab;
        }
        
        public T GetObject()
        {
            if (_pool.Count == 0)
            {
                var poolable = GameObject.Instantiate(_prefab);

                return poolable;
            }
            
            return _pool.Dequeue();
        }

        public void PutObject(T poolable)
        {
            _pool.Enqueue(poolable);

            poolable.gameObject.SetActive(false);
        }

        public void Reset()
        {
            _pool.Clear();
        }
    }
}