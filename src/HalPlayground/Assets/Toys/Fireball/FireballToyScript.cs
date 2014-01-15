using UnityEngine;
using System.Collections;

public class FireballToyScript : MonoBehaviour
{
    #region Constantes
    private const float MinForce = -25;
    private const float MaxForce = 25;
    #endregion

    public GameObject Fireball;

    
	private void Start () 
    {
	    
	}

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateFireball();
        }
    }

    private void CreateFireball()
    {
        GameObject fireball = (GameObject) Instantiate(Fireball);
        fireball.rigidbody.AddForce(
            Random.Range(MinForce, MaxForce), 
            Random.Range(MinForce, MaxForce),
            Random.Range(MinForce, MaxForce), 
            ForceMode.Impulse);
    }

}
