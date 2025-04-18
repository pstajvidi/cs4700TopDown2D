using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private HealthManager healthManager; 
    public Slider healthBar; // Reference to the health bar UI element

    public Text hpText; // Reference to the text element for displaying health
    
    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth; // Set the max value of the health bar
        healthBar.value = healthManager.currentHealth; // Update the current value of the health bar
        hpText.text ="HP: "+ healthManager.currentHealth + "/" + healthManager.maxHealth; // Update the text element to show current and max health
    }
}
