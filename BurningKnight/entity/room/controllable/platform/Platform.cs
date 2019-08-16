using BurningKnight.entity.component;
using BurningKnight.save;
using Lens.entity;
using Lens.util.file;
using Microsoft.Xna.Framework;
using VelcroPhysics.Dynamics;

namespace BurningKnight.entity.room.controllable.platform {
	public class Platform : Support {
		private Vector2 startingPoint;
		
		public override void PostInit() {
			base.PostInit();
			
			Depth = Layers.UnderFloor;
			startingPoint = Position;
		}

		public override void Load(FileReader stream) {
			base.Load(stream);
			
			startingPoint = new Vector2(stream.ReadInt32(), stream.ReadInt32());
			Position = startingPoint;
		}

		public override void Save(FileWriter stream) {
			base.Save(stream);
			
			stream.WriteInt32((int) startingPoint.X);
			stream.WriteInt32((int) startingPoint.Y);
		}

		public override void Apply(Entity e, float dt) {
			base.Apply(e, dt);
			var b = e.GetAnyComponent<BodyComponent>();

			if (b == null || !ShouldMove(e)) {
				return;
			}
			
			b.Position += GetComponent<RectBodyComponent>().Velocity * dt;
		}

		protected virtual bool ShouldMove(Entity e) {
			return true;
		}
	}
}