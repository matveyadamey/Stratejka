using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TestMove : NetworkBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    void Update()
    {
        if (!isLocalPlayer) return;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
    }
}
