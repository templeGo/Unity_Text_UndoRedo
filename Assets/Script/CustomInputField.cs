using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomInputField : InputField
{

    private bool Deactivated = true;

    public override void OnDeselect(BaseEventData eventData)
    {
        Deactivated = true;
        DeactivateInputField();
        base.OnDeselect(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (Deactivated)
        {
            MoveTextEnd(true);
            Deactivated = false;
        }
        base.OnPointerClick(eventData);
    }
}
