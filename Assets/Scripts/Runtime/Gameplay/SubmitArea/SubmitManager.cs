using System.Linq;
using UnityEngine;

public class SubmitManager : MonoBehaviour
{
    [SerializeField] SubmitBlock[] submitBlocks;

    public bool HasEmptyBlock()
    {
        return submitBlocks.Count(sb => sb.IsEmpty) > 0;
    }

    public SubmitBlock GetFirstEmptyBlock()
    {
        return submitBlocks.FirstOrDefault(sb => sb.IsEmpty);
    }
}