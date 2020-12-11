using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite bOn;
    public Sprite bOff;
    public bool buttonPressed = false;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            this.sr.sprite = bOn;
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        buttonPressed = false;
    }
}
