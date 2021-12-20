using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Graph : MonoBehaviour
{
    public GameObject vertexPrefab;
    protected List<Vertex> vertices;
    protected List<List<Vertex>> neighbours;
    protected List<List<float>> costs;

    public virtual void Start()
    {
        Load();
    }

    public virtual void Load()
    {

    }

    //получение размера графа
    public virtual int GetSize()
    {
        if (ReferenceEquals(vertices, null))
            return 0;
        return vertices.Count;
    }

    //поиск ближайших вершин для заданной позиции
    public virtual Vertex GetNearestVertex(Vector3 position)
    {
        return null;
    }

    //получение вершины по идентификатору
    public virtual Vertex GetVertexObj(int id)
    {
        if (ReferenceEquals(vertices, null) || vertices.Count == 0)
            return null;
        if (id < 0 || id >= vertices.Count)
            return null;
        return vertices[id];
    }

    //извлечение соседних вершин
    public virtual Vertex[] GetNeighbours(Vertex v)
    {
        if (ReferenceEquals(neighbours, null) || neighbours.Count == 0)
            return new Vertex[0];
        if (v.id < 0 || v.id >= neighbours.Count)
            return new Vertex[0];
        return neighbours[v.id].ToArray();
    }

    public List<Vertex> GetPathDFS(GameObject srcObj, GameObject dstObj)
    {
        //проверка входных объектов на значение null
        if (srcObj == null || dstObj == null)
            return new List<Vertex>();

        Vertex src = GetNearestVertex(srcObj.transform.position);
        Vertex dst = GetNearestVertex(dstObj.transform.position);
        Vertex[] neighbours;
        Vertex v;
        int[] previous = new int[vertices.Count];
        for (int i = 0; i < previous.Length; i++)
            previous[i] = -1;
        previous[src.id] = src.id;
        Stack<Vertex> s = new Stack<Vertex>();
        s.Push(src);

        //алгоритм DFS для поиска пути
        while (s.Count != 0)
        {
            v = s.Pop();
            if (ReferenceEquals(v, dst))
            {
                return BuildPath(src.id, v.id, ref previous);
            }
            neighbours = GetNeighbours(v);
            foreach (Vertex n in neighbours)
            {
                if (previous[n.id] != -1)
                    continue;
                previous[n.id] = v.id;
                s.Push(n);
            }
        }
        return new List<Vertex>();
    }

    public List<Vertex> GetPathBFS(GameObject srcOЬj, GameObject dstObj)
    {
        if (srcOЬj == null || dstObj == null)
            return new List<Vertex>();

        Vertex[] neighbours;
        Queue<Vertex> q = new Queue<Vertex>();
        Vertex src = GetNearestVertex(srcOЬj.transform.position);
        Vertex dst = GetNearestVertex(dstObj.transform.position);
        Vertex v;
        int[] previous = new int[vertices.Count];
        for (int i = 0; i < previous.Length; i++)
            previous[i] = -1;
        previous[src.id] = src.id;
        q.Enqueue(src);

        //алгоритм BFS для поиска пути
        while (q.Count != 0)
        {
            v = q.Dequeue();
            if (ReferenceEquals(v, dst))
            {
                return BuildPath(src.id, v.id, ref previous);
            }

            neighbours = GetNeighbours(v);
            foreach (Vertex n in neighbours)
            {
                if (previous[n.id] != -1)
                    continue;
                previous[n.id] = v.id;
                q.Enqueue(n);
            }
        }
        return new List<Vertex>();
    }

    private List<Vertex> BuildPath(int srcId, int dstId, ref int[] prevList)
    {
        List<Vertex> path = new List<Vertex>();
        int prev = dstId;
        do
        {
            path.Add(vertices[prev]);
            prev = prevList[prev];
        } while (prev != srcId);
        return path;
    }
}
