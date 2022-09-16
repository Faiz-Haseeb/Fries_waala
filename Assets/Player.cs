using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hitx;
    private RaycastHit2D hity;
    private float moveSpeed = 2.0f;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
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
        /*}*/
    }

}
