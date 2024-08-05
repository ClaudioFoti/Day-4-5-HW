using UnityEngine;

namespace DefaultNamespace
{
    public class RobotPart
    {
        public RobotPart(Vector3 position)
        {
            Position = position;
            Rotation = new Vector3(0,0,0);
        }
        
        public RobotPart(Vector3 position, Vector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }
        
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
    }
}