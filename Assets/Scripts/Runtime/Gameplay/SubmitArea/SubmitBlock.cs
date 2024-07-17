
using UnityEngine;

public class SubmitBlock : MonoBehaviour
{
    public Tile Tile
    {
        get => _tile;
        set
        {
            if (_tile == value) return;

            _tile = value;

            if (_tile != null)
            {
                _tile.SubmitBlock = this;
                GameEvents.OnTileAttached?.Invoke(this, Character);
            }
            else
            {
                GameEvents.OnTileRemoved?.Invoke(this);
            }
        }
    }
    public string Character => _tile.GetCharacter();
    public bool IsEmpty => Tile == null;
    Tile _tile;
}
