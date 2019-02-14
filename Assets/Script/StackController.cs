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
        CheckStackWeight();
        //Debug.Log("Undocount" + UndoStack.Count + "Redocount" + RedoStack.Count);
    }

    public void Undo()
    {
        if (UndoStack.Count == 0)
            return;
        
        currentCommand = UndoStack.Pop();
        RedoStack.Push(currentCommand);
        //Debug.Log("Undocount" + UndoStack.Count + "Redocount" + RedoStack.Count);
    }

    public void Redo()
    {
        if (RedoStack.Count == 0)
            return;
        
        currentCommand = RedoStack.Pop();
        UndoStack.Push(currentCommand);
        //Debug.Log("Undocount" + UndoStack.Count + "Redocount" + RedoStack.Count);
    }

    /// <summary>
    /// stackに上限をつけて、上限に到達したら古いものから半分削除する
    /// </summary>
    public void CheckStackWeight()
    {
        int max = 40;
        int deleted = (int)(max * 0.5);

        int UndoStackCount = UndoStack.Count;

        if (UndoStackCount < max)
            return;

        Stack<Command> WorkStack = new Stack<Command>();
        for (int i = 0; i < UndoStackCount; i++)
        {
            WorkStack.Push(UndoStack.Pop());
        }

        for (int i = 0; i < UndoStackCount; i++)
        {
            if(i < deleted)
            {
                WorkStack.Pop();
            }
            else
            {
                UndoStack.Push(WorkStack.Pop());
            }
           
        }
        System.GC.Collect();
    }
}
