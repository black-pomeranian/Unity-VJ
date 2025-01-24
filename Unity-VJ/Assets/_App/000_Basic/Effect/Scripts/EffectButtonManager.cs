using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // �Ǘ�����{�^�����X�g
    [SerializeField] private Color activeColor = Color.green; // ON �̐F
    [SerializeField] private Color inactiveColor = Color.gray; // OFF �̐F

    private Dictionary<Button, bool> buttonStates = new Dictionary<Button, bool>();

    void Start()
    {
        foreach (var button in buttons)
        {
            buttonStates[button] = false; // ������Ԃ͂��ׂ�OFF
            button.onClick.AddListener(() => ToggleButton(button));
            UpdateButtonColor(button);
        }
    }

    private void ToggleButton(Button button)
    {
        buttonStates[button] = !buttonStates[button]; // ��Ԃ��g�O��
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
