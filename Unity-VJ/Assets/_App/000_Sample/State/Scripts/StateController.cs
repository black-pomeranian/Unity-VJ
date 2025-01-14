using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private List<GameObject> state1Objects;
    [SerializeField] private List<GameObject> state2Objects;
    [SerializeField] private List<GameObject> state3Objects;
    [SerializeField] private List<GameObject> state4Objects;

    public void SetState1()
    {
        ActivateObjects(state1Objects);
        DeactivateObjects(state2Objects);
        DeactivateObjects(state3Objects);
        DeactivateObjects(state4Objects);
    }

    public void SetState2()
    {
        ActivateObjects(state2Objects);
        DeactivateObjects(state1Objects);
        DeactivateObjects(state3Objects);
        DeactivateObjects(state4Objects);
    }

    public void SetState3()
    {
        ActivateObjects(state3Objects);
        DeactivateObjects(state1Objects);
        DeactivateObjects(state2Objects);
        DeactivateObjects(state4Objects);
    }

    public void SetState4()
    {
        ActivateObjects(state4Objects);
        DeactivateObjects(state1Objects);
        DeactivateObjects(state2Objects);
        DeactivateObjects(state3Objects);
    }

    private void ActivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    private void DeactivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
