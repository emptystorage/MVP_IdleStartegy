namespace Code.BattleParticipants
{
    public interface ICombatable
    {
        int Damage { get; }
        float ReloadTime { get; }
        float HuntDistance { get; }
        float AttackDistance { get; }
    }
}
