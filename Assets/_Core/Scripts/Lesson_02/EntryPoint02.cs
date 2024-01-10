using System.Text;
using Unity.Collections;
using UnityEngine;
using Random = System.Random;


namespace Lesson_02
{
    public class EntryPoint02 : MonoBehaviour
    {
        private NativeArray<int> array; 

        private NativeArray<Vector3> positions;
        private NativeArray<Vector3> velocities;
        private NativeArray<Vector3> finalPositions;


        void Start()
        {
            //Task1();

            Task2();
        }

        /// <summary>
        /// Создайте задачу типа IJob, которая принимает данные в формате NativeArray<int>
        /// и в результате выполнения все значения более десяти делает равными нулю.
        /// Вызовите выполнение этой задачи из внешнего метода и выведите в консоль результат.
        /// </summary>
        private void Task1()
        {
            FillIntArray();
            PrintIntArray();
            IJobTask jobTask = new IJobTask();
            jobTask.Array = array;
            jobTask.Execute();
            PrintIntArray();
        }

        /// <summary>
        /// Cоздайте задачу типа IJobParallelFor, которая будет принимать данные в виде двух контейнеров: Positions и Velocities
        /// — типа NativeArray<Vector3>.Также создайте массив FinalPositions типа NativeArray<Vector3>.
        /// Сделайте так, чтобы в результате выполнения задачи в элементы массива FinalPositions были записаны суммы 
        /// соответствующих элементов массивов Positions и Velocities.
        /// Вызовите выполнение этой задачи из внешнего метода и выведите в консоль результат.
        /// </summary>
        private void Task2()
        {
            FillVector3Arrays();
            PrintArrays();
            IJobParallelForTask jobParallelForTask = new IJobParallelForTask();
            jobParallelForTask.Positions = positions;
            jobParallelForTask.Velocities = velocities;
            jobParallelForTask.FinalPositions = finalPositions;
            jobParallelForTask.Execute(0);
            PrintArrays();
        }

        private void FillIntArray()
        {
            Random rnd = new Random();
            array = new NativeArray<int>(10, Allocator.Temp);

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(1, 20);
        }

        private void PrintIntArray()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i]);
                stringBuilder.Append(", ");
            }
            Debug.Log($"array: {stringBuilder}");
        }

        private void FillVector3Arrays()
        {
            int length = 3;
            int minNum = 1;
            int maxNum = 6;

            Random rnd = new Random();
            positions = new NativeArray<Vector3>(length, Allocator.Temp);
            velocities = new NativeArray<Vector3>(length, Allocator.Temp);
            finalPositions = new NativeArray<Vector3>(length, Allocator.Temp);

            for (int i = 0; i < length; i++)
            {
                positions[i] = new Vector3(rnd.Next(minNum, maxNum), rnd.Next(minNum, maxNum), rnd.Next(minNum, maxNum));
                velocities[i] = new Vector3(rnd.Next(minNum, maxNum), rnd.Next(minNum, maxNum), rnd.Next(minNum, maxNum));
                finalPositions[i] = Vector3.zero;
            }
        }

        private void PrintArrays()
        {
            PrintVector3Array(positions, nameof(positions));
            PrintVector3Array(velocities, nameof(velocities));
            PrintVector3Array(finalPositions, nameof(finalPositions));
        }

        private void PrintVector3Array(NativeArray<Vector3> array, string name)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{name}");
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append($"{array[i]}, ");
            }
            Debug.Log($"{stringBuilder}");
        }
    }
}