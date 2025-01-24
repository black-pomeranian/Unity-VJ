using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // 管理するボタンリスト
    [SerializeField] private Color activeColor = Color.green; // ON の色
    [SerializeField] private Color inactiveColor = Color.gray; // OFF の色

    private Dictionary<Button, bool> buttonStates = new Dictionary<Button, bool>();

    void Start()
    {
        foreach (var button in buttons)
        {
            buttonStates[button] = false; // 初期状態はすべてOFF
            button.onClick.AddListener(() => ToggleButton(button));
            UpdateButtonColor(button);
        }
    }

    private void ToggleButton(Button button)
    {
        buttonStates[button] = !buttonStates[button]; // 状態をトグル
        UpdateButtonColor(button);
    }

    private void UpdateButtonColor(Button button)
    {
        var buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = buttonStates[button] ? activeColor : inactiveColor;
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
