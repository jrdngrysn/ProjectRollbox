using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTScript : MonoBehaviour
{
    Rigidbody2D rb;
    private bool canExplode = false;

    public float radius = 5.0F;
    public float power = 10.0F;
    public float timeRemaining = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canExplode)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if (timeRemaining < 0)
            {
                rb.AddExplosionForce(power, this.transform.position, radius);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D collisionRB = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collisionRB)
        {
            ExplodeTNT();
        }
        
    }

    public void ExplodeTNT()
    {
       canExplode = true;
    }

}
