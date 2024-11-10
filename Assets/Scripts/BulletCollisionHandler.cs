using System;
using DefaultNamespace;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> Touched;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IInteractable interactable))
        {
            Touched?.Invoke(interactable);
        }
    }
}