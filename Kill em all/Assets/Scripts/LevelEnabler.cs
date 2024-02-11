using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelEnabler : MonoBehaviour
{
    void Start()
    {
        LevelCounter levelCounter = FindObjectOfType<LevelCounter>();
        Component[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            button.interactable = false;
        }

        for(int i = 0; i < transform.childCount;i++)
        {
            transform.GetChild(i).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Level " + (i + 1).ToString();
            transform.GetChild(i).name = "Level " + (i + 1).ToString();
        }

        for (int i = 0; i <= levelCounter.maxLevel - 2; i++)
        {
            //Making buttons interactable
            try
            {
                transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
            }
            catch
            {
                //do nothing
            }
        }
    }
}
