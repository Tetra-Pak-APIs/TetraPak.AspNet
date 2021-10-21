namespace TetraPak.AspNet
{
    public interface IApiDataResponse
    {
        /// <summary>
        ///   Obtains all data items.
        /// </summary>
        /// <returns></returns>
        object[] GetDataAsObjectArray();
    }
}