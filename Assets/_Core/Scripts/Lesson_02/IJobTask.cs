using Unity.Collections;
using Unity.Jobs;

namespace Lesson_02
{
    public struct IJobTask : IJob
    {
        public NativeArray<int> Array;


        public void Execute()
        {
            ChangeArray();
            Array.Dispose();
        }


        private void ChangeArray()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > 10)
                    Array[i] = 0;
            }
        }
    }
}