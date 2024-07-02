using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TouchManager;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab;
    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent;

    public Tile[] Tiles { get; private set; }

    private void Awake()
    {
        TouchEvents.OnElementTapped -= TileTapped;
        PrepareTiles();
    }

    private void OnDestroy()
    {
        TouchEvents.OnElementTapped -= TileTapped;
    }
    void PrepareTiles()
    {
        var tileCount = 5;
        Tiles = new Tile[5]; // todo: change with level tile amount

        for (int i = 0; i < tileCount; i++)
        {
            Tiles[i] = Instantiate(tilePrefab, tileParent);
        }
    }

    void TileTapped(ITouchable touchable)
    {
        var tappedTile = touchable.gameObject.GetComponent<Tile>();
    }
    // birþeyi birden fazla proje de kullanmak için 
}