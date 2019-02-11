using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInputField : InputField
{

    //TODO inputField選択時に全選択になるのを解除しようと思うも、できず(ActiveInputFieldが呼ばれてない)

    private bool Focused = false;

    new public void ActivateInputField()
    {
        Focused = true;
        base.ActivateInputField();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        if (Focused)
        {
            Debug.Log("Focused"+ Focused);
            MoveTextEnd(true);
            Focused = false;
        }
    }
}
