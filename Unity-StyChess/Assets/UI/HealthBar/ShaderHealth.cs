using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderHealth : MonoBehaviour
{
    [SerializeField] private Material mat;

    void OnAwake()
    {
        this.GetComponent<Renderer>().material = mat;
    }
}
