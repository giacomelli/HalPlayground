using UnityEngine;
using System.Collections;

public class MeshDeformationToyScript : MonoBehaviour
{
    #region Enumerações
    public enum FallOffType
    {
        Gauss,
        Linear,
        Needle
    }
    #endregion

    #region Campos
    private MeshFilter m_unappliedMesh;
    #endregion

    #region Propriedades
    public float Radius = 1.0f;
    public float Pull = 10.0f;
    public FallOffType FallOff = FallOffType.Gauss;
    #endregion

    #region Métodos
    private static float LinearFalloff(float distance, float inRadius)
    {
        return Mathf.Clamp01(1.0f - distance / inRadius);
    }

    private static float GaussFalloff(float distance, float inRadius)
    {
        return Mathf.Clamp01(Mathf.Pow(360.0f, -Mathf.Pow(distance / inRadius, 2.5f) - 0.01f));
    }

    private static float NeedleFalloff(float distance, float inRadius)
    {
        return -(distance * distance) / (inRadius * inRadius) + 1.0f;
    }

    private void DeformMesh(Mesh mesh, Vector3 position, float power, float inRadius)
    {
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        float sqrRadius = inRadius * inRadius;
        float sqrMagnitude = 0;
        float falloffValue = 0;

        // Calculate averaged normal of all surrounding vertices	
        Vector3 averageNormal = Vector3.zero;

        for (int i = 0; i < vertices.Length; i++)
        {
            sqrMagnitude = (vertices[i] - position).sqrMagnitude;
            // Early out if too far away
            if (sqrMagnitude > sqrRadius)
                continue;

            float distance = Mathf.Sqrt(sqrMagnitude);
            falloffValue = LinearFalloff(distance, inRadius);
            averageNormal += falloffValue * normals[i];
        }

        averageNormal = averageNormal.normalized;

        // Deform vertices along averaged normal
        for (int i = 0; i < vertices.Length; i++)
        {
            sqrMagnitude = (vertices[i] - position).sqrMagnitude;
            // Early out if too far away
            if (sqrMagnitude > sqrRadius)
                continue;

            float distance = Mathf.Sqrt(sqrMagnitude);
            switch (FallOff)
            {
                case FallOffType.Gauss:
                    falloffValue = GaussFalloff(distance, inRadius);
                    break;
                case FallOffType.Needle:
                    falloffValue = NeedleFalloff(distance, inRadius);
                    break;
                default:
                    falloffValue = LinearFalloff(distance, inRadius);
                    break;
            }

            vertices[i] += averageNormal * falloffValue * power;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    private void Update()
    {

        // When no button is pressed we update the mesh collider
        if (!Input.GetMouseButton(0))
        {
            // Apply collision mesh when we let go of button
            ApplyMeshCollider();
            return;
        }


        // Did we hit the surface?
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            MeshFilter filter = (MeshFilter)hit.collider.GetComponent("MeshFilter");

            if (filter)
            {
                // Don't update mesh collider every frame since physX
                // does some heavy processing to optimize the collision mesh.
                // So this is not fast enough for real time updating every frame
                if (filter != m_unappliedMesh)
                {
                    ApplyMeshCollider();
                    m_unappliedMesh = filter;
                }

                // Deform mesh
                Vector3 relativePoint = filter.transform.InverseTransformPoint(hit.point);
                DeformMesh(filter.mesh, relativePoint, Pull * Time.deltaTime, Radius);
            }
        }
    }

    private void ApplyMeshCollider()
    {
        if (m_unappliedMesh != null)
        {
            MeshCollider meshCollider = (MeshCollider) m_unappliedMesh.GetComponent("MeshCollider");

            if (meshCollider != null)
            {
                meshCollider.mesh = m_unappliedMesh.mesh;
            }
        }

        m_unappliedMesh = null;
    }
    #endregion
}
