using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    private Stack<Command> UndoStack = new Stack<Command>();
    private Stack<Command> RedoStack = new Stack<Command>();

    public Command currentCommand { get; private set; }

    public void Record(Command command)
    {
        UndoStack.Push(command);
        RedoStack.Clear();
        Debug.Log("Undocount" + UndoStack.Count + "Redocount" + RedoStack.Count);
    }

    public void Undo()
    {
        if (UndoStack.Count == 0)
        {
            return;
        }
        currentCommand = UndoStack.Pop();
        RedoStack.Push(currentCommand);
        Debug.Log("Undocount" + UndoStack.Count + "Redocount" + RedoStack.Count);
    }

    public void Redo()
    {
        if (RedoStack.Count == 0)
        {
            return;
        }
        currentCommand = RedoStack.Pop();
        UndoStack.Push(currentCommand);
        Debug.Log("Undocount" + UndoStack.Count + "Redocount" + RedoStack.Count);
    }
}
