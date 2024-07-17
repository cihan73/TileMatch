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
}