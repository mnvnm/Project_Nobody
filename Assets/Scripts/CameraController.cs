using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float cameraDistance = 3f; // 플레이어와 카메라 사이 거리

    //카메라 초기 위치
    private float x = 0.0f;
    private float y = 0.0f;

    //y값 제한
    private float yMinLimit = -60f;
    private float yMaxLimit = 80f;

    //앵글의 최소,최대 제한
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rot();
    }

    private void Rot()
    {
        //마우스 스크롤과의 거리계산
        cameraDistance -= 1 * Input.mouseScrollDelta.y;

        //마우스 스크롤했을경우 카메라 거리의 Min과Max
        if (cameraDistance < 1)
        {
            cameraDistance = 1.5f;

        }

        if (cameraDistance >= 9)
        {
            cameraDistance = 9;
        }

        //카메라 회전속도 계산
        x += Input.GetAxis("Mouse X") * mouseSensitivity * 0.015f;
        y -= Input.GetAxis("Mouse Y") * mouseSensitivity * 0.015f;

        //앵글값 정하기
        //y값의 Min과 MaX 없애면 y값이 360도 계속 돎
        //x값은 계속 돌고 y값만 제한
        y = ClampAngle(y, yMinLimit, yMaxLimit);

        //카메라 위치 변화 계산
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.85f, 0.5f, -cameraDistance) + target.position;

        target.transform.rotation = Quaternion.Euler(0, x, 0);
        transform.rotation = rotation;
        transform.position = position;
    }
}
