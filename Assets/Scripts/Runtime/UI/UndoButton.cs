using UnityEngine;
using UnityEngine.UI;
using UniRx;
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
        button.onClick.AddListener(OnClick);
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
        board.TileCommandInvoker.RemoveCommand();
    }

}