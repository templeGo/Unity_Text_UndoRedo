using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    private Stack<Command> UndoStack = new Stack<Command>();
    private Stack<Command> RedoStack = new Stack<Command>();

    public void Record(Command command)
    {
        UndoStack.Push(command);
        Debug.Log("count" + UndoStack.Count);
    }

    public void Undo()
    {

    }

    public void Redo()
    {

    }
}
