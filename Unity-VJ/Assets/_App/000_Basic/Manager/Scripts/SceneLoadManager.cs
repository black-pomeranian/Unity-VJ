using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private SceneLoader sceneLoader;

    void Start()
    {
        // CurrentMaskIndex�̒l���Ď����A�ω�����OnIndexChanged���Ăяo��
        parameterManager.CurrentSceneIndex
            .Skip(1)
            .Subscribe(newValue =>
            {
                Debug.Log($"Scene Index Changed: {newValue}");
                OnIndexChanged(newValue); // �l���ς�����ۂɏ����𕪊�
            })
            .AddTo(this); // GameObject���j�����ꂽ�ۂɎ����ōw�ǉ���
    }


    private void OnIndexChanged(int newIndex)
    {
        // newIndex�̒l�ɉ����ď����𕪊�
        switch (newIndex)
        {
            case 0:
                sceneLoader.LoadScene(newIndex);
                break;
            case 1:
                sceneLoader.LoadScene(newIndex);
                break;
            case 2:
                sceneLoader.LoadScene(newIndex);
                // Action C �̏���
                break;
            default:
                Debug.Log($"Scene Index is {newIndex}: Default Action");
                // �f�t�H���g�̏���
                break;
        }
    }
}
