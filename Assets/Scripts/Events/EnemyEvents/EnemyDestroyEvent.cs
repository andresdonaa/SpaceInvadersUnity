namespace Scripts.Events
{
    public class EnemyDestroyEvent
    {
        public EnemyController Enemy { get; set; }

        public EnemyDestroyEvent(EnemyController enemy)
        {
            Enemy = enemy;
        }
    }
}
