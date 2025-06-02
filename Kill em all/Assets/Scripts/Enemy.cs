using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enemy Script
public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem bloodSpill;
    [SerializeField] AudioClip deathSFX;
    GameManager gameManager;
    GameManager gm;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.EnemyCountIncrease();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bullet Alternative")
        {
            gameManager.EnemyCountDecrease();
            AudioSource.PlayClipAtPoint(deathSFX,transform.position);
            ParticleSystem blood =  Instantiate(bloodSpill,transform.position,transform.rotation);
            blood.Play();
            Destroy(blood, 2f);
            Destroy(gameObject);
        }
    }
}
