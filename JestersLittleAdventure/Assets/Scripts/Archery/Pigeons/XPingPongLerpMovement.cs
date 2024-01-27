using UnityEngine;

namespace Archery.Pigeons
{
    public class XPingPongLerpMovement : IMovementStrategy
    {
        private readonly Vector2 targetPosition;
        private const float duration = 4.0f;

        public XPingPongLerpMovement(Vector2 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    
        public float CalculateNewXPosition(GameObject gameObject)
        {
            var vec = Vector2.Lerp(gameObject.transform.position, this.targetPosition, duration * Time.deltaTime);

            return vec.x;
        }

        public float CalculateNewYPosition(GameObject gameObject)
        {
            return this.targetPosition.y;
        }
    }
}