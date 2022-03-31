using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 direction = gameObject.transform.position - Camera.main.transform.position;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }
}
