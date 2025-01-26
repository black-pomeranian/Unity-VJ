using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private List<GameObject> state1Objects;
    [SerializeField] private List<GameObject> state2Objects;
    [SerializeField] private List<GameObject> state3Objects;
    [SerializeField] private List<GameObject> state4Objects;
    [SerializeField] private List<GameObject> state5Objects;
    [SerializeField] private List<GameObject> state6Objects;
    [SerializeField] private List<GameObject> state7Objects;
    [SerializeField] private List<GameObject> state8Objects;
    [SerializeField] private List<GameObject> state9Objects;
    [SerializeField] private List<GameObject> state10Objects;

    private List<List<GameObject>> stateObjects;
    private void Start()
    {
        // 実行時にリストを生成
        stateObjects = new List<List<GameObject>>
        {
            state1Objects, state2Objects, state3Objects, state4Objects, state5Objects,
            state6Objects, state7Objects, state8Objects, state9Objects, state10Objects
        };
    }

    public void SetState(int index)
    {
        if (index < 0 || index >= stateObjects.Count)
        {
            Debug.LogWarning("Invalid state index: " + index);
            return;
        }

        // すべてのオブジェクトを非アクティブ化
        foreach (var objects in stateObjects)
        {
            DeactivateObjects(objects);
        }

        // 指定のステートのみアクティブ化
        ActivateObjects(stateObjects[index]);
    }

    private void ActivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null) obj.SetActive(true);
        }
    }

    private void DeactivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null) obj.SetActive(false);
        }
    }
}