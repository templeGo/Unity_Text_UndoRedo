using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    public delegate void UndoAction();
    public delegate void RedoAction();

    private UndoAction UndoCommand;
    private RedoAction RedoCommand;

    public Command(UndoAction undo, RedoAction redo)
    {
        UndoCommand = undo;
        RedoCommand = redo;
    }

    public void Undo()
    {
        UndoCommand.Invoke();
    }

    public void Redo()
    {
        RedoCommand.Invoke();
    }
}
