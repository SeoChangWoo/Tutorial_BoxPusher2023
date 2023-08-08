using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; 
    [SerializeField] private Rigidbody bulletRigidbody;

    public Transform targetTransform;
    public Transform spawnerTransform;

    private void Awake()
    {
        targetTransform = FindObjectOfType<Player>().transform;
        spawnerTransform = FindObjectOfType<BulletSpawner>().transform;
    }
    void Start()
    {
        Vector3 direction = (targetTransform.position - spawnerTransform.position).normalized;
        bulletRigidbody.velocity = direction * speed;
        Destroy(gameObject, 3f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>(); 
            if (player != null)
            {
               //장면재시작
            }
        }
    }
}
