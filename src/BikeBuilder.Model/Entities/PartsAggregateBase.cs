namespace BikeBuilder.Model.Entities
{
	using Geonetric.DDD.Model;
	using Geonetric.DDD.Model.MultiTenant;

	public abstract class PartsAggregateBase<TIdentity> : MultiTenantEntityBase<TIdentity>, IMultiTenantDomainAggregate<TIdentity>
		where TIdentity : IIdentityGuid
	{
	}
}