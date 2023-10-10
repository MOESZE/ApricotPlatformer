using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private Rigidbody rbFloor;

    // Start is called before the first frame update
    void Start()
    {
        rbFloor = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            rbFloor.isKinematic = false;
            rbFloor.useGravity = true;
            Destroy(gameObject, 3);
        }
    }
}
