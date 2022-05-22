using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Weapon[] weapon;
    [SerializeField] GameObject reloadBar;
    private KeyCode reloadButton = KeyCode.R;
    private KeyCode jumpButton = KeyCode.Space;
    private int baseGunNumber = 0;

    private int nums; // 지워야함

    private void Awake()
    {
        baseGunNumber = 0;     
    }

    public void Updated()
    {
        InputControl();
    }

    void InputControl()
    {
        if (!weapon[baseGunNumber].isReload)
        {
            if (Input.GetMouseButtonDown(0))
                weapon[baseGunNumber].StartFire();

            if (Input.GetMouseButtonUp(0))
                weapon[baseGunNumber].StopFire();
        }

        if (Input.GetKeyDown(reloadButton) && weapon[baseGunNumber].IsMaxAmmo > 0)
        {
            if (weapon[baseGunNumber].isReload != true)
                weapon[baseGunNumber].ReloadSound();

                reloadBar.SetActive(true);
                weapon[baseGunNumber].isReload = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
            DataController.money += 5000;


    }

    public void GunChange(int num)
    {
        weapon[baseGunNumber].isReload = false;
        reloadBar.SetActive(false);
        weapon[baseGunNumber].IsFire = false;
        weapon[baseGunNumber].StopFire();
        weapon[baseGunNumber].gameObject.SetActive(false);
        baseGunNumber = num;
        weapon[baseGunNumber].gameObject.SetActive(true);
    }
}
