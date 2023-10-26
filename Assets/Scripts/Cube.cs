using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer rend;

    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            rend.material.color = Color.red;
        }
    }
}
