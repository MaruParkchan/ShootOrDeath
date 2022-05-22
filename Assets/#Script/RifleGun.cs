using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleGun : Weapon {

    protected override IEnumerator Firing()
    {
        while (true)
        {
            if (gunConfig.currentAmmo <= 0)
            {
                base.FiringSound(0);
                gunConfig.currentAmmo = 0;
                IsFire = false;
                yield break;
            }

            if (IsFireStop)
            {
                IsFire = false;
                yield break;
            }

            base.CreateBullet();
            base.FiringSound(1);

            yield return new WaitForSeconds(gunConfig.fireRate);
        }
    }
}
