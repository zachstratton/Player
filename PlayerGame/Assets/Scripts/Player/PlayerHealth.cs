using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    ClickToMove clicktomove;
    bool isDead;
    bool damaged;


    // Use this for initialization
    void Awake()
    {
        clicktomove = GetComponent<ClickToMove>();
        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        //anim
        clicktomove.enabled = false;
    }
}