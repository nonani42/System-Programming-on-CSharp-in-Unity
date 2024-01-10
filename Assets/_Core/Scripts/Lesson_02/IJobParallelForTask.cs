using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Lesson_02
{
    public struct IJobParallelForTask : IJobParallelFor
    {
        [ReadOnly]
        public NativeArray<Vector3> Positions;

        [ReadOnly]
        public NativeArray<Vector3> Velocities;

        [WriteOnly]
        public NativeArray<Vector3> FinalPositions;

        public void Execute(int index)
        {
            FinalPositions[index] = Positions[index] + Velocities[index];
        }
    }
}
