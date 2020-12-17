using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{

    [Header("Standard Settings")]
    public GameObject usedButton;
    ButtonScript bs;

    public float speed;
    private Vector2 direction;

    [Header("Custom Settings")]
    [Tooltip("If true, doesn't require a button to activate, and is 'on' the entire time.")]
    public bool alwaysActive;

    // Start is called before the first frame update
    void Start()
    {
        bs = usedButton.GetComponent<ButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (bs.buttonPressed || alwaysActive)
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
    }


    //private void OnCollisionStay(Collision other)
    //{
    //    direction = transform.right;
    //    direction = direction * speed;

    //    other.rigidbody.AddForce(direction, ForceMode.Acceleration);
    //}
}
