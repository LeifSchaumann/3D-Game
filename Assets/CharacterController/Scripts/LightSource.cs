using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightSource : MonoBehaviour
{
    public Material affectedMaterial;

    void Update()
    {
        affectedMaterial.SetVector("_Light_Position", transform.position);
    }
}
