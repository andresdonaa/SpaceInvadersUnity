namespace Scripts.Events
{
    public class EnemyTakeDamageEvent
    {
        public EnemyController Enemy { get; set; }

        public EnemyTakeDamageEvent(EnemyController enemy)
        {
            Enemy = enemy;
        }
    }
}
