using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab;

    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent;

    public Tile[] Tiles { get; set; }

    void PrepareTiles()
    {
        var tileCount = 5;
        Tiles = new Tile[tileCount];
        for (int i = 0; i < tileCount; i++)
        {
            Tiles[i] = Instantiate(tilePrefab, tileParent);
        }
    }

}
