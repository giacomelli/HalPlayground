using UnityEngine;

/// <summary>
/// Fireball toy script.
/// </summary>
public class FireballToyScript : MonoBehaviour
{
    #region Constants
    private const float MinForce = -25;
    private const float MaxForce = 25;
    #endregion
	
	#region Editor properties
    public GameObject Fireball;
	#endregion

	#region Methods
	private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateFireball();
        }
    }

    private void CreateFireball ()
	{
		GameObject fireball = (GameObject)Instantiate (Fireball);
		Camera.main.GetComponent<SmoothLookAt> ().target = fireball.transform;
		
		fireball.rigidbody.AddForce (
            Random.Range (MinForce, MaxForce), 
            Random.Range (MinForce, MaxForce),
            Random.Range (MinForce, MaxForce), 
            ForceMode.Impulse);
	}
	#endregion
}