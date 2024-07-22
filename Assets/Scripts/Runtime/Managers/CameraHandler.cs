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

        for (int i = 0; i < tiles.Length; i++)
        {
            targetGroup.m_Targets[i].target = tiles[i].transform;
            targetGroup.m_Targets[i].weight = 1;
        }
        var targetIndex = tiles.Length;
        foreach (var block in submitManager.SubmitBlocks)
        {
            targetGroup.m_Targets[targetIndex].target = block.transform;
            targetGroup.m_Targets[targetIndex].weight = 1;
            targetIndex++;
        }
    }
}