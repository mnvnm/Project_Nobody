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
    [SerializeField] private Camera playerCamera;
    private Rigidbody m_Rigidbody;
    private float m_moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 100f;
    float m_xRotate = 0f;

    private float xRotation = 0;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    public void Initialize()
    {
        xRotation = 0;
    }

    private void Move()
    {
        m_Rigidbody.linearVelocity = new Vector3(0, m_Rigidbody.linearVelocity.y, 0);

        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.forward.normalized * zAxis + transform.right.normalized * xAxis;

        m_Rigidbody.linearVelocity = move.normalized * m_moveSpeed + new Vector3(0, m_Rigidbody.linearVelocity.y, 0);
    }

    private void Rot()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        m_xRotate = Mathf.Clamp(m_xRotate + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        this.transform.eulerAngles = new Vector3(0, yRotate, 0);
        playerCamera.transform.eulerAngles = new Vector3(m_xRotate, transform.eulerAngles.y, 0);
    }
    void Update()
    {
        Move();
        Rot();
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
