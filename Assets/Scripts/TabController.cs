using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] tabPages;
    // Start is called before the first frame update
    void Start()
    {
        ShowTab(0);
    }

    public void ShowTab(int tabIndex)
    {
        for (int i = 0; i < tabPages.Length; i++)
        {
            if (i == tabIndex)
            {
                tabPages[i].SetActive(true);
                tabImages[i].color = Color.white;
            }
            else
            {
                tabPages[i].SetActive(false);
                tabImages[i].color = Color.gray;
            }
        }
    }
}
