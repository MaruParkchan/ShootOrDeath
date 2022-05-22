using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour , ITakeDamagable {

    [SerializeField] private GameObject dieEffect;
    [SerializeField] private int maxHp = 0;
    [SerializeField] private int currentHp = 0;
    public int MaxHp { get { return maxHp; } }
    public int CurrentHp { get { return currentHp; } }

    void Update () {
        if (currentHp <= 0)
            OnDie();

        if (Input.GetKeyDown(KeyCode.I))
            UpgradeCastle(5000);
    }

    public void UpgradeCastle(int num)
    {
        maxHp += num;
        currentHp += num;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    private void OnDie()
    {
        GameObject clone = Instantiate(dieEffect);
        clone.transform.position = transform.position;
        DataController.isDie = true;
        Destroy(gameObject);
    }
}
