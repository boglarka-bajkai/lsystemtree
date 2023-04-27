using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//This is not even a turtle this is a flippin' aeroplane
public class LTurtle : MonoBehaviour { 

    public struct Plane
    {
        public Vector3 Position;
        public Vector3 Direction;

        public Vector3 YawAxis;
        public Vector3 PitchAxis;
        public Vector3 RollAxis;
    }
    public string Sentence { get; set; }
    public float Angle { get; set; }
    public float Length { get; set; }

    private Plane plane;

    private Stack stack = new Stack();

    private void Start()
    {
        plane.Position = gameObject.transform.position;
        plane.Direction = Vector3.up;
        plane.YawAxis = Vector3.forward;
        plane.PitchAxis = Vector3.left;
        plane.RollAxis = Vector3.up;
    }

    /*special rules for drawing (from The Algorithmic Beauty of Plants):
         * angle : 25 degree
         * F : draw forward
         * f : move forward
         * - : turn right <angle>
         * + : turn left <angle>
         * ? : pitch up
         * & : pitch down
         * \ : roll left
         * / : roll right
         * | : turn around
         * $ : rotate the turtle to vertical
         * [ : push position and angle / start a branch
         * ] : pop position and angle / complete a branch
        */

    public void Draw()
    {
        foreach (char c in Sentence)
        {
            if(c == 'F')
            {
                //draw forward
                Vector3 start = plane.Position;
                Vector3 end = plane.Position + Length * plane.Direction;
                var b = new Branch(start, end);
                b.Draw();
                plane.Position = end;
            }
            if (c == 'f')
            {
                //move forward
                plane.Position += Length * plane.Direction;
            }
            if (c == '-')
            {
                //turn right <angle> -- yaw
                plane.Direction = (Quaternion.AngleAxis(-Angle, plane.YawAxis) * plane.Direction).normalized;
                plane.PitchAxis = (Quaternion.AngleAxis(Angle, plane.YawAxis) * plane.PitchAxis).normalized;
                plane.RollAxis = (Quaternion.AngleAxis(Angle, plane.YawAxis) * plane.RollAxis).normalized;
            }
            if (c == '+')
            {
                //turn left <angle> -- yaw
                plane.Direction = (Quaternion.AngleAxis(Angle, plane.YawAxis) * plane.Direction).normalized;
                plane.PitchAxis = (Quaternion.AngleAxis(Angle, plane.YawAxis) * plane.PitchAxis).normalized;
                plane.RollAxis = (Quaternion.AngleAxis(Angle, plane.YawAxis) * plane.RollAxis).normalized;
            }
            if (c == '?')
            {
                //pitch up
                plane.Direction = (Quaternion.AngleAxis(-Angle, plane.PitchAxis) * plane.Direction).normalized;
                plane.YawAxis = (Quaternion.AngleAxis(Angle, plane.PitchAxis) * plane.YawAxis).normalized;
                plane.RollAxis = (Quaternion.AngleAxis(Angle, plane.PitchAxis) * plane.RollAxis).normalized;
            }
            if (c == '&')
            {
                //pitch down
                plane.Direction = (Quaternion.AngleAxis(Angle, plane.PitchAxis) * plane.Direction).normalized;
                plane.YawAxis = (Quaternion.AngleAxis(Angle, plane.PitchAxis) * plane.YawAxis).normalized;
                plane.RollAxis = (Quaternion.AngleAxis(Angle, plane.PitchAxis) * plane.RollAxis).normalized;
            }
            if (c == '\\')
            {
                //roll left
                plane.Direction = (Quaternion.AngleAxis(-Angle, plane.RollAxis) * plane.Direction).normalized;
                plane.YawAxis = (Quaternion.AngleAxis(Angle, plane.RollAxis) * plane.YawAxis).normalized;
                plane.PitchAxis = (Quaternion.AngleAxis(Angle, plane.RollAxis) * plane.PitchAxis).normalized;
            }
            if (c == '/')
            {
                //roll right
                plane.Direction = (Quaternion.AngleAxis(Angle, plane.RollAxis) * plane.Direction).normalized;
                plane.YawAxis = (Quaternion.AngleAxis(Angle, plane.RollAxis) * plane.YawAxis).normalized;
                plane.PitchAxis = (Quaternion.AngleAxis(Angle, plane.RollAxis) * plane.PitchAxis).normalized;
            }
            if (c == '|')
            {
                //turn around
                plane.Direction = -plane.Direction;
            }
            if (c == '[')
            {
                //push position and angle
                stack.Push(plane);
                
            }
            if (c == ']')
            {
                //pop position and angle
                plane = (Plane)stack.Pop();
            }
        }
    }
}
