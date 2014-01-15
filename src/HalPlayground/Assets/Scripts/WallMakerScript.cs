#region Usings
using UnityEngine;
using System.Collections;
#endregion

[RequireComponent(typeof(CombineChildren))]
public class WallMakerScript : MonoBehaviour
{
    #region Propriedades
    public GameObject Brick;
    public int XBricks;
    public int YBricks;
    public int ZBricks;
    public Vector3 DirectionModifier = new Vector3(1, 1, 1);
    public float SleepSecondsBetweenBrickCreation = 0;
    #endregion

    /// <summary>
    /// Chamado apenas uma vez durante o ciclo de vida do script, isso acontece antes de qualquer método de Update ser chamado.
    /// <remarks>
    /// Não é chamado até a instância do script estar habilitada, além disso é chamado somente após todos os métodos Awake 
    /// em todas as instâncias do script serem chamados.
    /// </remarks>
    /// </summary>
    private void Start()
    {
        StartCoroutine(MakeWall(XBricks, YBricks, ZBricks, transform.position, DirectionModifier));
    }

    #region Utilitários
    /// <summary>
    /// Constrói uma parede.
    /// </summary>
    /// <param name="xBricks">Quantidade de tijolos no eixo x.</param>
    /// <param name="yBricks">Quantidade de tijolos no eixo y.</param>
    /// <param name="zBricks">Quantidade de tijolos no eixo z.</param>
    /// <param name="initialPosition">A posição inicial da parede.</param>
    /// <param name="direction">A direção que a parede deve ser construída.</param>
    /// <returns>Utilizado para criar as paredes lentamente.</returns>
    private IEnumerator MakeWall(int xBricks, int yBricks, int zBricks, Vector3 initialPosition, Vector3 direction)
    {
        for (int x = 0; x < xBricks; x++)
        {
            for (int y = 0; y < yBricks; y++)
            {
                for (int z = 0; z < zBricks; z++)
                {
                    Vector3 p = new Vector3(x * direction.x, y * direction.y, z * direction.z);
                    GameObject brick = (GameObject)Instantiate(Brick, initialPosition + p, Quaternion.identity);
                    brick.transform.parent = transform;

                    if (SleepSecondsBetweenBrickCreation > 0)
                    {
                        yield return new WaitForSeconds(SleepSecondsBetweenBrickCreation);
                    }
                    
                }
            }
        }

        yield return new WaitForSeconds(0);
    }
    #endregion  
}
