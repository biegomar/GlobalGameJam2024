using UnityEngine;

namespace Archery.Pigeons
{
    public class XPingPongMovement : IMovementStrategy
    {
        private const float pingPongLength = 13f;
    
        private readonly Vector2 startPosition;
        private float pingPongSpeed;
        private float moveTime;
    
        
        public XPingPongMovement(Vector2 initialPosition)
        {
            this.pingPongSpeed = UnityEngine.Random.Range(-1f, 2f) + GameManager.Instance.PigeonWaveYBaseSpeed;
            this.startPosition = initialPosition;
        }
        public float CalculateNewXPosition(GameObject gameObject)
        {
            this.moveTime += Time.deltaTime;
            var delta = Mathf.PingPong(moveTime * this.pingPongSpeed, pingPongLength);
            
            return this.startPosition.x < 0 ? this.startPosition.x + delta : this.startPosition.x - delta;
        }

        public float CalculateNewYPosition(GameObject gameObject)
        {
            return this.startPosition.y;
        }
    }
}