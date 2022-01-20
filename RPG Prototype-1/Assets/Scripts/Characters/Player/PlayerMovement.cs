using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Walk/Run Variables
    [SerializeField]
    private static float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f, /*maxVelocity = 22f,*/ rotationSpeed = 100.0f, sprintMultiplier = 2f, playerSpeed = moveForce;
    private float movementX, movementZ;
    // Jump Variables
    [SerializeField]
    private float fallMultiplier = 4f, lowJumpMultiplier = 3f;
    [SerializeField]
    private bool isGrounded = true;
    // String Vars
    private string GROUND_TAG = "Ground", JUMP_BUTTON = "Jump", HORZ_AXIS = "Horizontal", VERT_AXIS = "Vertical", SPRINT_BUTTON = "Sprint";

    //[SerializeField]
    private Rigidbody playerBody;
    //private Animator anim;
    //private string WALK_ANIMATION = "Walk";
    void Awake()
    {
        playerBody = this.GetComponent<Rigidbody>();
        //anim = getComponent<Animator>();
        //sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        //Player Rotates
        float rotation = Input.GetAxis(HORZ_AXIS) * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        // Player Sprints Forward
        if (Input.GetButtonDown(SPRINT_BUTTON))
        {
            playerSpeed *= sprintMultiplier;
        }
        if (Input.GetButtonUp(SPRINT_BUTTON))
        {
            playerSpeed = moveForce;
        }
        
        // Player Moves Forward/Backward
        float move = Input.GetAxis(VERT_AXIS) * playerSpeed * Time.deltaTime;
        transform.position += transform.forward * move;

        // Player Jumps Back

        // Player Jumps
//*** Improve Upwards Jump Force
        if(Input.GetButtonDown(JUMP_BUTTON) && isGrounded)
        {
            isGrounded = false;
            playerBody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);

        }
        // Player Short Jumps
        else if (playerBody.velocity.y > 0 && !Input.GetButton(JUMP_BUTTON))
        {
            playerBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }

        // Player Falling
        if(playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;
    }
}
