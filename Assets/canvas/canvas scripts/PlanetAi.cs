using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetAi : MonoBehaviour
{
    public Text healthText;
    public Slider healthBar;
    public Image bar;
    public int health;
    public int maxHealth = 100;

    void Start()
    {
        // healthText.text = health.ToString();
        //healthText.text = $"hp: {health}";
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = "hp: " + health;
        healthBar.value = health;
        bar.color = Color.Lerp(Color.red, Color.green, (float) health / maxHealth);
        if(health == 0)
        {
            bar.gameObject.SetActive(false);
        }
        else
        {
            bar.gameObject.SetActive(true);
        }
    }
    public void Damage(int damageAmount)
    {
        if (health - damageAmount < 0)
        {
            health = 0;
        }
        else
        {
            health -= damageAmount;
        }
        // healthText.text = health.ToString();
        //healthText.text = "hp: " + health;//.toString()
        // Debug.Log(health);
        UpdateUI();
    }


    public void Heal(int healAmount)
    {
        if (health + healAmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmount;
        }
        UpdateUI();
        //healthText.text = "hp: " + health;//.toString()
        //Damage(-healAmount);
    }
}
