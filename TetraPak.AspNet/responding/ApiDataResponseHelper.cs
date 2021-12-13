using System.Diagnostics.CodeAnalysis;
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
        public static bool TryAsApiDataResponse<T>(
            this object obj, 
            [NotNullWhen(true)] out ApiDataResponse<T>? dataResponse)
        {
            dataResponse = null;
            switch (obj)
            {
                case null:
                    return false;

                case ApiDataResponse<T> apiDataResponse:
                    dataResponse = apiDataResponse;
                    return true;
            }

            return false;
        }

        /// <summary>
        ///   Examines the <see cref="DynamicEntity"/> and returns a value to indicate that it
        ///   reflects a <see cref="ApiDataResponse"/>.
        /// </summary>
        /// <param name="dynamicEntity">
        ///   The <see cref="DynamicEntity"/> to be examined.
        /// </param>
        /// <param name="dataResponse">
        ///   Passed back the API response data (payload) if <paramref name="dynamicEntity"/> is
        ///   found to be a <see cref="ApiDataResponse"/>; otherwise <c>null</c>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if <paramref name="dynamicEntity"/> is an <see cref="ApiDataResponse"/>;
        ///   otherwise <c>false</c>.
        /// </returns>
        public static bool IsApiDataResponse(this DynamicEntity dynamicEntity, out object? dataResponse)
        {
            dataResponse = null;
            if (dynamicEntity.Keys.Count != 2)
                return false;

            if (!dynamicEntity.ContainsKey(ApiDataResponse.MetaKey)
                || !dynamicEntity.ContainsKey(ApiDataResponse.DataKey))
                return false;

            var data = dynamicEntity[ApiDataResponse.DataKey];
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