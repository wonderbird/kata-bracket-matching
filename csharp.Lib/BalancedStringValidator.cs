using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Lib
{
    public static class BalancedStringValidator
    {
        public static bool IsBalanced(this string input, string balancingCharacterPairs)
        {
            var reqClosingCharacters = new ClosingCharacters(balancingCharacterPairs);
            foreach (var character in input)
            {
                if (reqClosingCharacters.IsOpeningCharacter(character))
                {
                    reqClosingCharacters.AddIfOpeningCharacter(character);
                }
                else if (reqClosingCharacters.IsClosingCharacter(character))
                {
                    if (!reqClosingCharacters.CheckAndPopClosingCharacter(character))
                    {
                        return false;
                    }
                }
            }

            return reqClosingCharacters.IsEmpty();
        }
    }

    public class ClosingCharacters
    {
        private readonly Dictionary<char, char> _mapOpeningToClosingCharacters;
        private readonly Stack<char> _requiredClosingCharacters = new();

        public ClosingCharacters(string balancingCharacterPairs) =>
            _mapOpeningToClosingCharacters = MapOpeningToClosingCharacters(balancingCharacterPairs);

        private static Dictionary<char, char> MapOpeningToClosingCharacters(string balancingCharacterPairs)
        {
            return balancingCharacterPairs.Zip(
                    balancingCharacterPairs.Skip(1),
                    Tuple.Create)
                .Where((_, index) => index % 2 == 0)
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
        }

        public void AddIfOpeningCharacter(char character)
        {
            if (IsOpeningCharacter(character))
            {
                _requiredClosingCharacters.Push(_mapOpeningToClosingCharacters[character]);
            }
        }

        public bool CheckAndPopClosingCharacter(char character)
        {
            if (_requiredClosingCharacters.Count == 0)
            {
                return false;
            }

            if (_requiredClosingCharacters.Pop() != character)
            {
                return false;
            }

            return true;
        }

        public bool IsClosingCharacter(char character) => _mapOpeningToClosingCharacters.Values.Contains(character);

        public bool IsOpeningCharacter(char character) => _mapOpeningToClosingCharacters.Keys.Contains(character);

        public bool IsEmpty() => _requiredClosingCharacters.Count == 0;
    }
}
