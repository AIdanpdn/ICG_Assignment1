using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform lerpPoint1;
    [SerializeField] private Transform lerpPoint2;
    private Vector3 goToPos;

    public float lerpSpeed;

    bool lerped = false;
    float time = 0;


    // Start is called before the first frame update
    void Start()
    {
        goToPos = lerpPoint2.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, goToPos, time);
        time += Time.deltaTime * lerpSpeed;


        if (transform.position == goToPos && lerped)
        {
            Debug.Log("Lerp1");
            goToPos = lerpPoint2.position;
            lerped = false;
            time = 0;
        }

        if (transform.position == goToPos && !lerped)
        {
            Debug.Log("Lerp2");
            goToPos = lerpPoint1.position; 
            lerped = true;
            time = 0;
        }
    }
}
