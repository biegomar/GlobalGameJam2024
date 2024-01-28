using JetBrains.Annotations;
using UnityEngine;

namespace PicturePuzzleBiegoMar
{
    public class TilePositionItem
    {
        public Vector3 RelativePosition { get; set; }
        [CanBeNull] public SpriteRenderer Tile { get; set; }
    }
}