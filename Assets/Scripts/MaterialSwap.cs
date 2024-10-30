using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private SkinnedMeshRenderer renderer;

    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            renderer.material = materials[0];
            Debug.Log("1");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            renderer.material = materials[1];
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            renderer.material = materials[2];
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            renderer.material = materials[3];
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            renderer.material = materials[4];
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            renderer.material = materials[5];
        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            renderer.material = materials[6];
        }
    }
}
