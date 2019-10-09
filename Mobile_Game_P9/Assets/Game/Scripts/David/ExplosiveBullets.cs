using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullets : MonoBehaviour
{
    private float m_BulletSpeed = 70f;
    private float m_BulletDamage = 5f;
    [SerializeField] private GameObject m_HitImpact;
    [SerializeField] private float m_ExplosiveRange = 0.5f;

    private Transform m_Target;


    public void Spawn(Transform target, float bulletSpeed, float damage)
    {
        m_Target = target;
        m_BulletSpeed = bulletSpeed;
        m_BulletDamage = damage;
    }

    private void Update()
    {
        if (m_Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = m_Target.position - transform.position;
        float distanceThisFrame = m_BulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {

            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject bullet = Instantiate(m_HitImpact, transform.position, transform.rotation);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_ExplosiveRange);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.CompareTag("Enemy"))
            {
                hitColliders[i].GetComponent<EnemyHealth>().TakeDamage(m_BulletDamage);
            }
        }

        Destroy(gameObject);
    }
}
