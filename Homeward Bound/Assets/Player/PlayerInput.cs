﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    PlayerBody body;
    Vector3 forward, dir;
    float h, v;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        body = GetComponent<PlayerBody>();
    }

    private void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        forward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up);
        dir = (v * forward + h * cam.transform.right);
        dir = (dir.magnitude > 1f) ? dir.normalized : dir;
        if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f)
        {
            body.Move(dir);
        }

        if (Input.GetButtonDown("Use"))
        {
            body.Use();
        }

        if (Input.GetButtonDown("Interact"))
        {
            body.Interact();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            body.OpenInventory();
        }
    }
}