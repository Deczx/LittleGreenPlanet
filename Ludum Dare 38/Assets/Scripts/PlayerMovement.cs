using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    // the "planet" we want to be running around.
    public GameObject world;

    // Movement Speed
    public float moveSpeed;

    void Update()
    {
        // move around our world 
        float direction = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(world.transform.position, Vector3.forward, -direction * moveSpeed * Time.deltaTime);
    }
}

