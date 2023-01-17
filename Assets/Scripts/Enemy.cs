using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRb;
    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        //Get component rigid body and find game object player
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Get the vector of the distance between the player and the enemy
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        //Destroy game objects that fall off the island
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
