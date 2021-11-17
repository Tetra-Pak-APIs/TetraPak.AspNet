// using System;
//
// namespace TetraPak.AspNet
// {
//     /// <summary>
//     ///   Convenient methods for <see cref="ApiException"/>.
//     /// </summary>
//     public static class ApiExceptionHelper
//     {
//         /// <summary>
//         ///   Produces a duplicated <see cref="ApiException"/> by injecting a prefix to the
//         ///   <see cref="Exception.Message"/> property.
//         /// </summary>
//         /// <param name="exception">
//         ///   The extended <see cref="ApiException"/>.
//         /// </param>
//         /// <param name="prefix">
//         ///   The message prefix.
//         /// </param>
//         /// <returns></returns>
//         /// <exception cref="ArgumentNullException">
//         ///   <paramref name="prefix"/> is <c>null</c> or empty.
//         /// </exception>
//         public static ApiException WithMessagePrefix(this ApiException exception, string prefix) obsolete
//         {
//             if (string.IsNullOrEmpty(prefix)) throw new ArgumentNullException(nameof(prefix)); 
//             var message = $"{prefix} {exception.Message}";
//             return new ApiException(message, exception.StatusCode, exception.InnerException);
//         }
//     }
// }