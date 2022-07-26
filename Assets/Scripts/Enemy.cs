using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Rigidbody2D myBody;
    
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!target) {return;}

        if (myBody.position.x < target.position.x)
        {
            speed = Mathf.Abs(speed);
        } else {
            speed = -Mathf.Abs(speed);
        }
        myBody.velocity = new Vector2(Mathf.Lerp(myBody.velocity.x, speed, Time.deltaTime), myBody.velocity.y);
    }
}
