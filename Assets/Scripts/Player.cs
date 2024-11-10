using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(ScoreModel))]
    [RequireComponent(typeof(BulletCollisionHandler))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private const KeyCode FireKey = KeyCode.D;
        
        private PlayerMover _playerMover;
        private ScoreModel _scoreModel;
        private BulletCollisionHandler _handler;

        public event Action Died;

        private void Awake()
        {
            _scoreModel = GetComponent<ScoreModel>();
            _handler = GetComponent<BulletCollisionHandler>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(FireKey))
            {
                _weapon.Shoot();
            }
        }

        private void OnEnable()
        {
            _handler.Touched += OnCollisionDetected;
        }

        private void OnDisable()
        {
            _handler.Touched -= OnCollisionDetected;
        }

        private void OnCollisionDetected(IInteractable interactable)
        {
            if (interactable is Bullet)
            {
                Died?.Invoke();
            }
        }

        public void Reset()
        {
            _scoreModel.Reset();
            _playerMover.Reset();
        }
    }
}