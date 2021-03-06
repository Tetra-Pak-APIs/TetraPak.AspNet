using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TetraPak.AspNet.Diagnostics
{
    public class ServiceDiagnostics : IEnumerable<KeyValuePair<string,object>>
    {
        /// <summary>
        ///   The prefix for timer values.
        /// </summary>
        /// <seealso cref="GetValues"/>
        public const string TimerPrefix = "tpd-time";

        readonly Dictionary<string, object> _values = new();
        
        [JsonPropertyName("roundtripTime")]
        public long ElapsedMilliseconds { get; set; }

        public long? End() => GetElapsedMs(TimerPrefix);
        
        public void StartTimer(string key)
        {
            key = key == TimerPrefix ? key : timerKey(key); 
            _values[key] = new Timer(DateTime.Now.Ticks);
        }
        
        public long? GetElapsedMs(string key = null, bool stopTimer = true)
        {
            key = key is null ? TimerPrefix : timerKey(key);
            if (!_values.TryGetValue(key, out var obj) || obj is not Timer timer)
                return null;

            return timer.ElapsedMs(stopTimer);
        }
        
        static string timerKey(string key) => $"{TimerPrefix}-{key}";

        /// <summary>
        ///   Returns all values, optionally filtered with a <paramref name="prefix"/> pattern.
        /// </summary>
        /// <param name="prefix">
        ///   (optional)<br/>
        ///   A prefix pattern for filtering result.
        /// </param>
        /// <returns>
        ///   A collection of <see cref="KeyValuePair{String,Object}"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, object>> GetValues(string prefix = null)
        {
            return string.IsNullOrWhiteSpace(prefix) 
                ? _values 
                : _values.Where(i => i.Key.StartsWith(prefix));
        }

        public ServiceDiagnostics()
        {
            StartTimer(TimerPrefix);
        }
        
        public class Timer
        {
            public long Begin { get; }
            
            public long? End { get; set; }

            public long ElapsedMs(bool stop = true)
            {
                var end = DateTime.Now.Ticks;
                if (stop && !End.HasValue)
                    End = end;
                
                return (long) (End.HasValue
                    ? TimeSpan.FromTicks(End.Value - Begin).TotalMilliseconds
                    : TimeSpan.FromTicks(end - Begin).TotalMilliseconds);
            }

            public Timer(long now)
            {
                Begin = now;
            }
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}