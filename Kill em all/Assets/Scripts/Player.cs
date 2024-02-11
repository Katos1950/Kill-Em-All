using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletPos;
    [SerializeField] Transform arm;
    [SerializeField] Transform gun;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float shootPower = 20f;
    int rotationMultiplier = 1;
    AudioSource audioSource;
    GameManager gameManager;
    //LineRenderer lineRenderer;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        //lineRenderer = GetComponent<LineRenderer>();

    }
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arm.transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        arm.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);


        if (rotationZ > 90 || rotationZ < -90)
        {
            arm.transform.Rotate(new Vector3(180, 0, 0));
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

   
        if(Input.GetMouseButton(0) && gameManager.bullets > 0)
        {
            /*lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, bulletPos.position);
            lineRenderer.SetPosition(1,direction * 100);*/
            Debug.DrawRay(bulletPos.position, direction * 100);
        }


        if (Input.GetMouseButtonUp(0) && gameManager.bullets >0)
        {
            //lineRenderer.enabled = false;
            muzzleFlash.Play();
            audioSource.Play();
            GameObject bullet = Instantiate(bulletPrefab, bulletPos.transform.position, Quaternion.Euler(0,0,rotationZ));
            bullet.GetComponent<Rigidbody2D>().velocity = direction* shootPower;
            gameManager.BulletHandle();
        }
    }
}
