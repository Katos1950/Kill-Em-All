using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool showCanvas = true;
    public int bullets = 5;
    [SerializeField] Canvas canvas;
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas loseCanvas;
    [SerializeField] int enemies = 0;
    [SerializeField] GameObject bulletSprite;
    [SerializeField] GameObject bulletSpritesPos;
    [SerializeField] TextMeshProUGUI enemiesText;
    LevelCounter levelCounter;
    [SerializeField] UnityAds unityAds;
    private void Start()
    {
        unityAds.ShowBanner();
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
        levelCounter = FindObjectOfType<LevelCounter>();
        if(showCanvas)
        {
            for(int  i = 0; i<bullets;i++)
            {
                Instantiate(bulletSprite, bulletSpritesPos.transform);
            }
        }
        else
        {
            canvas.enabled = false;
        }
    }

    private void Update()
    {
        if(enemies == 0 && showCanvas)
        {
            StartCoroutine("LoadWinScene");
        }
        else if(bullets == 0 && GameObject.FindGameObjectsWithTag("Bullet").Length == 0 && showCanvas)
        {
            StartCoroutine("LoadLoseScene");
        }
    }

    public void EnemyCountIncrease()
    {
        enemies++;
        enemiesText.text = enemies.ToString();
    }

    public void EnemyCountDecrease()
    {
        enemies--;
        enemiesText.text = enemies.ToString();
    }

    public void BulletHandle()
    {
        bullets--;
        bulletSpritesPos.transform.GetChild(bullets).gameObject.SetActive(false);
    }

    //Scene Management
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        unityAds.ShowRewardedVideo();
    }

    public void Retry()
    {
        unityAds.ShowInterstitial();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(GameObject levelName)
    {
        SceneManager.LoadScene(levelName.name);
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }

    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(2f);
        winCanvas.enabled = true;
        levelCounter.DetermineMaxLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadLoseScene()
    {
        yield return new WaitForSeconds(2f);
        loseCanvas.enabled = true;
    }
}
