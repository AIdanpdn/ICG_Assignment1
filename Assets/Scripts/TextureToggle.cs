using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureToggle : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private MeshRenderer renderer;

    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            renderer.material = materials[0];
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            renderer.material = materials[1];
        }

    }
}
