using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demo.BackendServiceAPI.Models;
using TetraPak;

#nullable enable

namespace demo.BackendServiceAPI.Data
{
    public class GreetingsRepository
    {
        readonly Dictionary<string, GreetingDTO> _greetings = new Dictionary<string, GreetingDTO>();

        public Task<EnumOutcome<GreetingDTO>> ReadAsync(string? id = null)
        {
            if (id is { })
                return Task.FromResult(
                    _greetings.TryGetValue(id, out var greeting)
                        ? EnumOutcome<GreetingDTO>.Success(greeting)
                        : EnumOutcome<GreetingDTO>.Fail(new ArgumentOutOfRangeException(nameof(id))));

            return Task.FromResult(
                _greetings.Count == 0
                    ? EnumOutcome<GreetingDTO>.Fail()
                    : EnumOutcome<GreetingDTO>.Success(_greetings.Values));
        }

        public Task<bool> ContainsAsync(string id) => Task.FromResult(_greetings.ContainsKey(id));

        public Task<Outcome<string>> CreateOrUpdateAsync(GreetingDTO? greeting)
        {
            if (greeting is null)
                return Task.FromResult(Outcome<string>.Fail(new Exception("Expected a value")));

            if (_greetings.TryGetValue(greeting.Id, out _))
                return UpdateAsync(greeting); 
                
            _greetings.Add(greeting.Id, greeting);
            return Task.FromResult(Outcome<string>.Success(greeting.Id));
        }

        public Task<Outcome<string>> UpdateAsync(GreetingDTO? greeting)
        {
            if (greeting is null)
                return Task.FromResult(Outcome<string>.Fail(new Exception("Expected a value")));

            if (!_greetings.TryGetValue(greeting.Id, out var existing))
                return Task.FromResult(Outcome<string>.Fail(
                    new ArgumentOutOfRangeException(nameof(greeting), $"Repository does not contain greeting '{greeting.Id}'")));

            if (greeting.Greeting is { })
            {
                existing.Greeting = greeting.Greeting;
            }

            if (greeting.Subject is { })
            {
                existing.Subject = greeting.Subject;
            }
            
            return Task.FromResult(Outcome<string>.Success(existing.Id));
        }
    }
}