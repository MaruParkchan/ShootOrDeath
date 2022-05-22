using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour , ITakeDamagable {

    [SerializeField] private int hp; // 적 체력
    [SerializeField] private int enemyPower = 0;
    [SerializeField] private int giveMoney;
    [SerializeField] private GameObject dieEffect; // 죽을시 이펙트
    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    void Update () {
        OnDie();
    }

    private void FixedUpdate()
    {
        PlayerCheck();

        if (movement.IsHit != true || !DataController.isDie)
            SupportCheck();

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    private void OnDie()
    {
        if (hp <= 0)
        {
            OnDieEffect();

            DataController.money += giveMoney;
            DataController.killScore++;
            CameraShake.shakeTime = 0.1f;
            Destroy(gameObject);
        }
    }

    void PlayerCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20.0f, 1 << LayerMask.NameToLayer("Player"));

        if (hit.transform != null)
        {
            if (Vector3.Distance(hit.transform.GetComponent<Collider2D>().bounds.center, transform.position) <= 2.1f)
            {
                hit.transform.gameObject.GetComponent<PlayerStat>().GetComponent<ITakeDamagable>().TakeDamage(enemyPower);
                OnDieEffect();
                Destroy(gameObject);
            }
        } 
    }

    void SupportCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20.0f, 1 << LayerMask.NameToLayer("Crazy"));
        if (hit.transform != null)
        {
            if (Vector3.Distance(hit.transform.position, transform.position) <= 1.0f)
            {
                movement.IsHit = true;
            }
        }
    }

    void OnDieEffect()
    {
        GameObject clone = Instantiate(dieEffect);
        clone.transform.position = transform.position;
    }
}
