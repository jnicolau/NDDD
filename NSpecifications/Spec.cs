﻿namespace NSpecifications;

/// <summary>
/// Represents a generic specification.
/// </summary>
/// <typeparam name="T">The type of the candidate object.</typeparam>
/// <remarks>
/// If your specification relies on properties that are changed after instantiating it
/// this implementation might fail because the IsSatisfiedBy is compiled and cached on
/// it's first usage. 
/// </remarks>
/// <param name="predicate">The predicate that defines the specification.</param>
public class Spec<T>(Expression<Func<T, bool>> predicate) : ASpec<T>
{
    /// <summary>
    /// Represents a specification that is satisfied by any candidate object.
    /// </summary>
    public static readonly Spec<T> Any = new(_ => true);

    /// <summary>
    /// Represents a specification that is not satisfied by any candidate object.
    /// </summary>
    public static readonly Spec<T> None = new(_ => false);

    /// <inheritdoc/>
    public override Expression<Func<T, bool>> Predicate { get; } = predicate ?? throw new ArgumentNullException(nameof(predicate));
}

/// <summary>
/// Provides a set of static methods for working
/// with <see cref="ASpec{T}"/> instances.
/// </summary>
public static class Spec
{
    /// <summary>
    /// Creates a specification that is satisfied by any candidate object.
    /// </summary>
    /// <typeparam name="T">The type of the candidate object.</typeparam>
    /// <returns>
    /// An <see cref="ASpec{T}"/> that is satisfied by any candidate object.
    /// </returns>
    public static ASpec<T> Any<T>()
        => Spec<T>.Any;

    /// <summary>
    /// Creates a specification that is not satisfied by any candidate object.
    /// </summary>
    /// <typeparam name="T">The type of the candidate object.</typeparam>
    /// <returns>
    /// An <see cref="ASpec{T}"/> that is not satisfied by any candidate object.
    /// </returns>
    public static ASpec<T> None<T>()
        => Spec<T>.None;
}
