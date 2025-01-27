namespace Code.BattleParticipants
{
    public interface ICombatable
    {
        int Damage { get; }
        float ReloadTime { get; }
        float HuntDistance { get; }
        float AttackDistance { get; }
        bool IsAttacking { get; }

        void Combat();
        void Attack(in BattleParticipant target);
    }
}
