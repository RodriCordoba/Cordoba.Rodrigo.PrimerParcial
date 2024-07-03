namespace Entidades.Indumentaria
{
    /// <summary>
    /// Interfaz genérica para representar las propiedades y métodos básicos de una prenda de indumentaria.
    /// </summary>
    /// <typeparam name="T">El tipo de material de la prenda.</typeparam>
    public interface IIndumentaria<T>
    {
        /// <summary>
        /// Obtiene o establece el código de la prenda.
        /// </summary>
        string Codigo { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de la prenda.
        /// </summary>
        int Cantidad { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de material de la prenda.
        /// </summary>
        T TipoMaterial { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de ítems relacionados con la prenda.
        /// </summary>
        List<Indumentaria> Items { get; set; }

        /// <summary>
        /// Devuelve una descripción de la prenda.
        /// </summary>
        /// <returns>Una cadena que describe la prenda.</returns>
        string Descripcion();
    }
}
