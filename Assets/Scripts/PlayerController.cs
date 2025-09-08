using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// PlayerController 의 용도 : 유저(플레이어)의 모든 것을 관리
/// </summary>
public class PlayerController : LivingEntity
{
    private Rigidbody m_Rigidbody;
    private float m_moveSpeed = 5f;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
        Cursor.visible = false; // 마우스 커서 숨기기
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    public void Initialize()
    {

    }

    private void Move()
    {
        m_Rigidbody.linearVelocity = new Vector3(0, m_Rigidbody.linearVelocity.y, 0);

        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.forward.normalized * zAxis + transform.right.normalized * xAxis;

        m_Rigidbody.linearVelocity = move.normalized * m_moveSpeed + new Vector3(0, m_Rigidbody.linearVelocity.y, 0);
    }
    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // 마우스 커서 잠금 해제
            Cursor.visible = true; // 마우스 커서 보이기
        }
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
    }

    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die() 실행(사망 적용)

        onDeath += () =>
        {
            // 사망시 처리할 내용
            Debug.Log("Player Die");
        };
        base.Die();
    }
}
