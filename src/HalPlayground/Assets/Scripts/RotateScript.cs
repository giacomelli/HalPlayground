#region Usings
using UnityEngine;
using System.Collections;
#endregion

public class RotateScript : MonoBehaviour
{
    #region Propriedades
    public Vector3 Rotation;
    #endregion

    #region Métodos
    /// <summary>
    /// Chamado a cada frame, se a instância do script está habilitada.
    /// <remarks>
    /// Esse método é normalmente utilizado para implementar qualquer tipo de comportamento do jogo.
    /// </remarks>
    /// </summary>
    private void Update()
    {        
        transform.Rotate(Rotation);
    }
    #endregion
}
