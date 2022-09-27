using System.Collections.Generic;

public class CommandHandler
{
    private Stack<ICommand> _commandsList = new Stack<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commandsList.Push(command); 
        command.Execute();
    }

    public void UndoCommand()
    {
        if (_commandsList.Count > 0)
        {
            ICommand latestCommand = _commandsList.Pop();
            latestCommand.Undo();
        }
    }
}
