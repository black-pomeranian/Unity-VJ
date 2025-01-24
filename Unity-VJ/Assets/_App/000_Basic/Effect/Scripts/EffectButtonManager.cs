using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // 管理するボタンリスト
    [SerializeField] private ParameterManager _parameterManager;

    [SerializeField] private Color activeColor = Color.green; // ON の色
    [SerializeField] private Color inactiveColor = Color.gray; // OFF の色

    private int effectMax;
    private Dictionary<Button, bool> isColorFlipped = new Dictionary<Button, bool>(); // 各ボタンの反転状態を管理

    void Start()
    {
        effectMax = _parameterManager.effectMax;

        // ボタンごとにリスナーを設定
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < effectMax)
            {
                int index = i; // キャプチャ問題を回避するためにローカル変数を使用
                isColorFlipped[buttons[index]] = false; // 初期状態を設定
                buttons[index].onClick.AddListener(() =>
                {
                    Debug.Log(index);
                    // ParameterManagerの_currentCameraIndexを設定
                    _parameterManager.ToggleEffectState(index);

                    // ボタンの色を更新
                    UpdateButtonColor(buttons[index]);
                });
            }
        }
    }

    private void UpdateButtonColor(Button button)
    {
        var buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            // 現在の反転状態に応じて色を設定
            buttonImage.color = isColorFlipped[button] ? inactiveColor : activeColor;
            // 次回呼び出し時に反転させる
            isColorFlipped[button] = !isColorFlipped[button];
        }
    }

    private void OnDestroy()
    {
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
