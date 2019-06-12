using BurningKnight.assets;
using BurningKnight.entity.component;
using Lens.graphics;
using Lens.graphics.animation;
using Microsoft.Xna.Framework;

namespace BurningKnight.entity.projectile {
	public class ProjectileGraphicsComponent : SliceComponent {
		public ProjectileGraphicsComponent(string image, string slice) : base(image, slice) {
			
		}

		public ProjectileGraphicsComponent(AnimationData image, string slice) : base(image, slice) {
			
		}

		public override void Render(bool shadow) {
			if (shadow) {
				Graphics.Render(Sprite, Entity.Position + new Vector2(Sprite.Center.X, Sprite.Height + Sprite.Center.Y), 
					0, Sprite.Center, Vector2.One, Graphics.ParseEffect(Flipped, !FlippedVerticaly));
				return;
			}

			var p = (Projectile) Entity;
			var d = p.IndicateDeath && p.T >= p.Range - 1f && p.T % 0.8f <= 0.4f;

			if (d) {
				var shader = Shaders.Entity;
				
				Shaders.Begin(shader);
				
				shader.Parameters["flash"].SetValue(1f);
				shader.Parameters["flashReplace"].SetValue(1f);
				shader.Parameters["flashColor"].SetValue(ColorUtils.White);
			}
			
			Graphics.Render(Sprite, Entity.Position);

			if (d) {
				Shaders.End();
			}
		}
	}
}