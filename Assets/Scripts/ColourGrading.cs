using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGrading : MonoBehaviour
{
    //The material used for colour grading
    [SerializeField] private Material gradingMat;

    //grades the colours
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, gradingMat);
    }
}
