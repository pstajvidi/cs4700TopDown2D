using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int palyerLevel=1; 
    public int playerMaxLevel=100;
    public int baseExp=1000;
    public Text levelText; 
    public int playerExp=0;

    public int[] expToLevelUp;  

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + palyerLevel.ToString();
        expToLevelUp = new int[playerMaxLevel];
        expToLevelUp[1] = baseExp;
        for(int i=2; i<expToLevelUp.Length; i++)
        {
            if (i > 1)
            {
                expToLevelUp[i] = Mathf.FloorToInt(expToLevelUp[i - 1] * 1.05f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
