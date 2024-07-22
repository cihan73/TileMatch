using System;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup targetGroup;
    [SerializeField] SubmitManager submitManager;
    [SerializeField] Transform tileParent, blockParent;
    [SerializeField] float offset = 20;

    void Awake()
    {
        GameEvents.OnTilesSpawned += Prepare;
    }

    void OnDestroy()
    {
        GameEvents.OnTilesSpawned -= Prepare;
    }

    private void Prepare(Tile[] tiles)
    {
        var count = tiles.Length + submitManager.SubmitBlocks.Length;
        targetGroup.m_Targets = new CinemachineTargetGroup.Target[count];
    }
}