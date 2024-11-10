using DefaultNamespace;
using UnityEngine;

public class Bullet : PoolableObject<Bullet>
{
    protected override void OnTouched(IInteractable obj)
    {
        OnFaced(this);
    }
}