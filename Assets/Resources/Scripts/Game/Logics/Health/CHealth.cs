using UnityEngine;

namespace Game.Logics.Health
{
    public class CHealth : MonoBehaviour
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float CurrentHealth { get; private set; }
        [field: SerializeField] public float RegenerationHealth { get; private set; }
        [field: SerializeField] public bool IsAlive  { get; private set; }

        public void AddHealth(float amount) => CurrentHealth += amount;

        public void SubstractHealth(float health)
        {
            CurrentHealth = Mathf.Max(CurrentHealth - health, 0.0f);

            if (CurrentHealth <= 0.0f)
            {
                IsAlive = false;
            }
        }

        public void AddHealthRegeneration(float amount) => RegenerationHealth += amount;

        private void Update()
        {
            if (IsAlive)
            {
                CurrentHealth = Mathf.Min(CurrentHealth + RegenerationHealth * Time.deltaTime, MaxHealth);
            }
        }
    }
}
