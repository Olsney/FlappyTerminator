using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;
        
        private ObjectPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(_prefab);
        }
        
        public void Shoot()
        {
            Bullet bullet = _bulletPool.GetObject();

            bullet.transform.position = transform.position;
            bullet.SetDirection(transform.right);
            bullet.gameObject.SetActive(true);

            bullet.Faced += ReturnToPool;
        }
        
        private void ReturnToPool(Bullet bullet)
        {
            Debug.Log("ReturnToPool is OK");
            bullet.Faced -= ReturnToPool;
            _bulletPool.PutObject(bullet);
        }
    }
}