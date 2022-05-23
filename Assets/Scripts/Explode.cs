using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float explosionForce = 2.0f;
    public float explosionRadius = 2.0f;

    private void Awake()
    {
        ExplodeObjects();
    }

    public void ExplodeObjects()
    {
        ExplodingObjects[] objects = FindObjectsOfType<ExplodingObjects>();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects.Length != 0)
            {
                objects[i].GetComponent<Rigidbody>().
                    AddExplosionForce(explosionForce, transform.position, explosionRadius,
                    1.0f, ForceMode.Impulse);
            }
        }
    }
}
