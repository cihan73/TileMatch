using System;

public static class GameEvents
{
    public static Action<SubmitBlock, string> OnTileAttached;
    public static Action<SubmitBlock> OnTileRemoved;
}