using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;
    [SerializeField]
    public int maxHealth = 6000;
    [SerializeField]
    public int currentHealth;

    public HealthBar healthBar;

    private int frame = 0;

    private GameObject playerPos;

    private int stage = 1;

    void Start()
    {
        playerPos = GameObject.Find("Player");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        moveSpeed = 2f;
        moveRight = true;
    }

    void Update()
    {
        SetBossStage(ref stage);
        DamageIndicator();
        //death
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public int SetBossStage(ref int stage)
    {
        if (currentHealth >= 4500)
        {
            stage = 1;
        }
        else if (currentHealth >= 1000)
        {
            stage = 2;
        }
        else if (currentHealth > 0)
        {
            stage = 3;
        }

        switch (stage)
        {
            case 1:
                RightLeftMovement();
                moveSpeed = 2f;
                break;
            case 2:
                RightLeftMovement();
                moveSpeed = 4f;
                break;
            case 3:
                moveSpeed = 7f;
                //rotates boss
                //transform.Rotate(Vector3.forward * 15f * Time.deltaTime);
                RightLeftMovement();
                break;
        }
        return stage;
    }

    void RightLeftMovement()
    {
        if (transform.position.x > 7f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -7f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void DamageIndicator(){
        if (frame < 2)
        {
            frame++;
        }
        else
        {
            var ColorCheck = new Color(225, 0, 182);
            if (this.gameObject.GetComponent<SpriteRenderer>().color != ColorCheck)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = ColorCheck;
            }

            frame = 0;
        }
    }



}
