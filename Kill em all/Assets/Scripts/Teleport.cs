using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject teleportTo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Vector3 contact = collision.GetContact(0).point - new Vector2( transform.position.x, transform.position.y);
            collision.gameObject.transform.position = teleportTo.transform.position + contact;
        }
    }
}
