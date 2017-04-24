using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour {
    
    //public vars
    public float swingSpeed; //How often can we swing

    //private vars
    private float timer;
    private bool isReady;
    private int swingDirection;

    private const int RIGHT = 0;
    private const int LEFT = 1;

    private void Start()
    {
        timer = 0.0f;
        isReady = true;
        swingDirection = RIGHT;
    }


    // Update is called once per frame
    void Update () {
        //Swing hammer in last moved direction
        if (Input.GetAxisRaw("Horizontal") < 0) swingDirection = LEFT;
        if (Input.GetAxisRaw("Horizontal") > 0) swingDirection = RIGHT;
       
        if (!isReady)
        {
            timer += Time.deltaTime;
            if (timer >= swingSpeed) isReady = true;
        }

        if (Input.GetButtonDown("Melee") && isReady)
        {
            SwingHammer();
        }
       
    }

    private void SwingHammer()
    {
        this.timer = 0.0f;
        this.isReady = false;
        this.GetComponent<AudioSource>().PlayDelayed(0.2f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>().Shake(1.0f);
        if (swingDirection == LEFT) this.GetComponent<Animation>().Play("SwingLeft");
        if (swingDirection == RIGHT) this.GetComponent<Animation>().Play("SwingRight");
    }

    public void DoneSwinging()
    {
        this.timer = 0.0f;
        this.isReady = false;
    }
}
