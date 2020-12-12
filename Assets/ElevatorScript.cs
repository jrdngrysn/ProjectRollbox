using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public ButtonScript bs;

    public GameObject button;
    private Vector2 PlatStart;
    public Vector2 PlatEnd;
    public float speed = .1f;

    private float distBetween;
    private float distBetween2;
    public bool flip = false;
    public bool isDoor = false;


    // Start is called before the first frame update
    void Start()
    {
        bs = button.GetComponent<ButtonScript>();
        PlatStart = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bs.buttonPressed)
        {

            distBetween = Vector2.Distance(this.transform.position, PlatEnd);
            distBetween2 = Vector2.Distance(this.transform.position, PlatStart);

            if (!flip)
            {
                this.gameObject.transform.position = (Vector3)Vector2.Lerp(this.gameObject.transform.position, PlatEnd, speed * Time.deltaTime);
            }

            else if (flip && !isDoor)
            {
                this.gameObject.transform.position = (Vector3)Vector2.Lerp(this.gameObject.transform.position, PlatStart, speed * Time.deltaTime);
            }

            if (distBetween < .4f && !flip)
            {
                if (!flip)
                {
                    flip = true;
                }
            }

            if (distBetween2 < .4f && flip)
            {
                if (flip)
                {
                    flip = false;
                }
            }


        }

        else if (!bs.buttonPressed && isDoor)
        {
            this.gameObject.transform.position = (Vector3)Vector2.Lerp(this.gameObject.transform.position, PlatStart, speed * Time.deltaTime);
        }
    }
}


