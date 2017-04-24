using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    //public vars
    public GameObject[] bulletPrefabs;
    public GameObject world;
    public float bulletspeed;
    public float fireRate;

    //private vars
    private float timer;
    private float powerupTimer;
    private bool isPoweredUp;
    private float defaultFireRate;
    private GameObject bulletPrefab;

    // Use this for initialization
    void Start() {
        timer = 0.0f;
        isPoweredUp = false;
        defaultFireRate = fireRate;
        bulletPrefab = bulletPrefabs[0];
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire"))
        {
            Fire();
            timer = 0.0f;
        }

        if (Input.GetButton("Fire"))
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                Fire();
                timer = 0.0f;
            }
        }
    }

    void Fire() {
        // Create a bullet
        GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);
        
        // Send it flying
        Vector2 shootDirection = -(world.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletspeed * shootDirection;

      
    }

    public void PowerupRapid(float duration, float rapidFireRate)
    {
        powerupTimer = duration;
        IEnumerator powerup = RapidFire(duration, rapidFireRate);
        StopAllCoroutines();
        StartCoroutine(powerup);
        
    }

    public void PowerupLarge(float duration, float newFireRate)
    {
        powerupTimer = duration;
        IEnumerator powerup = LargeFire(duration, newFireRate);
        StopAllCoroutines();
        StartCoroutine(powerup);
    }

    IEnumerator RapidFire(float duration, float newFireRate)
    {
        fireRate = newFireRate;
        bulletPrefab = bulletPrefabs[1];
        yield return new WaitForSeconds(powerupTimer);
        bulletPrefab = bulletPrefabs[0];
        fireRate = defaultFireRate;
    }

    IEnumerator LargeFire(float duration, float newFireRate)
    {
        fireRate = newFireRate;
        bulletPrefab = bulletPrefabs[2];
        yield return new WaitForSeconds(powerupTimer);
        bulletPrefab = bulletPrefabs[0];
        fireRate = defaultFireRate;
    }


}
