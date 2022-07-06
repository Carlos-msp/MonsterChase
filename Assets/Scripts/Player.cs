using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Parameters
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpVelocity = 20f;

    // Physics
    private float movementX;
    // Components
    private Rigidbody2D selfRigidBody;
    private SpriteRenderer selfSpriteRenderer;
    private Animator selfAnimator;
    // External Variables and Strings
    private const string WALK_ANIMATION_VARIABLE = "Walk";
    private const string GROUND_TAG = "Walkable";
    // State Variables
    private bool isGrounded = false;

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
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveSpeed;
        AnimatePlayer();
    }

    void CaptureInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (!isGrounded) { return; }
        selfRigidBody.velocity = selfRigidBody.velocity + new Vector2(0f, jumpVelocity);
        isGrounded = false;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            selfAnimator.SetBool(WALK_ANIMATION_VARIABLE, true);
            selfSpriteRenderer.flipX = false;
        }
        else if (movementX < 0)
        {
            selfAnimator.SetBool(WALK_ANIMATION_VARIABLE, true);
            selfSpriteRenderer.flipX = true;
        }
        else
        {
            selfAnimator.SetBool(WALK_ANIMATION_VARIABLE, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collided)
    {
        Debug.Log("Collided with " + collided);
        if (collided.gameObject.tag.Equals(GROUND_TAG)) {
            isGrounded = true;
        }
    }

}
