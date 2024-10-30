using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject trophy;

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(trophy);
    }
}
