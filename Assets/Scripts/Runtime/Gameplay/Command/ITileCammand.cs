public interface ITileCommand
{
    void Execute(SubmitBlock submitBlock);
    void Undo();
}