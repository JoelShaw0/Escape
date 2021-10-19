using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Exit
{
    public string keyString; // looking for when checking for exits (North, West)
    public string exitDescription; // Displays in the action log for displaying to the action log
    public Room valueRoom;
}
