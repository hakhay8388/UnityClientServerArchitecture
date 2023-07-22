using Game.Server.nDatabase.nEntities;
using Game.Server.nSessionManager;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game.Server.nGameGraph.nWebApiGraph.nListenerGraph.nGameManagerListener.nPlayer
{
    public class cPlayer
    {

        public Vector3 Position;
        public Quaternion Rotation;

        public float MoveSpeed = 0.005f / Settings.TICKS_PER_SEC;
        public bool[]  Inputs;


        public cUser User { get; set; }
        public cSession Session { get; set; }


        public cPlayer(cSession _Session, cUser _User) 
        {
            Position = new Vector3(0, 0, 0);
            Rotation = Quaternion.Identity;
            Session = _Session;
            User = _User;
            Inputs = new bool[4];
        }

        public void Update()
        {
            Vector2 __InputDirection = Vector2.Zero;
            if (Inputs[0])
            {
                __InputDirection.X -= 1;
            }
            if (Inputs[1])
            {
                __InputDirection.X += 1;
            }
            if (Inputs[2])
            {
                __InputDirection.Y += 1;
                
            }
            if (Inputs[3])
            {
                __InputDirection.Y -= 1;                
            }

            Move(__InputDirection);
        }

        private void Move(Vector2 _InputDirection)
        {
            Vector3 __Forward = Vector3.Transform(new Vector3(0, 0, 1), Rotation);
            Vector3 __Right = Vector3.Normalize(Vector3.Cross(__Forward, new Vector3(0, 1, 0)));

            Vector3 __MoveDirection = __Right * _InputDirection.X + __Forward * _InputDirection.Y;
            Position += __MoveDirection * MoveSpeed;
        }

        public void SetInput(bool[] _Inputs)
        {
            Inputs = _Inputs;
        }

    }
}
