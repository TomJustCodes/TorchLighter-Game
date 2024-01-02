using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherAttackState : EnemyState
{
    private Vector3 PlayerDestinantion;
    public float projectileSpeed = 30f;
    public GameObject Enemyprojectile;
    public float fireRate = 1;
    public float shootTimer;
    public WatcherChaseState chaseState;
    

    public override EnemyState RunCurrentState(EnemyStateManager Enemy)
    {
        Enemy.FacePlayer();

        float distance = Vector3.Distance(Enemy.playersTransform.position, Enemy.enemypos.position);

        
        if (distance > Enemy.AttackRange)
        {
            Enemy.animator.SetBool("Attack", false);
            return chaseState;
        }
        if (shootTimer == 0)
        {
            RaycastHit Hit;
            Ray ray = new Ray(Enemy.sensor.transform.position, transform.forward);

            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.rigidbody.gameObject.tag == "Player")
                {
                    Enemy.animator.SetBool("Attack", true);
                    PlayerDestinantion = Hit.point;
                    Debug.DrawLine(ray.origin, Hit.point);
                    InstantiateEnemyProjectile(Enemy.Eye1);
                    InstantiateEnemyProjectile(Enemy.Eye2);

                }



            }
            shootTimer = 1;
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
            shootTimer = Mathf.Max(shootTimer, 0);

        }
        return this;

    }

    void InstantiateEnemyProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(Enemyprojectile, firePoint.position, firePoint.rotation) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (PlayerDestinantion - firePoint.position).normalized * projectileSpeed;

    }

}

