namespace Code.BattleParticipant
{
    public interface ICombatable
    {
        float HuntDistance { get; }
        float AttackDistance { get; }
        bool IsAttacking { get; }
        void Combat();
        void Attack(in BattleParticipant target);
    }
}
