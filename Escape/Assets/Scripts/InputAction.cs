using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class does nothing currently
public abstract class InputAction : ScriptableObject
{
    public string keyWord;

    public abstract void RespondToInput(GameController controller, string[] seperatedInputWords);
}
