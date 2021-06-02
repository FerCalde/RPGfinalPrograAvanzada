using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : SingletonTemporal<InfoManager>
{
    Text infoText;
    private void Start()
    {
        infoText = GetComponent<Text>();
    }
    public void InfoChanger(string t)
    {
        infoText.text = t;
    }
}
