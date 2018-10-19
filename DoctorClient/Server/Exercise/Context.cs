using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Exercise
{
    public class Context
    {
        public ExerciseState State { get; set; }

        public Context(ExerciseState state)
        {
            this.State = state;
        }

        public void Request()
        {
            this.State.Event(this);
        }
    }
}