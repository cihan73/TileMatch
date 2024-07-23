using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "TileStats", menuName = "ScriptableObjects/TileStats")]
public class TileStatsSO : ScriptableObject
{
    public float executeSpeed = 50f;
    public Ease executeEase = Ease.OutSine;
}