using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform RayPoint;

    public float health;
    public float speed;
    float x;
    public float StopDist;
    // Update is called once per frame
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();

      RaycastHit2D hitInfo =  Physics2D.Raycast(RayPoint.position, RayPoint.right, StopDist);

        Debug.DrawRay(RayPoint.position, RayPoint.right, Color.green);

        if (hitInfo)
        {
            x = 0;
        } else
        {
            x = -1;
        }

    }

    void Flip() {
        Debug.Log("Hit");
    }


    void Move()
    {
        Debug.Log("Hit");

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

}

