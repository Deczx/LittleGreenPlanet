using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    
    // Public vars
    public float shakeAmount = 0.25f; 
    public float decreaseFactor = 1.0f;

    // Private vars
    private new Camera camera;
    private Vector3 cameraPos;
    private float shake = 0.0f;


    private void Awake()
    {
        this.camera = (Camera)this.GetComponent<Camera>();

        // Check if the script is attached to an Object with a Camera attached,
        if (this.camera == null)
        {
            // Print an error.
            Debug.Log("CameraShake: Unable to find 'Camera' component attached to GameObject.");
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (IsShaking())
        {
            this.camera.transform.localPosition = Random.insideUnitCircle * this.shakeAmount * this.shake;
            Vector3 temp = this.camera.transform.localPosition;
            temp.z = -20f;
            this.camera.transform.localPosition = temp;

            this.shake -= Time.deltaTime * this.decreaseFactor;

            if (!IsShaking())
            {
                this.shake = 0.0f;
                this.camera.transform.localPosition = this.cameraPos;
            }
        }
	}

    public void Shake(float amount)
    {
        if (!IsShaking())
        {
            this.cameraPos = this.camera.transform.position;
        }

        this.shake = amount;
    }

    private bool IsShaking()
    {
        return shake > 0.0f;
    }
}
