namespace BikeBuilder.Model.Entities
{
	using System;

	using Geonetric.DDD.Model;

	public class BicycleId : IdentityGuidBase
	{
	}

	public class Bicycle : PartsAggregateBase<BicycleId>, IEquatable<Bicycle>
	{
		public readonly BicycleId BicycleId;
		public readonly PartId FrameId;

		public Bicycle(PartId frameId)
			: this(new BicycleId(), frameId)
		{
			// TODO: Check for valid PartId identifying a frame.
			// TODO: Publish BicycleAdded event.
		}

		internal Bicycle(BicycleId bicycleId, PartId frameId)
		{
			// This constructor is used by a factory when
			// restoring this object from a data store.
			this.BicycleId = new BicycleId();
			this.FrameId = frameId;
		}

		protected override BicycleId EntityId
		{
			get
			{
				return this.BicycleId;
			}
		}

		public bool Equals(Bicycle other)
		{
			return this.BicycleId.Equals(other.BicycleId)
				&& this.FrameId.Equals(other.FrameId);

			// Still the same bike, even if it's been sold.
			////	&& this.CollectionId.Equals(other.CollectionId)
		}

		protected override bool Equals(IDomainEntity<BicycleId> other)
		{
			Bicycle otherBicycle = other as Bicycle;
			if (otherBicycle == null)
			{
				return false;
			}

			return this.Equals(otherBicycle);
		}
	}
}