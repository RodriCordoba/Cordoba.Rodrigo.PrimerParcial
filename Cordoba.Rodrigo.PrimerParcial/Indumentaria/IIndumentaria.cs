namespace Entidades.Indumentaria
{
    public interface IIndumentaria<T>
    {
        string Codigo { get; set; }
        int Cantidad { get; set; }
        T TipoMaterial { get; set; }
        List<Indumentaria> Items { get; set; }
        string Descripcion();
    }
}
