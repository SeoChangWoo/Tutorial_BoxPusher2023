using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpeedManager speed;
    public Transform playerTransform;
    public Animator playerAnimator;

    private void Start()
    {
        speed.isBoost = false;
        speed.value = 3;
    }

    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.position = playerTransform.position + Vector3.forward * speed.value * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.forward);
            playerAnimator.Play("walk");
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.position = playerTransform.position + Vector3.left * speed.value * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.left);
            playerAnimator.Play("walk");
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.position = playerTransform.position + Vector3.back * speed.value * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.back);
            playerAnimator.Play("walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position = playerTransform.position + Vector3.right * speed.value * Time.deltaTime;
            playerTransform.LookAt(playerTransform.position + Vector3.right);
            playerAnimator.Play("walk");
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.Play("idle");
        }
        if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D))
        {
            speed.value = 0;
        }
        else
        {
            if(speed.isBoost == true)
            {
                speed.value = 5 ;
            }
            else
            {
                speed.value = 3;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            speed.isBoost = true;
            other.gameObject.SetActive(false);
        }
    }
}
