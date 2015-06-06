namespace BikeBuilder.Model.Entities
{
	using System;

	using Geonetric.DDD.Model;

	public class PartId : IdentityGuidBase
	{
	}

	public class Part : PartsAggregateBase<PartId>, IEquatable<Part>
	{
		public readonly PartId PartId;

		private BicycleId bicycleId;

		public Part()
			: this(new PartId())
		{
			// TODO: Publish PartAdded event.
		}

		internal Part(PartId partId)
		{
			this.PartId = partId;
		}

		protected override PartId EntityId
		{
			get
			{
				return this.PartId;
			}
		}

		public bool Equals(Part other)
		{
			// TODO: should still be the same type of part.
			return this.PartId.Equals(other.PartId);

			// Still the same part, even if it's been sold.
			////	&& this.CollectionId.Equals(other.CollectionId)
		}

		protected override bool Equals(IDomainEntity<PartId> other)
		{
			Part otherPart = other as Part;
			if (otherPart == null)
			{
				return false;
			}

			return this.Equals(otherPart);
		}
	}
}