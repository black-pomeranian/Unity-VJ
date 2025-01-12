using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private GameObject Sphere;
    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject Cylinder;
    [SerializeField] private GameObject Particle;

    public void SetState1()
    {
        Activate(Sphere);
        Deactivate(Cube);
        Deactivate(Cylinder);
        Deactivate(Particle);
    }

    public void SetState2()
    {
        Deactivate(Sphere);
        Activate(Cube);
        Deactivate(Cylinder);
        Deactivate(Particle);
    }

    public void SetState3()
    {
        Deactivate(Sphere);
        Deactivate(Cube);
        Activate(Cylinder);
        Deactivate(Particle);
    }

    public void SetState4()
    {
        Deactivate(Sphere);
        Deactivate(Cube);
        Activate(Cylinder);
        Activate(Particle);
    }



    public void Activate(GameObject targetObject)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!");
        }
    }

    public void Deactivate(GameObject targetObject)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!");
        }
    }
}
