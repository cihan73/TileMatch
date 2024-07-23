using DG.Tweening;
using TMPro;
using UnityEngine;
using static TouchManager;

public class Tile : MonoBehaviour, ITouchable, ITileCommand
{
    [SerializeField] TileStatsSO tileStats;
    [SerializeField] TextMeshPro tmp;
    public SubmitBlock SubmitBlock
    {
        get => _submitBlock;
        set
        {
            if (_submitBlock == value) return;

            _submitBlock = value;

            if (_submitBlock != null)
            {
                _submitBlock.Tile = this;
            }
        }
    }
    private SubmitBlock _submitBlock;
    Vector3 _basePos;
    TileData _tileData;

    public void Prepare(TileData tileData)
    {
        _tileData = tileData;
        gameObject.name = $"Tile_{_tileData.id}_{_tileData.character}";
        SetPosition(_tileData.position);
        SetCharacterText(_tileData.character);
    }

    public void Execute(SubmitBlock submitBlock)
    {
        SubmitBlock = submitBlock;

        DOTween.Kill(transform);

        transform.DOLocalMove(submitBlock.transform.position, tileStats.executeSpeed)
            .SetSpeedBased(true)
            .SetEase(tileStats.executeEase);
    }

    public void Undo()
    {
        DOTween.Kill(transform);

        if (SubmitBlock != null)
        {
            SubmitBlock.Tile = null;
            SubmitBlock = null;
        }

        transform.DOLocalMove(_basePos, tileStats.executeSpeed * 2)
            .SetSpeedBased(true)
            .SetEase(tileStats.executeEase);
    }

    public string GetCharacter()
    {
        return _tileData.character.ToLowerInvariant();
    }

    public int[] GetChildren()
    {
        if (SubmitBlock != null) return null;

        return _tileData.children;
    }

    public int GetID()
    {
        return _tileData.id;
    }

    private void SetPosition(Vector3 newPos)
    {
        transform.position = newPos;
        _basePos = transform.position;
    }

    private void SetCharacterText(string character)
    {
        tmp.text = character;
    }
}