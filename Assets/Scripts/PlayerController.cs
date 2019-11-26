using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float walkSpeed;

    private Vector2 moveInput;

    public Rigidbody2D theRB;

    public Transform gunArm;

    public Animator anim;

    public GameObject bulletToFire;
    public Transform firePoint;

    // Shot variables

    public float timeBetweenShots;
    private float shotCounter;

    public SpriteRenderer bodySR;

    // Dash variables
    private float activeMoveSpeed;
    public float dashSpeed = 8f, dashLength = 0.5f, dashCooldown = 1f, dashInvincLength = 0.5f;

    [HideInInspector]
    public float dashCounter;
    private float dashCoolCounter;

    private void Awake()
    {
        instance = this;  // this refers to this version of the script, whichever object has this script attached to it.    
    }



    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Remove speed boost for diagonal movement (1.41 units per frame)
        moveInput.Normalize();

        // transform.position += new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;

        theRB.velocity = moveInput * activeMoveSpeed;

        Vector3 mousePos = Input.mousePosition;

        // Calculate where the player is on the screen

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        // Face the direction the bullet firing,

        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }

        // Rotate gun arm

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);

        // Fire bullet

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)  // Not in a dash cooldown state or in the middle of an already activated dash
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                PlayerHealthController.instance.MakeInvincible(dashInvincLength);

                anim.SetTrigger("dash");
            }
           
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = walkSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }








        // Animation

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }


    }
}
