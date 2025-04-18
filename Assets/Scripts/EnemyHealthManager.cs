using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth; 
    public int maxHealth;

    private bool flashActive; 

    [SerializeField]private float flashLength = 0f; 

    private float flashCounter=0f;

    private SpriteRenderer enemySprite;
    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flashActive){
            if(flashCounter > flashLength*0.99f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 0f ); 
            }
            else if(flashCounter > flashLength*0.82f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 1f ); 
            }
            else if(flashCounter > flashLength*0.66f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 0f ); 
            }
            else if(flashCounter > flashLength*0.49f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 1f ); 
            }
            else if(flashCounter > flashLength*0.33f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 0f ); 
            }
            else if(flashCounter > flashLength*0.16f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 1f ); 
            }
            else if(flashCounter > 0f){
                 enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 0f ); 
            }
            else{
                enemySprite.color = new Color(enemySprite.color.r,enemySprite.color.g, enemySprite.color.b, 1f ); 
                flashActive = false;
            }
            flashCounter -= Time.deltaTime; // Decrease the flash counter
        }
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        flashActive = true; // Start flashing when hurt
        flashCounter = flashLength; // Reset the flash counter
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
