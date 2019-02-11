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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Backspace))
        {
            RecordEvent();
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            UndoEvent();
        }
    }
}
