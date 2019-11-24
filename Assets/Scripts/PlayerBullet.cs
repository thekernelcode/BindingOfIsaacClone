using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed = 7.5f;

    public int bulletDamage = 50;

    public Rigidbody2D theRb;

    public GameObject impactEffectForBullet;

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

    // Check for enemy entering our trigger collider
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Instantiate(impactEffectForBullet, transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (otherCollider.tag == "Enemy")
        {
            otherCollider.GetComponent<EnemyController>().DamageEnemy(bulletDamage);
        }
    }

    // If disappears from camera view
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
