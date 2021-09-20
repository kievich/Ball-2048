using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Util
{
    public static class BallHelper
    {
        public static List<Ball> FindBallsInRadius(Vector3 position, float radius, BallStates state)
        {
            List<Ball> balls = new List<Ball>();

            foreach (var ball in Ball.balls)
            {
                if (Vector3.Distance(position, ball.gameObject.transform.position) < radius && ball.State.Value == state)
                    balls.Add(ball);

            }
            return balls;

        }
    }
}
