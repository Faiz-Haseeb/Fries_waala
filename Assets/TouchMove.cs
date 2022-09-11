using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    private Vector3 moveDelta;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        // swap sprite location
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //gets called as long as you keep touching screen.
        if (Input.GetMouseButton(0))
        {
            //gets mouse position and converts it into world coordinates (linear interpolation?).
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size,
            0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime * 2, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size,
            0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime * 2, 0, 0);
        }
    }

    /*
    void TouchMove()
    {
        //gets called as long as you keep touching screen.
        if(Input.GetMouseButton(0))
        {
            //gets mouse position and converts it into world coordinates (linear interpolation?).
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);

        }
    }
    */
}
