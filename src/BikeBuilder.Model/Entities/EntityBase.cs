namespace BikeBuilder.Model.Entities
{
	using System;

	using Geonetric.DDD.Model;

	public abstract class EntityBase<TIdentity> : IDomainEntity<TIdentity>
		where TIdentity : IIdentityGuid
    {
		protected abstract TIdentity EntityId
		{
			get;
		}

		TIdentity IDomainEntity<TIdentity>.EntityId
		{
			get
			{
				return this.EntityId;
			}
		}

		protected abstract bool Equals(IDomainEntity<TIdentity> other); // return this.EntityId.Equals(other.EntityId);

		bool IEquatable<IDomainEntity<TIdentity>>.Equals(IDomainEntity<TIdentity> other)
		{
			return this.Equals(other);
		}
	}
}