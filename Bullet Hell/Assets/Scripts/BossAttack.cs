using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
   
    private int bulletAmmount = 20;
    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;
    [SerializeField]
    private float freq = .5f;
    private Vector2 bulletMoveDirection;
    [SerializeField]
    public GameObject bulletPre;
    public GameObject boss;


    private void Update()
    {
        BossStages();
    }


    void Start()
    {
        InvokeRepeating("Fire", 0f, freq);
    }
 
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmmount;
        float angle = startAngle;
        for(int i = 0; i < bulletAmmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;


            GameObject bul = Instantiate(bulletPre, this.transform.position, Quaternion.identity);
            if (bul != null)
            {
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);
            }
            

            angle += angleStep;

        }
    }

    void BossStages(){
        Debug.Log(gameObject.GetComponent<Boss>().currentHealth);
        if (gameObject.GetComponent<Boss>().currentHealth >= 4500)
        {
            freq = .5f;
            bulletAmmount = 20;
        } else if(gameObject.GetComponent<Boss>().currentHealth > 1000)
        {
            freq = .3f;
            bulletAmmount = 26;
        } else if(gameObject.GetComponent<Boss>().currentHealth > 0)
        {
            freq = .2f;
            bulletAmmount = 34;
        }
    }
    
}
