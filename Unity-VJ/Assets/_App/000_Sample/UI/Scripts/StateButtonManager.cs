using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class StateButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // 管理するボタンリスト
    [SerializeField] private StateManager _stateManager;

    [SerializeField] private Color activeColor = Color.green; // アクティブなボタンの色
    [SerializeField] private Color inactiveColor = Color.gray; // 非アクティブなボタンの色

    void Start()
    {


        // 初期状態の設定
        UpdateButtonColors(buttons[0]);

        _stateManager.CurrentStateIndex
            .Subscribe(x => UpdateButtonColors(buttons[x]))
            .AddTo(this);
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
