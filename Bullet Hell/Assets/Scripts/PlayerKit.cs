using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerKit : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;
    Boss target;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    public float bulletForce = 20f;
    public float FireRate = 8;
    public float lastfired;

    public Image HitIndicator;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }

        if (HitIndicator != null)
        {
            if(HitIndicator.GetComponent<Image>().color.a > 0)
            {
                var color = HitIndicator.GetComponent<Image>().color;
                color.a -= .07f;
                HitIndicator.GetComponent<Image>().color = color;
            }
            
        }

        //Death
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        


    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        target = GameObject.FindObjectOfType<Boss>();
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce((target.transform.position-transform.position).normalized * bulletForce, ForceMode2D.Impulse);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        var color = HitIndicator.GetComponent<Image>().color;
        color.a = .8f;
        HitIndicator.GetComponent<Image>().color = color;

    }
}
