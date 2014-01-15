#region Usings
using System;
using UnityEngine;
#endregion

/// <summary>
/// Cria um raio que sai do GameObject associado e atingi o alvo configurado na propriedade Target.
/// </summary>
public class BoltScript : MonoBehaviour
{
    #region Campos
    private Particle[] m_particles;
    private Light[] m_lights;
    private int m_lightsNumber;
    private int m_lightsEveryParticles;
    private PerlinScript m_noise;
    private float m_oneOverZigs;
    #endregion

    #region Propriedades
    public Transform Target;
    public int Zigs = 100;
    public float Speed = 1f;
    public float Scale = 1f;
    public Light Light;
    public float LightsPartilesPercent = 0.1f;
    #endregion

    #region Métodos
    private void Start()
    {
        m_oneOverZigs = 1f / (float)Zigs;
        particleEmitter.emit = false;

        particleEmitter.Emit(Zigs);
        m_particles = particleEmitter.particles;

        // Cria as luzes necessárias para iluminar o raio.
        m_lightsNumber = Convert.ToInt32(m_particles.Length * LightsPartilesPercent);
        m_lightsEveryParticles = Convert.ToInt32(LightsPartilesPercent * 100);

        m_lights = new Light[m_lightsNumber];

        for (int i = 0; i < m_lightsNumber; i++)
        {
            Light boltLight = (Light) Instantiate(Light, Vector3.zero, Quaternion.identity);
            boltLight.transform.parent = transform;
            m_lights[i] = boltLight;
        }
    }

    private void Update()
    {        
        if (m_noise == null)
        {
            m_noise = new PerlinScript();
        }

        float timex = Time.time * Speed * 0.1365143f;
        float timey = Time.time * Speed * 1.21688f;
        float timez = Time.time * Speed * 2.5564f;
        
        for (int i = 0; i < m_particles.Length; i++)
        {
            Vector3 position = Vector3.Lerp(transform.position, Target.position, m_oneOverZigs * (float)i);
            Vector3 offset = new Vector3(m_noise.Noise(timex + position.x, timex + position.y, timex + position.z),
                                        m_noise.Noise(timey + position.x, timey + position.y, timey + position.z),
                                        m_noise.Noise(timez + position.x, timez + position.y, timez + position.z));

            position += (offset * Scale * ((float)i * m_oneOverZigs));

            m_particles[i].position = position;
            m_particles[i].color = Color.white;
            m_particles[i].energy = 1f;
        }

        particleEmitter.particles = m_particles;

        // Reposiciona as luzes conforme as partículas correspondentes.
        for (int i = 0; i < m_lightsNumber; i++)
        {
            m_lights[i].transform.position = m_particles[i * m_lightsEveryParticles].position;
        }
    }
    #endregion
}
