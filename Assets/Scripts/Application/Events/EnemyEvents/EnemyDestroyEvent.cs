namespace Scripts.Events
{
    public class EnemyDestroyEvent
    {
        public EnemyController Enemy { get; private set; }

        public EnemyDestroyEvent(EnemyController enemy)
        {
            Enemy = enemy;
        }
    }
}
