using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // 管理するボタンリスト
    [SerializeField] private Color activeColor = Color.green; // アクティブなボタンの色
    [SerializeField] private Color inactiveColor = Color.gray; // 非アクティブなボタンの色

    void Start()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }

        // 初期状態の設定
        UpdateButtonColors(buttons[0]);
    }

    private void OnButtonClicked(Button clickedButton)
    {
        UpdateButtonColors(clickedButton);
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
