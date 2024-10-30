using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject spawn;

    void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = spawn.transform.position;
    }
}
