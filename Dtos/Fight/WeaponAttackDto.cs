namespace dotnet_rpg.Dtos.Fight
{
    public class WeaponAttackDto
    {
        //No need for weapon id because the attacker can only have one weapon.
        public int AttackerId{ get; set; }
        public int OpponentId { get; set; }

    }
}
