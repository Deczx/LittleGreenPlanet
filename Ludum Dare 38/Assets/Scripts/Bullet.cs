using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Public vars
    public bool destroyOnImpact;


    // Private vars
    private float topBorder;
    private float bottomBorder;
    private float leftBorder;
    private float rightBorder;


	void Start () {
        float dist = (transform.position - Camera.main.transform.position).z;
        topBorder =     Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist)).y;
        bottomBorder =  Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        leftBorder =    Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder =   Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist)).x;
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.x > rightBorder  ||   transform.position.x < leftBorder   ||
            transform.position.y > topBorder    || transform.position.y < bottomBorder) {
            // Destroy our bullet when it leaves the screen
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyOnImpact && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
