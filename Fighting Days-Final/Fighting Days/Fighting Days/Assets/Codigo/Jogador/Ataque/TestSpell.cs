using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{

    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float spellForce;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = transform.position;
                Vector2 direction = (mousePos - myPos).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
                spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);
            }
        }
    }
}