using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public SpriteRenderer sr;

    public Sprite bOn;
    public Sprite bOff;
    public GameObject[] myButtons;
    public GameObject[] myPlatforms;
    public Vector2[] PlatStart;
    public Vector2[] PlatEnd;
    public float speed = .75f;

    private int lens = 0;
    public bool flip = false;

    private bool buttonPressed = false;
    public float fraction = 0;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < myButtons.Length; i++)
        {
            lens++;
        }


        if (buttonPressed)
        {
            this.sr.sprite = bOn;

            for (int i = 0; i < myButtons.Length; i++)
            {
                if (fraction < 1 && !flip)
                {
                    fraction += speed * Time.deltaTime;
                    myPlatforms[i].gameObject.transform.position = Vector2.MoveTowards(PlatStart[i], PlatEnd[i], fraction);
                }

                else if (fraction > 1 && flip)
                {
                    fraction -= speed * Time.deltaTime;
                    myPlatforms[i].gameObject.transform.position = Vector2.MoveTowards(PlatEnd[i], PlatStart[i], fraction);
                }
                    if (lens < i)
                    {
                        i = 0;
                    }
                }

            if (fraction >= 1)
            {
                if (flip)
                {
                    flip = false;
                    fraction = 0;
                }


                else if (fraction <= 1)
                {
                    if (!flip)
                    {
                        flip = true;
                        fraction = 2;
                    }
                }

            }
        }
        else
        {
            this.sr.sprite = bOff;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        buttonPressed = true;
    }
}
