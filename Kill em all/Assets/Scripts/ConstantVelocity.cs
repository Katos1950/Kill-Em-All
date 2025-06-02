using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Velocity checker
public class ConstantVelocity : MonoBehaviour
{
    [SerializeField] float xVelo = 14.14214f;
    [SerializeField] float yVelo = 14.14214f;
    Rigidbody2D rigidbody;
    Rigidbody2D rb;
    int maxCollisionCount = 10;
    int collisionCount = 0;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collisionCount >= maxCollisionCount)
        {
            Destroy(gameObject);
        }

        collisionCount++;
        if(rigidbody.velocity.x < 0 &&rigidbody .velocity.y < 0)
        {
            rigidbody.velocity = new Vector2(-xVelo,-yVelo);
        }
        else if(rigidbody.velocity.x < 0 &&rigidbody .velocity.y > 0)
        {
            rigidbody.velocity = new Vector2(-xVelo,yVelo);
        }
        else if(rigidbody.velocity.x > 0 &&rigidbody .velocity.y < 0)
        {
            rigidbody.velocity = new Vector2(xVelo,-yVelo);
        }
        else if(rigidbody.velocity.x > 0 &&rigidbody .velocity.y > 0)
        {
            rigidbody.velocity = new Vector2(xVelo,yVelo);
        }
    }
}
