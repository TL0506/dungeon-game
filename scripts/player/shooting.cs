using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = 5 * transform.right;
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            BasicEnemy basic = collision.gameObject.GetComponent<BasicEnemy>();
            basic.damage(2);
            Debug.Log("enemy hit");
        }
    }
}
