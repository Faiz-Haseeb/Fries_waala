using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load : MonoBehaviour
{
    public int num_customers;
    private int counter;
    public int num_attatched;
    public int table0 = 0;
    public int table1 = 0;
    public int orders = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        Invoke("ShowOnScreen", 2);
    }

    void ShowOnScreen()
    {
        GameObject originalGameObject = GameObject.Find("Customer GameObject");
        GameObject child = originalGameObject.transform.GetChild(counter).gameObject;

        child.GetComponent<Renderer>().enabled = true;
        counter++;

        if (counter < num_customers)
        {
            Invoke("ShowOnScreen", 2);
        }
    }
}
