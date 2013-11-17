namespace SharpStocks.Data
{
    /// <summary>
    /// Marker interface for objects which correspond to entities in persistant storage
    /// </summary>
    public interface IEntity { }
    /// <summary>
    /// Marker interface for IEntity ojects which are not immutable
    /// </summary>
    public interface IModifiable : IEntity { }
}