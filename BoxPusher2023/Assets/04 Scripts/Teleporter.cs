using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Transform currentPoint;
    private void Start()
    {
        currentPoint = pointA;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportCharacter(other.transform);
        }
    }
    private void TeleportCharacter(Transform characterTransform)
    {
        if (currentPoint == pointA)
        {
            Debug.Log("A");
            characterTransform.position = pointB.position;
            currentPoint = pointB;
        }
        else if (currentPoint == pointB)
        {
            Debug.Log("B");
            characterTransform.position = pointA.position;
            currentPoint = pointA;
        }
    }
}
