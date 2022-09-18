using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock_appear : MonoBehaviour
{
    private load parentComp;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        parentComp = GetComponentInParent<load>();

        if (other.gameObject.tag == "Table")
        {
            EnableSprite();
        }
        if (other.gameObject.tag == "Table1")
        {
            EnableSprite();
        }
    }


    private void EnableSprite()
    {
        this.GetComponent<Renderer>().enabled = true;
        GameObject player = GameObject.Find("customer");
        GameObject child = player.transform.GetChild(counter).gameObject;
        counter++;
        child.GetComponent<Renderer>().enabled = false;
    }
}
