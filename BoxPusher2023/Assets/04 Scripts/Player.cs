using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    public Animator playerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerTransform.position = playerTransform.position + Vector3.forward * speed * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.forward);
            playerAnimator.Play("walk");
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.position = playerTransform.position + Vector3.left * speed * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.left);
            playerAnimator.Play("walk");
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.position = playerTransform.position + Vector3.back * speed * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.back);
            playerAnimator.Play("walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position = playerTransform.position + Vector3.right * speed * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.right);
            playerAnimator.Play("walk");
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) 
        {
            playerAnimator.Play("idle");
        }

    }
}
