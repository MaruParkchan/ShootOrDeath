using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour {

	[System.Serializable]
    public struct GunConfig
    {
        public GameObject bulletPrefab;
        public float fireRate;
        public float reloadCurrentTime;
        public int limitGetMax; // 최대 장탄 수
        public int limitAmmoMax; // 최대 가질수 있는 총알
        public int currentAmmo;
        public int maxAmmo;
        public Transform firePoint;
        public AudioSource audioSource;
        public AudioClip[] gunfireClip;
    }

    [SerializeField] GameObject aim;
    private Vector3 aimPostion;

    private Slider reloadBar;
    private SpriteRenderer parentRedner;
    private SpriteRenderer renderer; // 총 Sprite 바꾸기

    [SerializeField] protected GunConfig gunConfig = new GunConfig();

    public bool IsFire { get; set; }
    public bool IsFireStop { get; set; }
    public int IsMaxAmmo { get { return gunConfig.maxAmmo; } }
    public int IsCurrentAmmo { get { return gunConfig.currentAmmo; } }
    public int LimitAmmoMax { get { return gunConfig.limitAmmoMax; } }
    public bool isButtonDown;
    public bool isReload;
    private float reloadBaseTime;

    private void Awake()
    {
        parentRedner = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        renderer = GetComponent<SpriteRenderer>();
        reloadBaseTime = gunConfig.reloadCurrentTime;
    }

    private void Update()
    {
        MouseAim();
        LookAtMouse();
        ReloadGun();
      //  RotateSprite();
        LimitMaxAmmo();
    }

    void MouseAim()
    {
        aimPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPostion.z = 0.0f;
        aim.transform.position = aimPostion;
    }

    public void LookAtMouse()
    {     
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        dir.z = 0;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    public void StartFire()
    {
        if(IsFire == false && isButtonDown != true)
        {
            IsFire = true;
            IsFireStop = false;
            StartCoroutine("Firing");
        }
    }

    public void StopFire()
    {
        IsFireStop = true;
    }

    public void ReloadGun()
    {
        if(isReload)
        {
            reloadBar = GameObject.FindWithTag("ReloadBar").GetComponent<Slider>();
            reloadBar.maxValue = reloadBaseTime;
            reloadBar.value = gunConfig.reloadCurrentTime;
            gunConfig.reloadCurrentTime -= Time.deltaTime;
            if (gunConfig.reloadCurrentTime < 0)
            {
                if(gunConfig.maxAmmo + gunConfig.currentAmmo > gunConfig.limitGetMax) 
                {
                    gunConfig.maxAmmo -= (gunConfig.limitGetMax - gunConfig.currentAmmo);
                    gunConfig.currentAmmo += (gunConfig.limitGetMax - gunConfig.currentAmmo);
                }
                else
                {                  
                    gunConfig.currentAmmo += gunConfig.maxAmmo;
                    gunConfig.maxAmmo = 0;
                }

                gunConfig.reloadCurrentTime = reloadBaseTime;
                reloadBar.gameObject.SetActive(false);
                isReload = false;
            }
        }
        else
            gunConfig.reloadCurrentTime = reloadBaseTime;
    }

    public void BuyAmmo(int count)
    {
        gunConfig.maxAmmo += count;
    }

    private void LimitMaxAmmo()
    {
        if (gunConfig.maxAmmo > gunConfig.limitAmmoMax)
            gunConfig.maxAmmo = gunConfig.limitAmmoMax;
    }

    protected virtual void FiringSound(int num)
    {
//      gunConfig.audioSource.PlayOneShot(gunConfig.gunfireClip[num]);
        AudioSource.PlayClipAtPoint(gunConfig.gunfireClip[num], Camera.main.transform.position);
    }

    public void ReloadSound()
    {
        gunConfig.audioSource.clip = gunConfig.gunfireClip[2];
        gunConfig.audioSource.Play();
    }

    protected abstract IEnumerator Firing();

    protected virtual void CreateBullet()
    {
        GameObject clone = Instantiate(gunConfig.bulletPrefab);
        clone.transform.position = gunConfig.firePoint.position;
        clone.transform.rotation = transform.rotation;
        gunConfig.currentAmmo--;
    }

    //void RotateSprite()
    //{
    //    if (90 < transform.eulerAngles.z && transform.eulerAngles.z < 270)
    //    {
    //        parentRedner.flipX = true;
    //        renderer.flipY = true;
    //    }
    //    else
    //    {
    //        parentRedner.flipX = false;
    //        renderer.flipY = false;
    //    }
    //}
   
}
