[System.Serializable]
public class Item
{
    public int id;
    public string nombre;
    public string descripcion;

    public Item(int id, string nombre, string descripcion)
    {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }

    public virtual string ObtenerInfo()
    {
        return $"[Item #{id}] {nombre} - {descripcion}";
    }
}