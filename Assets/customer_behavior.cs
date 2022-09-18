using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class customer_behavior : MonoBehaviour
{
    public bool orderfinished;
    private Vector3 moveDelta;
    private bool fin;
    private float moveSpeed = 3.0f;
    public bool orderready;
    public bool orderreceived;
    private load parentComp;
    private int completed = 0;
    private int total;
    private bool attatched;

    private void start()
    {
        attatched = false;
        orderfinished = true;
        fin = false;
        orderready = false;
        orderreceived = false;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        parentComp = GetComponentInParent<load>();
        total = GameObject.Find("Customer GameObject").GetComponent<load>().num_customers;
        if (other.gameObject.tag == "Player" && fin == false && parentComp.num_attatched < 1)
        {
            attatched = true;
            fin = true;
            parentComp.num_attatched += 1;
        }
        if (other.gameObject.tag == "Table" && parentComp.table0 < 2)
        {
            attatched = false;
            parentComp.table0 += 1;
            parentComp.num_attatched = 0;
            Invoke("set_order_ready", 3);
        }
        if (other.gameObject.tag == "Table1" && parentComp.table1 < 2)
        {
            attatched = false;
            parentComp.table1 += 1;
            parentComp.num_attatched = 0;
            Invoke("set_order_ready", 3);
        }

        if (other.gameObject.tag == "Player" && fin == true && parentComp.num_attatched == 0 && orderready == true && orderreceived == false)
        {
            Debug.Log("Order Received");
            orderreceived = true;
            orderready = false;
        }
        GameObject player = GameObject.Find("main_character");
        for (int i = 0; i < 3; i++)
        {
            GameObject child = player.transform.GetChild(i).gameObject;
            if (other.gameObject.tag == "Player" && child.GetComponent<Renderer>().enabled == true)
            {
                Debug.Log("disable sprite");
                child.GetComponent<Renderer>().enabled = false;
                this.GetComponent<Renderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
                completed += 1;
                this.GetComponent<Rigidbody2D>().isKinematic = true;
                orderfinished = true;
                parentComp.table0 -= 1;
                parentComp.table1 -= 1;
            }
        }

        if (completed == total-1)
        {
            Debug.Log(total);
            Debug.Log("hi");
            SceneManager.LoadScene(3);
        }
    }

    private void set_order_ready()
    {
        orderready = true;
    }

    private void Update()
    {
        if (attatched == true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector2 mousePos = Input.mousePosition;
                Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

                moveDelta = new Vector3(pos.x, pos.y, 0.0f);

            }
            /*hitx = Physics2D.BoxCast(transform.position, boxCollider.size,
                      0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            hity = Physics2D.BoxCast(transform.position, boxCollider.size,
                      0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

            if (hitx.collider == null && hity.collider == null)
            {*/
            transform.position = Vector3.MoveTowards(transform.position, moveDelta, Time.deltaTime * moveSpeed);
        }
    }

}