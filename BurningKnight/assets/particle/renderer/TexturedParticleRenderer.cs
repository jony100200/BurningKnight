using Lens.assets;
using Lens.graphics;
using Microsoft.Xna.Framework;

namespace BurningKnight.assets.particle.renderer {
	public class TexturedParticleRenderer : ParticleRenderer {
		public TextureRegion Region;

		public TexturedParticleRenderer(string slice) {
			Region = Animations.Get("particles").GetSlice(slice);
		}

		public TexturedParticleRenderer() {
			
		}

		public override void Render(Particle particle) {
			Graphics.Render(Region, particle.Position - new Vector2(0, particle.Z), particle.Angle, Region.Center, new Vector2(particle.Scale));
		}
	}
}