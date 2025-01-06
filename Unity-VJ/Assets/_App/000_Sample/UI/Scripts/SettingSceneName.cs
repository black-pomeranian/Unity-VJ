using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro���g�p���邽�߂̖��O���

public class SettingSceneName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sceneNameText; // TextMeshPro��UI�v�f���Q��

    void Start()
    {
        // ���݂̃V�[�������擾
        string sceneName = SceneManager.GetActiveScene().name;

        // TextMeshPro�ɃV�[�����𔽉f
        sceneNameText.text = "Scene: " + sceneName;
    }
}
