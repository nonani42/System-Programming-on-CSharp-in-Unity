using System.Collections;
using UnityEngine;

namespace Lesson_01
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int health;
        private Coroutine healingCoroutine;

        public void Start()
        {
            ReceiveNormalHealing();
            if (healingCoroutine != null)
                StopCoroutine(healingCoroutine);
            ReceiveBigHealing();
        }

        public void ReceiveNormalHealing()
        {
            Debug.Log($"ReceiveNormalHealing");
            ReceiveHealing(5, 3, 0.5f);
        }

        public void ReceiveBigHealing()
        {
            Debug.Log($"ReceiveBigHealing");
            ReceiveHealing(10, 3, 0.5f);
        }

        private void ReceiveHealing(int healAmount, float time, float delay)
        {
            healingCoroutine = StartCoroutine(Heal(healAmount, time, delay));
        }

        private IEnumerator Heal(int healAmount, float time, float delay)
        {
            while (health < maxHealth && time > 0)
            {
                health += healAmount;
                time -= delay;
                Debug.Log($"health {health}; time {time}");
                yield return new WaitForSeconds(delay);
            }
            yield break;
        }
    }
}