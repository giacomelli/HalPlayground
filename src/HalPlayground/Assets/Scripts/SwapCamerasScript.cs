#region Usings
using UnityEngine;
#endregion

/// <summary>
/// Realiza o swap (troca) entre duas c�meras.
/// <remarks>
/// Controla automaticamente a altera��o de tamanho e profundidade entre as c�meras.
/// </remarks>
/// </summary>
public class SwapCamerasScript : MonoBehaviour
{
    #region Campos
    private float m_firstCameraDepth;
    private Rect m_firstCameraRect;
    private Transform m_firstCameraTransform;

    private float m_secondCameraDepth;
    private Rect m_secondCameraRect;
    private Transform m_secondCameraTransform;
    #endregion

    #region Propriedades
    public Camera FirstCamera;
    public Camera SecondCamera;
    #endregion

    #region M�todos
    private void Start () 
    {
        m_firstCameraDepth = FirstCamera.depth;
        m_firstCameraRect = FirstCamera.rect;
        m_firstCameraTransform = FirstCamera.transform;

        m_secondCameraDepth = SecondCamera.depth;
        m_secondCameraRect = SecondCamera.rect;
        m_secondCameraTransform = SecondCamera.transform;
	}

    private void SwapCameras()
    {
        FirstCamera.depth = m_secondCameraDepth;
        FirstCamera.rect = m_secondCameraRect;
        FirstCamera.transform.position = m_secondCameraTransform.position;
        FirstCamera.transform.rotation = m_secondCameraTransform.rotation;
        FirstCamera.transform.localScale = m_secondCameraTransform.localScale;

        SecondCamera.depth = m_firstCameraDepth;
        SecondCamera.rect = m_firstCameraRect;
        SecondCamera.transform.position = m_firstCameraTransform.position;
        SecondCamera.transform.rotation = m_firstCameraTransform.rotation;
        SecondCamera.transform.localScale = m_firstCameraTransform.localScale;

        Camera swapping = FirstCamera;
        FirstCamera = SecondCamera;
        SecondCamera = swapping;
    }
    #endregion
}
