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
        DeactivateObjects(state2Objects);
        DeactivateObjects(state3Objects);
        DeactivateObjects(state4Objects);

        ActivateObjects(state1Objects);

    }

    public void SetState2()
    {
        DeactivateObjects(state1Objects);
        DeactivateObjects(state3Objects);
        DeactivateObjects(state4Objects);

        ActivateObjects(state2Objects);

    }

    public void SetState3()
    {
        DeactivateObjects(state1Objects);
        DeactivateObjects(state2Objects);
        DeactivateObjects(state4Objects);

        ActivateObjects(state3Objects);

    }

    public void SetState4()
    {
        DeactivateObjects(state1Objects);
        DeactivateObjects(state2Objects);
        DeactivateObjects(state3Objects);

        ActivateObjects(state4Objects);

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
