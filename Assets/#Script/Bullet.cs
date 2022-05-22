using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Penetration, Disappear , Explosions
}

public class Bullet : MonoBehaviour{

    [System.Serializable]
    public struct Bulletattribute
    {
        public float speed;
        public int power;
        public float destroyTime;
        public Collider2D collider2D;
        public GameObject explsionEffect;
        public BulletType bulletType;
    }

    public Bulletattribute bulletattribute = new Bulletattribute();
    private int bounsPower = 0;

    private void Awake()
    {
        StartCoroutine("DestroyBullet");
        bounsPower = PlayerPrefs.GetInt("Power");
    }

    void Update ()
    {
        BulletMove();
        HitCheckObject();
    }

    private void BulletMove()
    {
        transform.Translate(Vector3.right * bulletattribute.speed * Time.deltaTime * bounsPower, Space.Self);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(bulletattribute.destroyTime);
        Destroy(this.gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.transform.tag == "Tile")
    //        Destroy(gameObject);

    //    if (bulletattribute.userType == UserType.Player)
    //    {
    //        if (col.transform.tag == "Head")
    //        {
    //            Debug.Log("머리를 맞춤");

    //            if (col.transform.parent.GetComponent<EnemyStat>().GetComponent<ITakeDamagable>() != null)
    //            {
    //                col.transform.parent.GetComponent<EnemyStat>().GetComponent<ITakeDamagable>().TakeDamage(bulletattribute.power * 2);

    //                if (bulletattribute.bulletType == BulletType.disappear)
    //                    Destroy(this.gameObject);
    //            }
    //        }

    //        if (col.transform.tag == "Body")
    //        {
    //            Debug.Log("몸을 맞춤");

    //            if (col.transform.parent.GetComponent<EnemyStat>().GetComponent<ITakeDamagable>() != null)
    //            {
    //                col.transform.parent.GetComponent<EnemyStat>().GetComponent<ITakeDamagable>().TakeDamage(bulletattribute.power);

    //                if (bulletattribute.bulletType == BulletType.disappear)
    //                    Destroy(this.gameObject);
    //            }
    //        }
    //    }
    //}


    private void HitCheckObject()
    {
        RaycastHit2D hit;

        float centerX = bulletattribute.collider2D.bounds.center.x;
        float leftEndX = (centerX - bulletattribute.collider2D.bounds.size.x / 2) - 0.01f;
        float centerY = bulletattribute.collider2D.bounds.center.y;

        Debug.DrawRay(new Vector3(leftEndX, centerY), (Vector2.right * transform.localScale.x * 0.23f), Color.red);
        hit = Physics2D.Raycast(new Vector3(leftEndX, centerY), Vector2.right, transform.localScale.x * 0.23f);

        if (hit.transform.tag == "Tile")
            Destroy(gameObject);

        if (hit.transform.tag == "Enemy")
        {
            if (hit.transform.GetComponent<EnemyStat>().GetComponent<ITakeDamagable>() != null)
            {
                hit.transform.GetComponent<EnemyStat>().GetComponent<ITakeDamagable>().TakeDamage(bulletattribute.power);
                if (bulletattribute.bulletType == BulletType.Disappear)
                    Destroy(this.gameObject);

                if(bulletattribute.bulletType == BulletType.Explosions)
                {
                    GameObject clone = Instantiate(bulletattribute.explsionEffect);
                    clone.transform.position = transform.position;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    var hit = col.transform.GetComponent<ITakeDamagable>();
    //    if (hit != null)
    //    {
    //        hit.TakeDamage(bulletattribute.power);

    //        if (bulletattribute.bulletType == BulletType.disappear)
    //            Destroy(this.gameObject);
    //    }
    //}
    //private void HitCheck()
    //{
    //    RaycastHit2D hit;
    //    float cellSizeX;
    //    float cellSizeY;

    //    float centerX = bulletattribute.collider2D.bounds.center.x;
    //    float centerY = bulletattribute.collider2D.bounds.center.y;
    //    float leftEndX = centerX - bulletattribute.collider2D.bounds.size.x / 2;
    //    float leftEndY = centerY - bulletattribute.collider2D.bounds.size.y / 2;

    //    cellSizeX = bulletattribute.collider2D.bounds.size.x / (3 - 1);
    //    cellSizeY = bulletattribute.collider2D.bounds.size.y / (3 - 1); // 0 ,1 ,2 총 3개
    //                                                                    //  cellSizeY = bu
    //                                                                    //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, transform.localScale.x * 0.5f, 1 << LayerMask.NameToLayer("Tile"));
    //                                                                    // for(int i = 0; i < 3; i++)
    //                                                                    // P
    //                                                                    //pos = new Vector3(bulletattribute.collider2D.bounds.size - (bulletattribute.collider2D.bounds.size.x / 2), 0);
    //                                                                    //Debug.Log(bulletattribute.collider2D.bounds.center.x - bulletattribute.collider2D.bounds.size.x/3);

    //    //   Debug.DrawRay(new Vector3(leftEndX, centerY - cellSizeY), (Vector2.right * transform.localScale.x * 0.28f) , Color.red);
    //    Debug.DrawRay(new Vector3(leftEndX, centerY), (Vector2.right * transform.localScale.x * 0.2f), Color.red);
    //    //   Debug.DrawRay(new Vector3(leftEndX, centerY + cellSizeY), (Vector2.right * transform.localScale.x * 0.28f) , Color.red);

    //    //  hit = Physics2D.Raycast(new Vector3(leftEndX, centerY - cellSizeY), Vector2.right, transform.localScale.x * 0.28f, 1 << LayerMask.NameToLayer("Tile"));
    //    hit = Physics2D.Raycast(new Vector3(leftEndX, centerY), Vector2.right, transform.localScale.x * 0.2f, 1 << LayerMask.NameToLayer("Tile"));
    //    //  hit = Physics2D.Raycast(new Vector3(leftEndX, centerY + cellSizeY), Vector2.right, transform.localScale.x * 0.28f, 1 << LayerMask.NameToLayer("Tile"));

    //    //Debug.DrawRay(new Vector3(leftEndY, centerX - cellSizeX), (Vector2.down * transform.localScale.y * 0.28f), Color.yellow);
    //    //Debug.DrawRay(new Vector3(leftEndY, centerX            ), (Vector2.down * transform.localScale.y * 0.28f), Color.yellow);
    //    //Debug.DrawRay(new Vector3(leftEndY, centerX + cellSizeX), (Vector2.down * transform.localScale.y * 0.28f), Color.yellow);

    //    //  Debug.DrawRay(leftEndPoint + new Vector3(0,1), (Vector2.right * transform.localScale.x * 0.28f), Color.red);  // 1.0 * 2.0 * 0.5f 2.0 * 0.5

    //    //   Debug.Log("col " + bulletattribute.collider2D.bounds.center);
    //}
}
