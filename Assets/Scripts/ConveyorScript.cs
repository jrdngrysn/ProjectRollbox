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
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            Debug.Log("Found RigidBody2D");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * collision.gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Force);
        }
    }


    //private void OnCollisionStay(Collision other)
    //{
    //    direction = transform.right;
    //    direction = direction * speed;

    //    other.rigidbody.AddForce(direction, ForceMode.Acceleration);
    //}
}
