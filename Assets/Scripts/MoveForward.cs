using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Header("Forward Movement")]
    [Tooltip("How fast to move GameObject Forward.")]
    public float speed = 1.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
