using System;
using DefaultNamespace;
using UnityEngine;

public abstract class PoolableObject<T> : MonoBehaviour, IInteractable where T : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private BulletCollisionHandler _handler;

    public event Action<T> Faced;

    public Vector3 Direction { get; private set; }

    private void Update()
    {
        _mover.Move(Direction);
    }

    private void Awake()
    {
        _handler = GetComponent<BulletCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.Touched += OnTouched;
    }

    private void OnDisable()
    {
        _handler.Touched -= OnTouched;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    protected abstract void OnTouched(IInteractable obj);

    protected void OnFaced(T obj)
    {
        Faced?.Invoke(obj);
    }
}