using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon {

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

            if (IsFire == false)
                yield return new WaitForSeconds(2.0f);
            else
                yield return new WaitForSeconds(gunConfig.fireRate);

            IsFire = true;
            base.FiringSound(1);
            GameObject clone = Instantiate(gunConfig.bulletPrefab);
            clone.transform.position = gunConfig.firePoint.position;
            clone.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-5f, 5f));
            gunConfig.currentAmmo--;

            
        }
    }

}
