
using System;
using Cysharp.Threading.Tasks.Triggers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] private WordManager wordManager;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnClickCallback);

        ObserveWord();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnClickCallback);
    }

    private void ObserveWord()
    {
        gameObject.ObserveEveryValueChanged(_ => wordManager.IsCurrentWordValid())
            .Subscribe(isWordValid =>
            {
                button.interactable = isWordValid;
            }).AddTo(gameObject);
    }

    private void OnClickCallback()
    {
        wordManager.Submit();
    }
}
