using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class BuildNavMesh : MonoBehaviour
{
    [Header("ベイク更新時間"), SerializeField] float bakeUpdateTime;
    private NavMeshSurface _surface;
    void Start()
    {
        _surface = GetComponent<NavMeshSurface>();
        StartCoroutine(BakeUpdate());
    }

    IEnumerator BakeUpdate()
    {
        while(true)
        {
            _surface.BuildNavMesh();

            yield return new WaitForSeconds(bakeUpdateTime);
        }
    }
}
