using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float maxRate = 3f; //maximum bullet generation cycle
    public float minRate = 0.5f; //Minimum bullet generation cycle

    private float rate; // bullet generation cycle
    private Transform target; //player's position
    private float timeAfterSpawn; // last time since bullet creation
    // Start is called before the first frame update
    void Start()
    {
        rate = Random.Range(minRate, maxRate);
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime is the time interval between the execution of the previous update() and the execution of the current update()
        // By accumulating time intervals, you can express how much time has passed at a specific point in time.
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn > rate)
        {
            timeAfterSpawn = 0f;
            rate = Random.Range(minRate, maxRate);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target); // Make the bullet's forward direction (z-axis direction) face the target
        }
    }
}
