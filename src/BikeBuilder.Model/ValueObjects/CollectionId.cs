namespace BikeBuilder.Model.ValueObjects
{
	using System;

	using Geonetric.DDD.Model;
	using Geonetric.DDD.Model.MultiTenant;

	public sealed class CollectionId : IdentityGuidBase, IOrganizationIdentifier
	{
		Guid IIdentity<Guid>.Id
		{
			get
			{
				return this.Id;
			}
		}

		string IIdentityGuid.IdString
		{
			get
			{
				return this.IdString;
			}
		}

		bool IEquatable<IOrganizationIdentifier>.Equals(IOrganizationIdentifier other)
		{
			return this.Equals(other);
		}

		bool IIdentityGuid.IsEmpty()
		{
			return this.IsEmpty();
		}
	}
}