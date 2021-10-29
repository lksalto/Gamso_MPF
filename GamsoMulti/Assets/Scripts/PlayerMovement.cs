using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool canJump = true;
    [SerializeField] float jumpSpeed;
    [SerializeField] float movementSpeed;

    [SerializeField] float rayLenght;
    [SerializeField] float rayPositionOffset;

    Vector3 rayPositionCenter;
    Vector3 rayPositionRight;
    Vector3 rayPositionLeft;

    RaycastHit2D[] groundHitsCenter;
    RaycastHit2D[] groundHitsLeft;
    RaycastHit2D[] groundHitsRight;
    RaycastHit2D[][] allRaycastHits = new RaycastHit2D[3][];
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Movement();
        Jump();
    }
    void Movement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if ((Input.GetKey(KeyCode.W)) && (canJump))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
    void Jump()
    {
        rayPositionCenter = transform.position + new Vector3(0, rayLenght * 0.01f, 0);
        rayPositionLeft = transform.position + new Vector3(-rayPositionOffset, rayLenght * 0.01f, 0);
        rayPositionRight = transform.position + new Vector3(rayPositionOffset, rayLenght * 0.01f, 0);
        groundHitsCenter = Physics2D.RaycastAll(rayPositionCenter, -Vector2.up, rayLenght);
        groundHitsLeft = Physics2D.RaycastAll(rayPositionLeft, -Vector2.up, rayLenght);
        groundHitsRight = Physics2D.RaycastAll(rayPositionRight, -Vector2.up, rayLenght);
        allRaycastHits[0] = groundHitsCenter;
        allRaycastHits[1] = groundHitsLeft;
        allRaycastHits[2] = groundHitsRight;
        canJump = GroundCheck(allRaycastHits);
        Debug.DrawRay(rayPositionCenter, -Vector2.up * rayLenght, Color.red);
        Debug.DrawRay(rayPositionLeft, -Vector2.up * rayLenght, Color.red);
        Debug.DrawRay(rayPositionRight, -Vector2.up * rayLenght, Color.red);
    }
    bool GroundCheck(RaycastHit2D[][] GroundHits)
    {
        foreach(RaycastHit2D[] HitList in GroundHits)
        {
            foreach(RaycastHit2D hit in HitList)
            {
                if(hit.collider != null)
                {
                    if (hit.collider.tag != "PlayerCollider")
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
