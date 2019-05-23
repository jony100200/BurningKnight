using BurningKnight.entity.component;
using BurningKnight.ui.dialog;

namespace BurningKnight.entity.creature.npc {
	public class OldMan : Npc {
		public override void AddComponents() {
			base.AddComponents();

			Width = 20;
			Height = 18;

			AddComponent(new AnimationComponent("old_man"));
			AddComponent(new RectBodyComponent(0, 0, Width, Height));
			
			AddComponent(new InteractableComponent(e => {
				GetComponent<DialogComponent>().Start("its_dangerous_to_go");
				return true;
			}));
			
			AddComponent(new CloseDialogComponent("its_dangerous_to_go"));
		}
	}
}