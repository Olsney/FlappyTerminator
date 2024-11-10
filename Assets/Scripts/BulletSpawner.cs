using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Bullet _bulletPrefab;

    private ObjectPool<Bullet> _pool;

    private void OnEnable()
    {
        _pool = new ObjectPool<Bullet>(_bulletPrefab);

        StartCoroutine(Generating());
    }

    private IEnumerator Generating()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        Bullet bullet = _pool.GetObject();

        bullet.transform.position = transform.position;
        bullet.SetDirection(transform.right);
        bullet.gameObject.SetActive(true);

        bullet.Faced += ReturnToPool;
    }

    private void ReturnToPool(Bullet bullet)
    {
        bullet.Faced -= ReturnToPool;
        _pool.PutObject(bullet);
    }
}