using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fence : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    public int currentHealth;
    public Manager manager;
    private bool isDead;
    public Slider PlayerHealth;
    public TMP_Text HPtext;

    private void Awake()
    {
        currentHealth = maxHealth;
       
    }
    private void Update()
    {
        PlayerHealth.value = currentHealth;
        HPtext.text = "" + currentHealth;
    }

    public void ReceiveDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Die();
            manager.GameOver();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
