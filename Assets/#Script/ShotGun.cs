using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon {

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

          //  CreateBullet();
            base.FiringSound(1);
            base.CreateBullet();
            yield return new WaitForSeconds(gunConfig.fireRate);
        }
    }

    protected override void CreateBullet()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject clone = Instantiate(gunConfig.bulletPrefab);
            clone.transform.position = gunConfig.firePoint.position;
            clone.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-20f, 20f));
            clone.transform.GetComponent<Bullet>().bulletattribute.speed = Random.Range(5, 10);
        }
        gunConfig.currentAmmo--;
    }
}
