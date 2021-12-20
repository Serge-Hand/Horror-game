
using System;

//класс для хранения внешних вершин с их стоимостями
[System.Serializable]
public class Edge : IComparable<Edge>
{
    public float cost;
    public Vertex vertex;

    public Edge(Vertex vertex = null, float cost = 1f)
    {
        this.vertex = vertex;
        this.cost = cost;
    }

    //метод сравнения
    public int CompareTo(Edge other)
    {
        float result = cost - other.cost;
        int idA = vertex.GetInstanceID();
        int idB = other.vertex.GetInstanceID();
        if (idA == idB)
            return 0;
        return (int)result;
    }

    //функция сравнения двух рёбер
    public bool Equals(Edge other)
    {
        return (other.vertex.id == this.vertex.id);
    }

    //функция сравнения двух объектов
    public override bool Equals(object obj)
    {
        Edge other = (Edge)obj;
        return (other.vertex.id == this.vertex.id);
    }

    //функция извлечения хэш-кода
    public override int GetHashCode()
    {
        return this.vertex.GetHashCode();
    }
}
