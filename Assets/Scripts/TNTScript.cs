using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTScript : MonoBehaviour
{
    private bool canExplode = false;

    public float radius = 5.0F;
    public float power = 10.0F;
    public float timeRemaining = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canExplode)
        {
            timeRemaining = 2;
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if (timeRemaining < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ExplodeTNT();
    }

    public void ExplodeTNT()
    {
       canExplode = true;
    }
}
