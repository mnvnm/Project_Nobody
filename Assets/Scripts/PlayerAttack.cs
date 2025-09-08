using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Update()
    {
        Attack();
    }
    public void Attack()
    {
        Vector3 center = new Vector3(0.5f, 0.5f, 0);
        Ray ray = Camera.main.ViewportPointToRay(center);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, ray.direction, out hit))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<LivingEntity>().OnDamage(10f, hit.point, hit.normal);
                    Debug.Log("레이캐스트가 충돌한 적: " + hit.transform.name);
                }
            }
        }
    }
}
