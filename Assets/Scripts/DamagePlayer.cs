﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }
    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }
    private void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }
}
