using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnemySettings : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;  
    public GameObject Enemy;
    public Slider HealthBar;
    public ScoreManager ScoreManager;
    public ScoreCounter textTest;
   

    private void Start()
    {
        
        currentHealth = maxHealth;
        
    }

    private void Update()
    {
        HealthBar.value = currentHealth;
        
    }
    public void ReceiveDamage(int damage)
    {
        Debug.Log("Enemy takes damage: " + damage);
        currentHealth -= damage;
       
        if (currentHealth <= 0)
        { 
            Enemy.GetComponent<Animator>().SetTrigger("Death");
            Invoke("Die", 2f);

            ScoreCounter.ScoreEnemys += 1;
    
            HealthBar.gameObject.SetActive(false);
            Enemy.GetComponent<EnemyWalk>().enabled = false; 
                       
        }
    }
  

    private void Die()
    {
        Destroy(Enemy);
    }
}

