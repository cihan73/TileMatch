using UnityEngine;
using static TouchManager;

public class Tile : MonoBehaviour, ITouchable
{
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
    TileData _tileData;

    public void Prepare(TileData tileData)
    {
        _tileData = tileData;
        gameObject.name = $"Tile_{_tileData.id}_{_tileData.character}";
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
}