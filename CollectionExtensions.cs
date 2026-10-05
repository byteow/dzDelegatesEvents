using System;
using System.Collections.Generic;
namespace CollectionExtensions;

public static class CollectionExtensions
{
    public static T GetMax<T>(
        this IEnumerable<T> collection,
        Func<T, float> convertToNumber)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(convertToNumber);

        T maxElement = null;
        float maxValue = float.MinValue;

        foreach (T element in collection)
        {
            float value = convertToNumber(element);

            if (maxElement == null || value > maxValue)
            {
                maxElement = element;
                maxValue = value;
            }
        }

        return maxElement;
    }
}
