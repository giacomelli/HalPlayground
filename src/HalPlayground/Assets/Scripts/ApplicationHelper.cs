using UnityEngine;
using System.Collections;

public class ApplicationHelper
{
    #region Propriedades
    public static bool IsWebPlatform
    {
    	get
        {
            return Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer;
        }
    }
	
	public static bool IsDesktoPlatform
	{
		get
		{
			return Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer;
		}
	}
	
	public static bool IsMobilePlatform 
	{
		get 
		{ 
			return Application.platform == RuntimePlatform.IPhonePlayer
				|| Application.platform == RuntimePlatform.Android; 
		}
	}
    #endregion
}
