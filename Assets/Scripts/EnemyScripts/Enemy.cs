using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected abstract void Say();

    protected abstract void MoveToPlayer();

    public abstract void ApplyDamage(float damage);
    
}
