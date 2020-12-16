﻿using UnityEngine;
using System.Collections;

public class NewRobot : MonoBehaviour {
    public float getTo = 6f;
    public bool work = true;
    public float sideForce = 15f;

    public string moveTo;
    public float distance = 1f;

    public bool debug = false;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (work == true) {
            rigidbody2D.AddForce (new Vector2 (sideForce, 0));

            if (transform.position.x == getTo | transform.position.x >= getTo) {
                transform.position = new Vector3(-getTo, transform.position.y, transform.position.z);
                Vector3 v = rigidbody2D.velocity;
                v.x = 0.0f;
                v.y = 0.0f;
                rigidbody2D.velocity = v;
            }

            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, distance, layerMask);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, distance, layerMask);
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.up, distance, layerMask);
            RaycastHit2D hit4 = Physics2D.Raycast(transform.position, -Vector2.up, distance, layerMask);

            if (hit.collider != null | hit2.collider != null | hit3.collider != null | hit4.collider != null) {
                Application.LoadLevel(moveTo);

                if (debug == true) {
                    Debug.Log("It found!");
                }
            }
        }
    }
}
