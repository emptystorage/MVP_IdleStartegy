namespace Code.BattleParticipants.AttackLogic
{
    public interface IAttackLogic
    {
        void Execute(in WarriorParticipant owner, in BattleParticipant target);
    }
}
