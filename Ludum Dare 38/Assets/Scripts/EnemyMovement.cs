using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float movementSpeed;

    // Target to move towards 
    public GameObject target;

    private Rigidbody2D enemyRigidBody;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("World");
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }


    private void Awake()
    { 
        // Rotate in direction of target.
        Vector2 moveDirection = (target.transform.position - this.transform.position).normalized;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }

    // Update is called once per frame
    void Update () {

        // Move in the direction of the target
        Vector2 offset = target.transform.position - transform.position;
        Vector2 direction = offset.normalized;

        enemyRigidBody.velocity = movementSpeed * direction;
	}

    public void SetSpeed(float value)
    {
        movementSpeed = value;
    }
}
