using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshProを使用するための名前空間

public class SettingSceneName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sceneNameText; // TextMeshProのUI要素を参照

    void Start()
    {
        // 現在のシーン名を取得
        string sceneName = SceneManager.GetActiveScene().name;

        // TextMeshProにシーン名を反映
        sceneNameText.text = "Scene: " + sceneName;
    }
}
