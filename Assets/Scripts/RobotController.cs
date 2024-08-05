using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class RobotController
    {
        private RobotModel _robotModel;
        private int _state;

        public RobotController(RobotModel.RobotState state)
        {
            _robotModel = new RobotModel();
            
            _state = 0;
            
            switch (state)
            {
                case RobotModel.RobotState.Human:
                    Human();
                    break;
                case RobotModel.RobotState.Car:
                    Car();
                    break;
                case RobotModel.RobotState.Airplane:
                    Airplane();
                    break;
            }
        }
        
        public void Human()
        {
            _robotModel.State = RobotModel.RobotState.Human;
            
            _robotModel.Colour = Color.red;
            
            _robotModel.Head = new RobotPart(new Vector3(0, 0.8f, 0.6f));
            _robotModel.Torso = new RobotPart(new Vector3(0, -0.4f, 0.6f));
            _robotModel.LeftArm = new RobotPart(new Vector3(0, 0, 1.6f));
            _robotModel.LeftHand = new RobotPart(new Vector3(0, 0, 2.4f));
            _robotModel.RightArm = new RobotPart(new Vector3(0, 0, -0.4f));
            _robotModel.RightHand = new RobotPart(new Vector3(0, 0, -1.2f));
            _robotModel.LeftLeg = new RobotPart(new Vector3(0, -1.5f, 1.1f));
            _robotModel.LeftFoot = new RobotPart(new Vector3(0, -2.3f, 1.1f));
            _robotModel.RightLeg = new RobotPart(new Vector3(0, -1.5f, 0.1f));
            _robotModel.RightFoot = new RobotPart(new Vector3(0, -2.3f, 0.1f));
        }
        
        public void Car()
        {
            _robotModel.State = RobotModel.RobotState.Car;
            
            _robotModel.Colour = Color.blue;
            
            _robotModel.Head = new RobotPart(new Vector3(1.5f, -0.35f, 0.6f));
            
            _robotModel.Torso = new RobotPart(new Vector3(0, -0.4f, 0.6f), new Vector3(0, 0, 90));

            Vector3 armRotation = new Vector3(90,0,0);
            _robotModel.LeftArm = new RobotPart(new Vector3(0.65f, -1.1f, 1), armRotation);
            _robotModel.LeftHand = new RobotPart(new Vector3(0.65f, -1.9f, 1), armRotation);
            _robotModel.RightArm = new RobotPart(new Vector3(0.65f, -1.1f, 0.1f), armRotation);
            _robotModel.RightHand = new RobotPart(new Vector3(0.65f, -1.9f, 0.1f), armRotation);
            _robotModel.LeftLeg = new RobotPart(new Vector3(-0.5f, -1, 1));
            _robotModel.LeftFoot = new RobotPart(new Vector3(-0.5f, -1.8f, 1));
            _robotModel.RightLeg = new RobotPart(new Vector3(-0.5f, -1, 0));
            _robotModel.RightFoot = new RobotPart(new Vector3(-0.5f, -1.8f, 0));
        }
        
        public void Airplane()
        {
            _robotModel.State = RobotModel.RobotState.Airplane;
            
            _robotModel.Colour = Color.green;
            
            _robotModel.Head = new RobotPart(new Vector3(1.5f, -0.35f, 0.6f));
            
            _robotModel.Torso = new RobotPart(new Vector3(0, -0.4f, 0.6f), new Vector3(0, 0, 90));

            _robotModel.LeftArm = new RobotPart(new Vector3(0.65f, -0.35f, 1.6f));
            _robotModel.LeftHand = new RobotPart(new Vector3(0.65f, -0.35f, 2.4f));
            _robotModel.RightArm = new RobotPart(new Vector3(0.65f, -0.35f, -0.4f));
            _robotModel.RightHand = new RobotPart(new Vector3(0.65f, -0.35f, -1.2f));
            
            Vector3 legRotation = new Vector3(0,0,-90);
            _robotModel.LeftLeg = new RobotPart(new Vector3(-1.4f, -0.35f, 1.1f),legRotation);
            _robotModel.LeftFoot = new RobotPart(new Vector3(-2.2f, -0.35f, 1.1f),legRotation);
            _robotModel.RightLeg = new RobotPart(new Vector3(-1.4f, -0.35f, 0.1f),legRotation);
            _robotModel.RightFoot = new RobotPart(new Vector3(-2.2f, -0.35f, 0.1f),legRotation);
        }

        public Vector3[] GetPositions()
        {
            return new[]
            {
                _robotModel.Torso.Position,
                _robotModel.Head.Position,
                _robotModel.LeftArm.Position,
                _robotModel.LeftHand.Position,
                _robotModel.RightArm.Position,
                _robotModel.RightHand.Position,
                _robotModel.LeftLeg.Position,
                _robotModel.LeftFoot.Position,
                _robotModel.RightLeg.Position,
                _robotModel.RightFoot.Position
            };
        }
        
        public Vector3[] GetRotations()
        {
            return new[]
            {
                _robotModel.Torso.Rotation,
                _robotModel.Head.Rotation,
                _robotModel.LeftArm.Rotation,
                _robotModel.LeftHand.Rotation,
                _robotModel.RightArm.Rotation,
                _robotModel.RightHand.Rotation,
                _robotModel.LeftLeg.Rotation,
                _robotModel.LeftFoot.Rotation,
                _robotModel.RightLeg.Rotation,
                _robotModel.RightFoot.Rotation
            };
        }

        public void Next()
        {
            _state++;
            switch (_state % 3)
            {
                case 0:
                    Human();
                    break;
                case 1:
                    Car();
                    break;
                case 2:
                    Airplane();
                    break;
            }
        }

        public Color Colour => _robotModel.Colour;
    }
}