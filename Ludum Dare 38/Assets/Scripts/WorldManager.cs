using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    // Public Vars
    public int maxHealth;
    public float damageDelay;
    public GameObject nextLayer;
    public GameObject gameMenu;

    // Private Vars
    private int currentHealth;
    private float timer;
    private const int DMG = 1;
    private bool isDestroyed;
    private Color startingColor;

    private SpriteRenderer sprite;
    private GameObject mainCamera;


    void Start () {
        currentHealth = maxHealth;
        isDestroyed = false;
        sprite = GetComponent<SpriteRenderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        startingColor = sprite.color;
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDestroyed)
        {
            DestroyLayer();

            if(nextLayer != null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            // We first calculate the normal of our movement since we have to move towards the center of the planet
            Vector3 dir = (player.transform.position - transform.position).normalized;
            // Then we calculate the scale of the movement Vector. Since we have a sphere we can just take the difference over one of the axis and divide it by 2.
            player.transform.localPosition -= ((GetComponent<SpriteRenderer>().bounds.size.x - nextLayer.GetComponent<SpriteRenderer>().bounds.size.x) * dir) / 2;
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        timer += Time.deltaTime;
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            //if (currentHealth <= 0)
            //{
            //    Destroy(collision.gameObject);
            //}
                
            
            if (timer >= damageDelay)
            {
                TakeDamage(DMG);
                timer = 0.0f;
                Debug.Log("DAMAGE!");
                UpdateColor();
                
            }

        }

    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }

    private void DestroyLayer()
    {

        if (nextLayer == null)
        {
            gameMenu.GetComponent<GameMenu>().GameOver();
        }
        else
        {
            isDestroyed = true;
            mainCamera.GetComponent<ScreenShake>().Shake(2.0f);
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void UpdateColor()
    {
        Color c = sprite.color;
        c.r += (255 - sprite.color.r) / maxHealth;
        c.g -= (sprite.color.g) / maxHealth;

        sprite.color = c;
    }

    public void ResetWorld()
    {
        currentHealth = maxHealth;
        isDestroyed = false;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = startingColor;
    }
}
