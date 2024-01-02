using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private bool collided;

    private void OnCollisionEnter(Collision co)
    {
        //checks for what the enemy projetile hits
        if (co.gameObject.tag == "Player" && co.gameObject.tag != "Bullet" && co.gameObject.tag != "Enemy" && !collided)
        {
            collided = true;
            Destroy(gameObject);

            co.gameObject.GetComponentInParent<PlayerHealth>().Damaged(10);//get player health and decreases by 10
        }

        else if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Enemy" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }

    }
}
