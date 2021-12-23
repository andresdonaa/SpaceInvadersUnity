namespace Scripts.Events
{
    public class EnemyTakeDamageEvent
    {
        public EnemyController Enemy { get; private set; }

        public EnemyTakeDamageEvent(EnemyController enemy)
        {
            Enemy = enemy;
        }
    }
}
