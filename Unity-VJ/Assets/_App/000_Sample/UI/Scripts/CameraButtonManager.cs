using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CameraButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // 管理するボタンリスト
    [SerializeField] private ParameterManager _parameterManager; // ParameterManager参照

    private int cameraMax;

    [SerializeField] private Color activeColor = Color.green; // アクティブなボタンの色
    [SerializeField] private Color inactiveColor = Color.gray; // 非アクティブなボタンの色

    void Start()
    {
        cameraMax = _parameterManager.cameraMax;

        // ボタンの数をカメラ数に合わせる
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i <= cameraMax)
            {
                // ボタンを有効化してイベントを設定
                buttons[i].gameObject.SetActive(true);
                int index = i; // キャプチャ問題を回避するためにローカル変数を使用
                buttons[index].onClick.AddListener(() =>
                {
                    // ParameterManagerの_currentCameraIndexを設定
                    _parameterManager.SetCameraIndex(index);

                    // ボタンの色を更新
                    UpdateButtonColors(buttons[index]);
                });
            }
        }

        // 初期状態の設定（インデックス0をアクティブにする）
        if (cameraMax > 0)
        {
            UpdateButtonColors(buttons[0]);
        }
    }

    private void UpdateButtonColors(Button activeButton)
    {
        foreach (var button in buttons)
        {
            var buttonImage = button.GetComponent<Image>();
            if (buttonImage != null && button.gameObject.activeSelf)
            {
                buttonImage.color = button == activeButton ? activeColor : inactiveColor;
            }
        }
    }

    private void OnDestroy()
    {
        // リスナーの解除
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
