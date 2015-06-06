namespace BikeBuilder.Model.Entities
{
	using System;

	using Geonetric.DDD.Model;
	using Geonetric.DDD.Model.MultiTenant;

	using ValueObjects;

	public abstract class MultiTenantEntityBase<TIdentity> : EntityBase<TIdentity>, IMultiTenantDomainAggregate<TIdentity>
		where TIdentity : IIdentityGuid
	{
		public CollectionId CollectionId { get; protected set; }

		IOrganizationIdentifier IOrganizationSpecific.OrganizationId
		{
			get
			{
				return this.CollectionId;
			}
		}

		public void Transfer()
		{
			throw new NotImplementedException("TODO: Implement Transfer");
		}
	}
}