using Lens.entity;

namespace BurningKnight.assets.particle.controller {
	public class ParticleController {
		public virtual void Init(Particle particle, Entity owner) {
			particle.Position = owner.Center;
		}
		
		public virtual bool Update(Particle particle, float dt) {
			particle.Update(dt);
			return false;
		}
	}
}