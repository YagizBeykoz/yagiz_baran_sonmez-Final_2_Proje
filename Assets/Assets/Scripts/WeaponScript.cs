using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Camera playerCamera;

    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootDelay = 2f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;

    public GameObject muzzleEffect;
    private Animator animator;

    public TextMeshProUGUI ammoDisplay;

    public int magSize, bulletsLeft;
    private void Awake()
    {
        readyToShoot = true;
        animator = GetComponent<Animator>();
        bulletsLeft = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }

        if(ammoDisplay != null)
        {
            ammoDisplay.text = $"{bulletsLeft}";
        }
    }

    private void FireWeapon()
    {
        if (bulletsLeft > 0)
        {
            bulletsLeft--;

            muzzleEffect.GetComponent<ParticleSystem>().Play();
            animator.SetTrigger("RECOIL");
            SoundManager.Instance.shootSound.Play();

            readyToShoot = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.forward = bulletSpawn.transform.forward;
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

            StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

            ScoreScript.instance.ScoreUpdate();
            
        }

        if (bulletsLeft <= 0)
        {
            print("Mermin Kalmadi");
            SoundManager.Instance.emptySound.Play();
        }
    }


    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float 
        delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
