using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag != "Inimigo")
        {
            if(collision.tag == "Player")
            {
                StatusPlayer.playerstats.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
