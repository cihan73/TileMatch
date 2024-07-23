using System.Collections.Generic;

public class TileCommandInvoker
{
    readonly Stack<ITileCommand> _commands = new();

    public void AddCommand(ITileCommand command, SubmitBlock block)
    {
        command.Execute(block);
        _commands.Push(command);
    }

    public void RemoveCommand()
    {
        if (_commands.Count <= 0) return;

        var command = _commands.Pop();
        command.Undo();
    }

    public bool HasCommand()
    {
        return _commands.Count > 0;
    }
}