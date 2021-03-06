using BurningKnight.entity.component;
using BurningKnight.entity.creature.player;

namespace BurningKnight.entity.twitch.happening {
	public class HurtHappening : Happening {
		private int damage;

		public HurtHappening(int dmg = 1) {
			damage = dmg;
		}
		
		public override void Happen(Player player) {
			player.GetComponent<HealthComponent>().ModifyHealth(-damage, null, DamageType.Custom);
		}
	}
}