using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    //Vector2 mousePos;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float widthRel = .3f / (Screen.width); //relative width
        float heightRel = .3f / (Screen.height); //relative height

        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, widthRel, 1 - widthRel);
        viewPos.y = Mathf.Clamp(viewPos.y, heightRel, 1 - heightRel);
        this.transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
