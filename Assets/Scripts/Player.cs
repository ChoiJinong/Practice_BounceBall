using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public GameObject panel;
    public List<GameObject> list_Stars = new List<GameObject>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1 ~ 1
        //float v = Input.GetAxis("Vertical");
        rb.linearVelocityX = h * moveSpeed;
        if (transform.position.y < -5)
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = new Vector3(-7.5f, 1, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector3(-7.5f, 1, 0);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            int idx = Array.IndexOf(list_Stars.ToArray(), collision.gameObject);
            list_Stars.RemoveAt(idx);
            Destroy(collision.gameObject);
            if (list_Stars.Count == 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0; // ½Ã°£ ¸ØÃã
            }
        }
        else
        {
            rb.AddForceY(1 * jumpForce);
        }
    }
}
