using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodbehavior : MonoBehaviour
{
    private bool fin;
    private load parentComp;
    private int counter = 0;

    private void start()
    {
        fin = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player" && fin == false)
        {
            fin = true;
            DisableSprite();
        }
        if (other.gameObject.tag == "Customer" && fin == true)
        {
            fin = false;
        }
    }

    private void DisableSprite()
    {
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        GameObject player = GameObject.Find("main_character");
        GameObject child = player.transform.GetChild(counter).gameObject;
        counter++;
        child.GetComponent<Renderer>().enabled = true;

    }
}