using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForward : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(1.5f, 0.0f, 0.0f));
    }
}
