using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public float m_Range = 15f;
    public float m_ShotSpeed = 5;

    [SerializeField] private float m_FireRate = 1.5f;
    [SerializeField] private float m_BulletSpeed;
    [SerializeField] private float m_BulletDamage;
    [SerializeField] private GameObject m_Bullet;
    [SerializeField] private Transform m_SpawnLocation;
    [SerializeField] private bool m_FollowTarget;

    private float m_FireRateTimer;
    private MatchManager m_MatchManager;
    private Transform m_TowerTarget;
    private EnemyHealth m_TargetHealth;

    private MaterialPropertyBlock m_Block;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        m_MatchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        Shoot();
    }

    private void FollowTarget()
    {
        if(m_TowerTarget != null && m_FollowTarget)
        {
            Quaternion oldRotation = new Quaternion();
            transform.LookAt(m_TowerTarget);
            transform.rotation = new Quaternion(oldRotation.x, transform.rotation.y, oldRotation.z, transform.rotation.w);
        }
    }

    private void UpdateTarget()
    {
        m_TowerTarget = null;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_Range);
        
        int closestEnemy = -1;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.CompareTag("Enemy"))
            {
                for (int enemies = 0; enemies < m_MatchManager.m_Enemies.Count; enemies++)
                {
                    if (hitColliders[i].gameObject == m_MatchManager.m_Enemies[enemies].gameObject)
                    {
                        if (closestEnemy == -1)
                        {
                            closestEnemy = enemies;
                        }
                        else
                        {
                            if (m_MatchManager.m_EnemyNavMesh[enemies].remainingDistance < m_MatchManager.m_EnemyNavMesh[closestEnemy].remainingDistance)
                            {
                                closestEnemy = enemies;
                            }
                        }
                    }
                }
            }
        }
        
        if(closestEnemy != -1) {
            m_TowerTarget = m_MatchManager.m_Enemies[closestEnemy].transform;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, m_Range);
    }
    private void Shoot()
    {
        if (m_TowerTarget != null)
        {
            m_FireRateTimer -= Time.deltaTime;
            if(m_FireRateTimer <= 0)
            {
                GameObject bullet = Instantiate(m_Bullet, m_SpawnLocation.position, m_SpawnLocation.rotation);
                if (bullet.CompareTag("Bomb"))
                {
                    bullet.GetComponent<ExplosiveBullets>().Spawn(m_TowerTarget, m_BulletSpeed, m_BulletDamage);
                }
                else
                {
                    bullet.GetComponent<Bullet>().Spawn(m_TowerTarget, m_BulletSpeed, m_BulletDamage);
                }
               
                m_FireRateTimer = m_FireRate;
            }
        }
    }
}
