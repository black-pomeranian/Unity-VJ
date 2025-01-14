using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // 管理するボタンリスト
    [SerializeField] private ParameterManager _parameterManager;

    private int maskMax;

    [SerializeField] private Color activeColor = Color.green; // アクティブなボタンの色
    [SerializeField] private Color inactiveColor = Color.gray; // 非アクティブなボタンの色

    void Start()
    {
        maskMax = _parameterManager.maskMax;


        // ボタンごとにリスナーを設定
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < maskMax)
            {
                int index = i; // キャプチャ問題を回避するためにローカル変数を使用
                buttons[index].onClick.AddListener(() =>
                {
                    Debug.Log(index);
                    // ParameterManagerの_currentCameraIndexを設定
                    _parameterManager.SetMaskIndex(index);

                    // ボタンの色を更新
                    UpdateButtonColors(buttons[index]);
                });
            }

        }

        // 初期状態の設定（インデックス0をアクティブにする）
        UpdateButtonColors(buttons[0]);
    }

    private void UpdateButtonColors(Button activeButton)
    {
        foreach (var button in buttons)
        {
            var buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
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
