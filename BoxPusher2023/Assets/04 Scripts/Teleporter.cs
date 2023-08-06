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
            characterTransform.position = pointB.position;
            currentPoint = pointB;
        }
        else if (currentPoint == pointB)
        {
            characterTransform.position = pointA.position;
            currentPoint = pointA;
        }
    }
}
