using System;
using UnityEngine;

namespace Archery.Pigeons
{
    public class PigeonItem
    {
        public GameObject Enemy { get; set; }
        public Vector3 StartPosition { get; set; }
        public uint Health { get; set; }
        public Guid FormationId { get; set; }
        public bool Flag { get; set; }
    }
}