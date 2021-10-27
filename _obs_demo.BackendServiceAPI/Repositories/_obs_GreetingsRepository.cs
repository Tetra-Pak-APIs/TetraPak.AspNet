// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using demo.Acme;
// using demo.Acme.Repositories;
// using demo.DataModel;
// using Microsoft.Extensions.Logging;
// using TetraPak;
//
// #nullable enable
//
// namespace demo.BackendServiceAPI.Repositories obsolete
// {
//     public class GreetingsRepository : SimpleRepository<GreetingModel>
//     {
//         ILogger Logger { get; }
//
//         
//         readonly Dictionary<string, GreetingModel> _greetings = new();
//
//         public async Task<EnumOutcome<GreetingModel>> ReadAsync(string? id = null, CancellationToken? cancellation = null)
//         {
//             await SimulateSlowRepositoryAsync(cancellation);
//             
//             if (id is { })
//                 return _greetings.TryGetValue(id, out var greeting)
//                         ? EnumOutcome<GreetingModel>.Success(greeting)
//                         : EnumOutcome<GreetingModel>.Fail(new ArgumentOutOfRangeException(nameof(id)));
//
//             return _greetings.Count == 0
//                     ? EnumOutcome<GreetingModel>.Fail()
//                     : EnumOutcome<GreetingModel>.Success(_greetings.Values);
//         }
//
//         public Task<bool> ContainsAsync(string id) => Task.FromResult(_greetings.ContainsKey(id));
//
//         public async Task<Outcome<string>> CreateOrUpdateAsync(GreetingModel? greeting, CancellationToken? cancellation = null)
//         {
//             await SimulateSlowRepositoryAsync(cancellation);
//
//             if (greeting is null)
//                 return Outcome<string>.Fail(new Exception("Expected a value"));
//
//             if (_greetings.TryGetValue(greeting.Id, out _))
//                 return await UpdateAsync(greeting); 
//                 
//             _greetings.Add(greeting.Id, greeting);
//             return Outcome<string>.Success(greeting.Id);
//         }
//
//         public async Task<Outcome<string>> UpdateAsync(GreetingModel? greeting, CancellationToken? cancellation = null)
//         {
//             await SimulateSlowRepositoryAsync(cancellation);
//             
//             if (greeting is null)
//                 return Outcome<string>.Fail(new Exception("Expected a value"));
//
//             if (!_greetings.TryGetValue(greeting.Id, out var existing))
//                 return Outcome<string>.Fail(
//                     new ArgumentOutOfRangeException(
//                         nameof(greeting), 
//                         $"Repository does not contain greeting '{greeting.Id}'"));
//
//             if (greeting.Greeting is { })
//             {
//                 existing.Greeting = greeting.Greeting;
//             }
//
//             if (greeting.Subject is { })
//             {
//                 existing.Subject = greeting.Subject;
//             }
//             
//             return Outcome<string>.Success(existing.Id);
//         }
//         
//    
//         public GreetingsRepository(ILogger<GreetingsRepository> logger) 
//         : base(logger)
//         {
//             Logger = logger;
//         }
//     }
// }