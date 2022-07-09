using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Jogador")
        {
            if (collision.GetComponent<DamageEnemy>() != null)
            {
                collision.GetComponent<DamageEnemy>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
