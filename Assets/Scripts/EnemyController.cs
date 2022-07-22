using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public Transform target;
    private Rigidbody2D myBody;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (myBody.position.x < target.position.x)
        {
            speed = Mathf.Abs(speed);
        } else {
            speed = -Mathf.Abs(speed);
        }
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
