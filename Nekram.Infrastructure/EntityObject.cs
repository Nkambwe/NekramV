using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Nekram.Infrastructure
{
    /// <summary>
    /// Base class for all Prema Entity objects
    /// </summary>
    /// <typeparam name="T">The type of the Id property of this object</typeparam>
    [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
    public abstract class EntityObject<T> : IValidatableObject {

        /// <summary>
        /// Gets or sets the unique ID of the entity in the underlying data store.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// Checks if the current entity has an identity.
        /// </summary>
        /// <returns>True if the entity has no identity yet, false otherwise.</returns>
        public bool HasNoIdentity() {

            return default(T) == null || Id.Equals(default(T));
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">
        /// The object to compare with the current object. 
        /// </param>
        public override bool Equals(object obj) {
            if (!(obj is EntityObject<T>)) {
                return false;
            }

            if (ReferenceEquals(this, obj)) {
                return true;
            }

            var entity = (EntityObject<T>)obj;

            if (entity.HasNoIdentity() || HasNoIdentity()) {
                return false;
            }
            return entity.Id.Equals(Id);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override int GetHashCode() {

            if (!HasNoIdentity()) {
                if (Id != null)
                    return Id.GetHashCode() ^ 31;
            }

            return ToString().GetHashCode();
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="thisEntity">The first instance to compare.</param>
        /// <param name="thatEntity">The second instance to compare.</param>
        public static bool operator ==(EntityObject<T> thisEntity, EntityObject<T> thatEntity) {
            return Equals(thisEntity, null) ?
                Equals(thatEntity, null) : thisEntity.Equals(thatEntity);
        }

        /// <summary>
        /// Compares two instances of an entity for inequality.
        /// </summary>
        /// <param name="thisEntity">The first instance to compare.</param>
        /// <param name="thatEntity">The second instance to compare.</param>
        /// <returns>False when the objects are the same, true otherwise.</returns>
        public static bool operator !=(EntityObject<T> thisEntity, EntityObject<T> thatEntity) {
            return !(thisEntity == thatEntity);
        }

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <param name="validationContext">Describes the context in which a validation check is performed.</param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public IEnumerable<ValidationResult> Validate() {
            var validationErrors = new List<ValidationResult>();
            var ctx = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, ctx, validationErrors, true);
            return validationErrors;
        }
    }
}
