using UnityEngine;
using System.Collections;

public class PlaygroundScript : MonoBehaviour
{
	public GUISkin Skin;
	
    private void OnGUI()
    {
    	GUI.skin = Skin;
		
    	GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        if (GUILayout.Button("Auto deform mesh"))
    	{
    		Application.LoadLevel("AutoDeformMeshScene");
    	}

        if (GUILayout.Button("Bolt"))
    	{
    		Application.LoadLevel("BoltScene");
    	}

        if (!ApplicationHelper.IsMobilePlatform && GUILayout.Button("Cell shading"))
    	{
    		Application.LoadLevel("CellShadingScene");
    	}

        if (GUILayout.Button("Fireball"))
    	{
    		Application.LoadLevel("FireballScene");
    	}

        if (GUILayout.Button("Mesh deformation"))
    	{
    		Application.LoadLevel("MeshDeformationScene");
    	}

        if (GUILayout.Button("Morph"))
    	{
    		Application.LoadLevel("MorphScene");
    	}

        if (GUILayout.Button("Neon"))
    	{
    	    Application.LoadLevel("NeonScene");
    	}

        if (ApplicationHelper.IsDesktoPlatform && GUILayout.Button("Quit"))
    	{
    		Application.Quit();
    	}
		
        GUILayout.EndArea();
    }    
}
