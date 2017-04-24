using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRapid : MonoBehaviour {

    public GameObject explosion;
    public float duration;
    public float fireRate;

    public float movementSpeed;
    public GameObject target;


    private void Awake()
    {
        Rigidbody2D powerRigidBody = GetComponent<Rigidbody2D>();

        // Rotate in direction of target.
        Vector2 moveDirection = (target.transform.position - this.transform.position).normalized;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }
    void Update()
    {
        

        // Move in the direction of the target
        Vector2 offset = target.transform.position - transform.position;
        Vector2 direction = offset.normalized;

        GetComponent<Rigidbody2D>().velocity = movementSpeed * direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Explode();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerWeapon>().PowerupRapid(this.duration, this.fireRate);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, audio.clip.length);

        }
    }

    private void Explode()
    {
        Instantiate(
            explosion,
            transform.position,
            transform.rotation);
        Destroy(this.gameObject);
    }
   
}
