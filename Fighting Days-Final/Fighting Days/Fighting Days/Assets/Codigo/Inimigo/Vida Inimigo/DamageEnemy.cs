using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour
{
    public float health;
    public float MaxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    void Start()
    {
        health = MaxHealth;
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPercentage();
        health -= damage;
        CheckDeath();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverheal()
    {
        if (health <= MaxHealth)
        {
            health = MaxHealth;
        }
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / MaxHealth);
    }
}
