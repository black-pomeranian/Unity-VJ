using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{

    [SerializeField] Material greenSkyBox;
    [SerializeField] Material greenMaterial;
    [SerializeField] GameObject maskedObject1;

    private Material defaultSkyBox;

    private MeshRenderer defaultRenderer1;
    private Material defaultMaterial1;

    // Start is called before the first frame update
    void Start()
    {
        defaultSkyBox = RenderSettings.skybox;

        defaultRenderer1 = maskedObject1.GetComponent<MeshRenderer>();
        defaultMaterial1 = defaultRenderer1.material;
    }

    public void SetMask1()
    {
        RenderSettings.skybox = defaultSkyBox;
        defaultRenderer1.material = defaultMaterial1;
    }

    public void SetMask2()
    {
        RenderSettings.skybox = defaultSkyBox;
        defaultRenderer1.material = greenMaterial;
    }

    public void SetMask3()
    {
        RenderSettings.skybox = greenSkyBox;
        defaultRenderer1.material = defaultMaterial1;
    }
}
