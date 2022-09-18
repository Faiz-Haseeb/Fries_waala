using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orders : MonoBehaviour
{
    public int orderstaken;
    private int counter = 0;


    void Update()
    {
        GameObject originalGameObject = GameObject.Find("Customer GameObject");
        int t0 = originalGameObject.GetComponent<load>().table0;
        int t1 = originalGameObject.GetComponent<load>().table1;
        counter = t0 + t1;
        orderstaken = 0;
        for (int i = 0; i < counter; i++)
        {
            GameObject child = originalGameObject.transform.GetChild(i).gameObject;

            if (child.GetComponent<customer_behavior>().orderreceived == true && child.GetComponent<customer_behavior>().orderready == false)
            {
                orderstaken++;
            }
        }
    }
}