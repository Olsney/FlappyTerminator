using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerTracker : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Vector3 _offset;

        private void LateUpdate()
        {
            Vector3 position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
            
            transform.position = position + _offset;
        }
    }
}