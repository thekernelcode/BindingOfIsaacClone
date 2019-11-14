using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed = 7.5f;

    public Rigidbody2D theRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move to the right relative to this object i.e Move in the direction I'm facing...

        theRb.velocity = transform.right * speed;


    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Destroy(gameObject);
    }
}
