using UnityEngine;

namespace DefaultNamespace
{
    public class RobotModel
    {
        public enum RobotState {Human, Car, Airplane}
        
        public Color Colour { get; set; }
        
        public RobotState State { get; set; }
            
        public RobotPart Head { get; set; }
        public RobotPart Torso { get; set; }
        public RobotPart LeftArm { get; set; }
        public RobotPart LeftHand { get; set; }
        public RobotPart RightArm { get; set; }
        public RobotPart RightHand { get; set; }
        public RobotPart LeftLeg { get; set; }
        public RobotPart LeftFoot { get; set; }
        public RobotPart RightLeg { get; set; }
        public RobotPart RightFoot { get; set; }
    }
}