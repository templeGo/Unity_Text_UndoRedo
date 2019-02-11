using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void RecordEventHandler();
    public delegate void UndoEventHandler();
    public delegate void RedoEventHandler();

    public RecordEventHandler RecordEvent;
    public UndoEventHandler UndoEvent;
    public RedoEventHandler RedoEvent;

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Backspace))
        {
            if(RecordEvent != null)
                RecordEvent();
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
        {
            if (RedoEvent != null)
                RedoEvent();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            if (UndoEvent != null)
                UndoEvent();
        }
    }
}
