using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WatcherChaseState : EnemyState
{
    public WatcherIdleState idleState;
    public WatcherAttackState AttackState;
    public EnemySenesor Range;

    private float timer = 0.0f;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    

    public override EnemyState RunCurrentState(EnemyStateManager Enemy)
    {
        Enemy.animator.SetBool("Running", true);
        Range.angle = 360;
        float Distancefromplayer = Vector3.Distance(Enemy.playersTransform.position, Enemy.enemypos.position);
        timer -= Time.deltaTime;

        if (timer < 0.0f)
        {
            float sqDistance = (Enemy.playersTransform.position - Enemy.agent.destination).sqrMagnitude;
            if (sqDistance > maxDistance * maxDistance)
            {
                Enemy.agent.destination = Enemy.playersTransform.position;
            }
            timer = maxTime;

        }
        if(Distancefromplayer <= Enemy.agent.stoppingDistance)
        {
            Enemy.FacePlayer();
        }
        if(Distancefromplayer < Enemy.AttackRange){
            Enemy.animator.SetBool("Running", false);
            return AttackState;
        }
        if(Range.PlayerSeen == false)
        {
            Enemy.animator.SetBool("Running", false);
            return idleState;
        }
        
        return this;
        
    }

}
