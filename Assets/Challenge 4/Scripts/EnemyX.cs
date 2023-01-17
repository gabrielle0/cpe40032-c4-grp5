using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX spawnManagerScripts;

    // Start is called before the first frame update
    void Start()
    {
        //Challenge 7: Use Game Object Find to find spawn manager script
        spawnManagerScripts = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        enemyRb = GetComponent<Rigidbody>();
        //Challenge 5: Change game object find to "Player Goal" and change value of speed
        playerGoal = GameObject.Find("Player Goal");

    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        //Challenge 7: Add force to enemies by using the enemy speed in the spawn manager script
        enemyRb.AddForce(lookDirection * spawnManagerScripts.enemySpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
