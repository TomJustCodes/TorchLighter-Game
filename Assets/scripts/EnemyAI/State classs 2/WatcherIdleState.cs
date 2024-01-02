using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherIdleState : EnemyState
{
    public WatcherChaseState chaseState;
    public EnemySenesor sense;

    public override EnemyState RunCurrentState(EnemyStateManager Enemy)
    {
        Enemy.animator.SetBool("Idle", true);
        sense.angle = 180;
        float Distancefromplayer = Vector3.Distance(Enemy.playersTransform.position, Enemy.enemypos.position);

        if (Distancefromplayer < Enemy.soundrange)
        {
            Enemy.animator.SetBool("Patrol", false);
            return chaseState;
        }
        if (sense.PlayerSeen)
        {
            Enemy.animator.SetBool("Idle", false);
            return chaseState;

        }
        else
        {
            return this;
        }
    
        
    }




}
