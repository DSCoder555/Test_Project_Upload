using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image buttonColor;
    public Button button;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        //myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(keyToPress))
        {
            //myColor = new Color(myColor[0], myColor[1], myColor[2], pressedCol);
            //myRenderer.material.color = myColor;

            //buttonColor = pressedColor;
            buttonColor.color = button.colors.pressedColor;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            //myColor = new Color(myColor[0], myColor[1], myColor[2], defaultCol);
            //myRenderer.material.color = myColor;

            //buttonColor = defaultColor;
            buttonColor.color = button.colors.normalColor;
        }
    }

    public void buttonClicked()
    {
        Debug.Log("Clicked");
    }
}
