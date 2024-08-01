﻿using System.Text.Json.Serialization;

namespace PresentationLayer
{
    // Base response class is used to make consuming endpoints easy by adding more information to the response  
    public class BaseResponse<T>(T? data, string message, List<string> errors = null, bool success = true)
    {
        public bool Success { get; set; } = success;
        public string Message { get; set; } = message;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; } = errors;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T? Data { get; set; } = data;
    }
}
