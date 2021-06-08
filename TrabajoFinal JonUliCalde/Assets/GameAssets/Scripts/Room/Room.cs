using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Room
{
    public string roomName;
    public Text roomNameText;

    public void UpdateDisplayData()//Updates the name of the room 
    {
        roomNameText.text = "Current room: " + roomName;
    }

}
