namespace Code.BattleParticipants.AttackLogic
{
    public struct MeleeAttacklLogic : IAttackLogic
    {
        public void Execute(in WarriorParticipant owner, in BattleParticipant target)
        {
            target.Hit(owner.Damage);
        }
    }
}
