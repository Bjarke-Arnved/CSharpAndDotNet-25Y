using System.Text.Json.Serialization;

namespace Opgave01.model;

public record Character([property:JsonPropertyName("fullName")]string FullName);