using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth; 
    public int maxHealth;

    private bool flashActive; 

    [SerializeField]private float flashLength = 0f; 

    private float flashCounter=0f;

    private SpriteRenderer playerSprite; // Reference to the sprite renderer for flashing effect
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>(); // Get the sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {
        if(flashActive){
            if(flashCounter > flashLength*0.99f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 0f ); 
            }
            else if(flashCounter > flashLength*0.82f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 1f ); 
            }
            else if(flashCounter > flashLength*0.66f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 0f ); 
            }
            else if(flashCounter > flashLength*0.49f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 1f ); 
            }
            else if(flashCounter > flashLength*0.33f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 0f ); 
            }
            else if(flashCounter > flashLength*0.16f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 1f ); 
            }
            else if(flashCounter > 0f){
                 playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 0f ); 
            }
            else{
                playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g, playerSprite.color.b, 1f ); 
                flashActive = false;
            }
            flashCounter -= Time.deltaTime; // Decrease the flash counter
        }
    }
    public void hurtPlayer(int damage)
    {
        currentHealth -= damage;
        flashActive = true; // Start flashing when hurt
        flashCounter = flashLength; // Reset the flash counter
        
        if (currentHealth <= 0)
        {
            // Player is dead
            gameObject.SetActive(false);
            Debug.Log("Player is dead");
        }
    }
}
