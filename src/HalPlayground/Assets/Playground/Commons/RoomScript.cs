using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            SendMessage("CreateFireball");
        }

        if (Input.GetKeyUp(KeyCode.F2))
        {
            SendMessage("SwapCameras");
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height - 65, 200, 65));

        if (GUILayout.Button("Create fireball"))
        {
            SendMessage("CreateFireball");
        }

        if (GUILayout.Button("Swap cameras"))
        {
            SendMessage("SwapCameras");
        }

        GUILayout.EndArea();
    }        
}
