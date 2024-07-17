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
                // tile attached
            }
            else
            {
                // tile removed
            }
        }
    }
    Tile _tile;
}