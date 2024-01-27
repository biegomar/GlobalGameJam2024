using UnityEngine;

namespace Archery.Pigeons
{
    internal interface IMovementStrategy
    {
        float CalculateNewXPosition(GameObject gameObject);
        float CalculateNewYPosition(GameObject gameObject);
    }
}