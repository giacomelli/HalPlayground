using UnityEngine;
using System.Collections;

public class BackScript : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 30, 100, 30), "Back"))
        {
            Application.LoadLevel("PlaygroundScene");
        }
    }
}
