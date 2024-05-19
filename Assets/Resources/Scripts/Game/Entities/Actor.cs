using Game.Types;
using Game.Logics.Health;
using Game.Logics.Movement;
using UnityEngine;

namespace Game.Entities
{
    public class Actor : MonoBehaviour
    {
        [field: SerializeField] public Transform SelfTransform { get; private set; }
        [field: SerializeField] public NavMeshMovement Movement { get; private set; }
        [field: SerializeField] public CHealth Health { get; private set; }
        [field: SerializeField] public ETeam Team { get; private set; }

        public Vector3 GetLocation() => SelfTransform != null ? SelfTransform.position : transform.position;

        public virtual void ApplyDamage(float amount)
        {
            if (Health != null && Health.IsAlive)
            {
                Health.SubstractHealth(amount);
            }
            else
            {
                OnDied();
            }
        }

        protected virtual void OnDied()
        {
            Destroy(gameObject);
        }
    }
}
