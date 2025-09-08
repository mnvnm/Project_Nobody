using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : LivingEntity
{
    public Transform TargetTransform;
    private void Awake()
    {
    }

    public void Initialize()
    {
    }
    void Update()
    {
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
    }
    public override void Die()
    {
        onDeath += () =>
        {
            // 사망시 처리할 내용
            Debug.Log("Enemy Die");
        };
        dead = true;
        base.Die();
    }
}