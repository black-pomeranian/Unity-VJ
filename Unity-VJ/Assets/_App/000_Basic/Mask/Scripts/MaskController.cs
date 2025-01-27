using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    [SerializeField] Material greenSkyBox;
    [SerializeField] Material renderMaterial;
    [SerializeField] private List<GameObject> maskedObjects;

    private List<Material> defaultMaterials = new List<Material>();
    private Material defaultSkyBox;

    void Start()
    {
        // デフォルトのスカイボックスを保存
        defaultSkyBox = RenderSettings.skybox;

        // 各オブジェクトのデフォルトマテリアルをリストに格納
        foreach (GameObject obj in maskedObjects)
        {
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                defaultMaterials.Add(renderer.material);
            }
        }
    }

    public void SetMask1()
    {
        RenderSettings.skybox = defaultSkyBox;
        ApplyDefaultMaterials();
    }

    public void SetMask2()
    {
        RenderSettings.skybox = defaultSkyBox;
        ApplyMaterialToAll(renderMaterial);
    }

    public void SetMask3()
    {
        RenderSettings.skybox = greenSkyBox;
        ApplyDefaultMaterials();
    }

    private void ApplyDefaultMaterials()
    {
        for (int i = 0; i < maskedObjects.Count; i++)
        {
            MeshRenderer renderer = maskedObjects[i].GetComponent<MeshRenderer>();
            if (renderer != null && i < defaultMaterials.Count)
            {
                renderer.material = defaultMaterials[i];
            }
        }
    }

    private void ApplyMaterialToAll(Material material)
    {
        foreach (GameObject obj in maskedObjects)
        {
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
        }
    }
}
