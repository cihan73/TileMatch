using System.Collections;
using System.Linq;
using Cinemachine;
using UnityEngine;

[DefaultExecutionOrder(-999)]
public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup targetGroup;
    [SerializeField] SubmitManager submitManager;
    [SerializeField] Transform tileParent, blockParent;
    [SerializeField] float offset = 20;
    [SerializeField] float offsetWeight = 1;

    void Awake()
    {
        GameEvents.OnTilesSpawned += Prepare;
    }

    IEnumerator Start()
    {
        yield return null;

        blockParent.position = new Vector3(GetMeanTileX(), GetTopTileY() + offset, GetMeanTileZ());

        yield return null;

        targetGroup.enabled = false;
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
            targetGroup.m_Targets[i].weight = offsetWeight;
        }

        var targetIndex = tiles.Length;
        foreach (var block in submitManager.SubmitBlocks)
        {
            targetGroup.m_Targets[targetIndex].target = block.transform;
            targetGroup.m_Targets[targetIndex].weight = offsetWeight;
            targetIndex++;
        }
    }

    float GetTopTileY()
    {
        return tileParent.Cast<Transform>()
            .Aggregate(float.MinValue, (current, child) => Mathf.Max(current, child.position.y));
    }

    float GetMeanTileX()
    {
        var meanX = 0f;

        foreach (Transform tile in tileParent)
        {
            meanX += tile.position.x;
        }

        return meanX / tileParent.childCount;
    }

    float GetMeanTileZ()
    {
        var meanZ = 0f;

        foreach (Transform tile in tileParent)
        {
            meanZ += tile.position.z;
        }

        return meanZ / tileParent.childCount;
    }
}