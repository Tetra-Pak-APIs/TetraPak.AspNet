using System.Text.Json;
using TetraPak.DynamicEntities;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Convenient methods for dealing with HTTP response use cases. 
    /// </summary>
    public static class ApiDataResponseHelper
    {
        /// <summary>
        ///   Examines an object and returns a value to indicate is is a <see cref="ApiDataResponse{T}"/>
        ///   of a specified data type.
        /// </summary>
        /// <param name="obj">
        ///   The object being examined.
        /// </param>
        /// <param name="dataResponse">
        ///   On success; passed back the object as an <see cref="ApiDataResponse{T}"/>.
        /// </param>
        /// <typeparam name="T">
        ///   The expected ApiDataResponse data type.
        /// </typeparam>
        /// <returns>
        ///   <c>true</c> if <paramref name="obj"/> is a <see cref="ApiDataResponse{T}"/> of <typeparamref name="T"/>;
        ///   otherwise <c>false</c>.
        /// </returns>
        public static bool TryAsApiDataResponse<T>(this object obj, out ApiDataResponse<T> dataResponse)
        {
            dataResponse = null;
            switch (obj)
            {
                case null:
                    return false;
                
                // case DynamicEntity dynamicEntity:
                //     return dynamicEntity.IsApiDataResponse(out dataResponse);

                case ApiDataResponse<T> apiDataResponse:
                    dataResponse = apiDataResponse;
                    return true;
            }

            return false;

            // if (!obj.GetType().TryGetGenericBase(typeof(ApiDataResponse<>), out var type)) obsolete
            //     return false;
            //
            // var itemType = type.GetGenericArguments().FirstOrDefault();
            // if (itemType is null)
            //     return false;
            //
            // return itemType == typeof(T) || itemType.IsAssignableFrom(typeof(T));
        }

        public static bool IsApiDataResponse(this DynamicEntity dynamicEntity, out object dataResponse)
        {
            dataResponse = null;
            if (dynamicEntity.Keys.Count != 2)
                return false;

            if (!dynamicEntity.ContainsKey(ApiDataResponse<object>.MetaKey)
                || !dynamicEntity.ContainsKey(ApiDataResponse<object>.DataKey))
                return false;

            var data = dynamicEntity[ApiDataResponse<object>.DataKey];
            if (data is null or JsonElement { ValueKind: JsonValueKind.Array })
            {
                // null is considered ok ...
                dataResponse = dynamicEntity;
                return true;
            }

            if (!data.IsCollection(out _, out _, out _)) 
                return false;
            
            dataResponse = dynamicEntity;
            return true;
        }
    }
}