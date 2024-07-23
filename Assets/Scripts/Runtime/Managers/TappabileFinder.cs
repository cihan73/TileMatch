using UnityEngine;

public class TappableFinder : MonoBehaviour
{
    [SerializeField] private Board board;

    private void Update()
    {
        foreach (var tile in board.Tiles)
        {
            tile.UpdateVisual(board.IsVisible(tile));
        }
    }
}