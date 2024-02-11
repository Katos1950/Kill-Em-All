using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallButton : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            rigidBody.isKinematic = false;
            Destroy(gameObject);
        }
    }
}
