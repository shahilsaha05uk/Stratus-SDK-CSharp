namespace StratusSDK
{
    public readonly record struct ObjectKey
    {
        const int MaxLength = 255;
        static readonly char[] InvalidCharacters =
        [
            '"',   // double quote
            '<',   // angular bracket
            '>',
            '#',   // hashtag
            '\\',  // backslash
            '|',   // pipe
            ' '    // space
        ];
        public string Value { get; }
        public ObjectKey(string value)
        {
            Validate(value);
            Value = value;
        }

        public static implicit operator string(ObjectKey key)
            => key.Value;
        public override string ToString()
            => Value;

        static void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Object key cannot be null or empty.");

            if (value.Length > MaxLength)
                throw new ArgumentException(
                    $"Object key length cannot exceed {MaxLength} characters.");

            if (value.IndexOfAny(InvalidCharacters) >= 0)
                throw new ArgumentException(
                    $"Object key contains invalid characters: {string.Join(", ", InvalidCharacters)}");
        }
    }
}
