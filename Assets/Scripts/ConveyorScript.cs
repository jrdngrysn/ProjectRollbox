using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{   

    public float speed;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("In Collision with: " + collision.gameObject.name);
        direction = transform.right;
        direction = direction * speed;

        Rigidbody2D collisionRB = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collisionRB)
        {
            Debug.Log("Found RigidBody2D");
            collisionRB.AddForce(direction * collisionRB.mass);
        }
    }


    //private void OnCollisionStay(Collision other)
    //{
    //    direction = transform.right;
    //    direction = direction * speed;

    //    other.rigidbody.AddForce(direction, ForceMode.Acceleration);
    //}
}
