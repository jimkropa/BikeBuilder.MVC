namespace BikeBuilder.Model.ValueObjects
{
	using System;

	using Geonetric.DDD.Model.MultiTenant;

	public sealed class CollectionId : OrganizationIdentifier // IdentityGuidBase, IOrganizationIdentifier
	{
		public CollectionId(string guidString)
			: base(guidString)
		{
		}

		public CollectionId(Guid id)
			: base(id)
		{
		}

		/*
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
		*/
	}
}