using UnityEngine;

namespace DefaultNamespace
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public void Move(Vector3 direction)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, transform.position + direction, _speed * Time.deltaTime);
        }
    }
}