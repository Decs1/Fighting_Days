using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTesteAtaque : MonoBehaviour
{
    public GameObject projectile;
    public Transform jogador;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;

    void Start()
    {
        StartCoroutine(BigShootPlayer());
    }

    IEnumerator BigShootPlayer()
    {
        yield return new WaitForSeconds(6);
        if (jogador != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            jogador = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 myPos = transform.position;
            Vector2 targetPos = jogador.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(BigShootPlayer());
        }
    }
}
