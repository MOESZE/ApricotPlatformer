using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject, 4);
        }
    }
}
