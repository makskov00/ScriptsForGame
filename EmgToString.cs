using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class EmgToString : MonoBehaviour
{
    public Text ValueText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int EMGvalue = UduinoManager.Instance.analogRead(AnalogPin.A1);

        ValueText.text = EMGvalue.ToString();

        
        
    }
}
