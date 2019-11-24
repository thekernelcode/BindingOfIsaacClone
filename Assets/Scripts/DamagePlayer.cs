using System.Collections;
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

    // Check to see if something has enetered our trigger collider
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }

    // Check to see if something is staying in our trigger collider
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }

    // Check for something without trigger tag has entered our collider
    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }

    // Check for something without trigger tag is staying in our collider
    private void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }
}
