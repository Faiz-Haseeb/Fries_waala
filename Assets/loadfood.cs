using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadfood : MonoBehaviour
{
    public int num_orders;
    private int counter;
    private orders parentComp;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    void Update()
    {
        parentComp = GetComponentInParent<orders>();
        num_orders = parentComp.orderstaken;

        if (num_orders > counter)
        {
            ShowOnScreen();
            counter++;
        }
    }

    void ShowOnScreen()
    {
        GameObject originalGameObject = GameObject.Find("Food GameObject");
        GameObject child = originalGameObject.transform.GetChild(counter).gameObject;

        child.GetComponent<Renderer>().enabled = true;
    }
}