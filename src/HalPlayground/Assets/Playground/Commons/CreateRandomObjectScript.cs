using UnityEngine;
using System.Collections;

public class CreateRandomObjectScript : MonoBehaviour
{
    #region Propriedades
    public GameObject Object;
    public float MinForce = -25;
    public float MaxForce = 25;
    public string CreateObjectMessage = "Create object";
    #endregion

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            CreateObject();
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height - 65, 200, 65));

        if (GUILayout.Button(CreateObjectMessage))
        {
            CreateObject();
        }

        GUILayout.EndArea();
    }

    private void CreateObject()
    {
        GameObject o = (GameObject)Instantiate(Object);
        o.rigidbody.AddForce(
            Random.Range(MinForce, MaxForce),
            Random.Range(MinForce, MaxForce),
            Random.Range(MinForce, MaxForce),
            ForceMode.Impulse);
    }
}
