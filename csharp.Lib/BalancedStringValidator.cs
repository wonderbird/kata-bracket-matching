using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Lib
{
    public static class BalancedStringValidator
    {
        public static bool IsBalanced(this string input, string balancingCharacterPairs)
        {
            var characterPairs = new CharacterPairs(balancingCharacterPairs);
            var nextClosingCharacter = new NextClosingCharacter();

            foreach (var character in input)
            {
                var isOpeningCharacter = characterPairs.IsOpening(character);
                var isClosingCharacter = characterPairs.IsClosing(character);

                if (nextClosingCharacter.Peek() == character)
                {
                    nextClosingCharacter.Pop();
                }
                else  if (isOpeningCharacter)
                {
                    nextClosingCharacter.Push(characterPairs.GetMatchingClosingCharacter(character));
                }
                else if (isClosingCharacter)
                {
                    return false;
                }
            }

            return nextClosingCharacter.IsEmpty();
        }
    }

    public class CharacterPairs
    {
        private readonly Dictionary<char, char> _mapOpeningToClosingCharacters;

        public CharacterPairs(string balancingCharacterPairs)
        {
            _mapOpeningToClosingCharacters = balancingCharacterPairs.Zip(
                    balancingCharacterPairs.Skip(1),
                    Tuple.Create)
                .Where((_, index) => index % 2 == 0)
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
        }

        public bool IsClosing(char character) => _mapOpeningToClosingCharacters.Values.Contains(character);

        public bool IsOpening(char character) => _mapOpeningToClosingCharacters.Keys.Contains(character);

        public char GetMatchingClosingCharacter(char openingCharacter) => _mapOpeningToClosingCharacters[openingCharacter];
    }

    public class NextClosingCharacter
    {
        private readonly Stack<char> _requiredClosingCharacters = new();

        public void Push(char character)
        {
            _requiredClosingCharacters.Push(character);
        }

        public void Pop()
        {
            _requiredClosingCharacters.Pop();
        }

        public bool IsEmpty() => _requiredClosingCharacters.Count == 0;

        public char? Peek() => IsEmpty() ? null : _requiredClosingCharacters.Peek();
    }
}
