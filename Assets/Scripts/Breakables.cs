using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{

    public GameObject[] brokenPieces;
    public int maxPieces = 5;

    public bool shouldDropItem;
    public GameObject[] itemsToDrop;
    public float itemDropChance;

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
            if (PlayerController.instance.dashCounter > 0)
            {
                Destroy(gameObject);

                // Show broken pieces of breakable
                int piecesToDrop = Random.Range(1, maxPieces);

                for (int i = 0; i < piecesToDrop; i++)
                {
                    int randomPiece = Random.Range(0, brokenPieces.Length);
                    Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
                }

                // Drop Items
                if (shouldDropItem == true)
                {
                    float dropChance = Random.Range(0, 100f);
                    if (dropChance < itemDropChance)
                    {
                        int randomDrop = Random.Range(0, itemsToDrop.Length);
                        Instantiate(itemsToDrop[randomDrop], transform.position, transform.rotation);
                    }
                }

            }

            
        }   
    }
}
