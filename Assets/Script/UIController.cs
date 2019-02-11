using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField]
    private InputField m_InputField;

    [SerializeField]
    private InputManager m_InputManager;

    [SerializeField]
    private StackController m_StackController;

    private string prevText;

    private void OnEnable()
    {
        m_InputManager.RecordEvent += RecordText;
        m_InputManager.UndoEvent += UndoText;
        m_InputManager.RedoEvent += RedoText;
    }
    private void OnDisable()
    {
        m_InputManager.RecordEvent -= RecordText;
        m_InputManager.UndoEvent -= UndoText;
        m_InputManager.RedoEvent -= RedoText;
    }

    // Start is called before the first frame update
    void Start()
    {
        prevText = m_InputField.text;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecordText()
    {
        var oldText = prevText;
        var lastText = m_InputField.text;
        var command = new Command(() => { m_InputField.text = oldText; }, () => { m_InputField.text = lastText; });
        m_StackController.Record(command);
        prevText = m_InputField.text;
    }

    public void UndoText()
    {
        m_StackController.Undo();
        m_StackController.currentCommand.Undo();
        m_InputField.MoveTextEnd(false);
    }

    public void RedoText()
    {
        m_StackController.Redo();
        m_StackController.currentCommand.Redo();
        m_InputField.MoveTextEnd(false);
    }

}
