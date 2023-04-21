using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

   private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().TakeDamage(10);
            var color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(240, 53, 68);
        }
        
    }

}
