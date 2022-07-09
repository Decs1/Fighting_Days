using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPlayer : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public Text healthText;
    public Slider healthSlider;

    public static StatusPlayer playerstats;
    public float health;
    public float MaxHealth;
    public float restartLevelDelay = 2f;

    void Awake()
    {
        if(playerstats != null)
        {
            Destroy(playerstats);
        }
        else
        {
            playerstats = this;
        }
    }

    void Start()
    {
        health = MaxHealth;
        SetHealthUI();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health) + " / " + Mathf.Ceil(MaxHealth).ToString();
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
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }
    }

    float CalculateHealthPercentage()
    {
        return health / MaxHealth;
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
        }
    }
}
