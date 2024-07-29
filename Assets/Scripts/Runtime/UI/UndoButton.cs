using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UndoButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Board board;

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        ObserveCommand();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnClick);
    }

    private void ObserveCommand()
    {
        gameObject.ObserveEveryValueChanged(_ => board.TileCommandInvoker.HasCommand())
            .Subscribe(hasCommand =>
            {
                button.interactable = hasCommand;
            }).AddTo(gameObject);
    }

    private void OnClick()
    {
        AudioManager.Instance.PlaySound("Click");
        board.TileCommandInvoker.RemoveCommand();
    }

}