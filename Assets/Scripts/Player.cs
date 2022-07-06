using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private Rigidbody2D selfRigidBody;
    private SpriteRenderer selfSpriteRenderer;
    private Animator selfAnimator;
    private const string WALK_ANIMATION_VARIABLE = "Walk";

    private void Awake()
    {
        selfRigidBody = GetComponent<Rigidbody2D>();
        selfSpriteRenderer = GetComponent<SpriteRenderer>();
        selfAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CaptureInput();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        AnimatePlayer();
    }

    void CaptureInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            selfAnimator.SetBool(WALK_ANIMATION_VARIABLE, true);
        }
        else if (movementX < 0)
        {
            selfAnimator.SetBool(WALK_ANIMATION_VARIABLE, true);
        }
        else
        {
            selfAnimator.SetBool(WALK_ANIMATION_VARIABLE, false);
        }
    }
}
