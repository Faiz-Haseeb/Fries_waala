using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodbehavior : MonoBehaviour
{
    private bool attatched;
    private bool fin;
    public bool orderready;
    public bool orderreceived;
    private load parentComp;
    private int counter = 0;

    private void start()
    {
        attatched = false;
        fin = false;
        orderready = false;
        orderreceived = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        parentComp = GetComponentInParent<load>();

        if (other.gameObject.tag == "Player" && fin == false)
        {
            attatched = true;
            fin = true;
            DisableSprite();
        }
        if (other.gameObject.tag == "Table")
        {
            attatched = false;
            DisableSprite();
        }
        if (other.gameObject.tag == "Table1")
        {
            attatched = false;
            DisableSprite();
        }

    }

    private void DisableSprite()
    {
        this.GetComponent<Renderer>().enabled = false;
        GameObject player = GameObject.Find("main_character");
        GameObject child = player.transform.GetChild(counter).gameObject;
        counter++;
        child.GetComponent<Renderer>().enabled = true;

    }
}
