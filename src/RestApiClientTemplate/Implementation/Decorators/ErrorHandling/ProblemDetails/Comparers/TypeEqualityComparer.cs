using System.Diagnostics.CodeAnalysis;

namespace RestApiClientTemplate.Implementation.Decorators.ErrorHandling.ProblemDetails.Comparers;

internal sealed class TypeEqualityComparer : EqualityComparer<Refit.ProblemDetails>
{
    public override bool Equals(Refit.ProblemDetails? x, Refit.ProblemDetails? y)
    {
        if (object.Equals(x, y))
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }
        return x.Type == y.Type;
    }

    public override int GetHashCode([DisallowNull] Refit.ProblemDetails obj)
        => HashCode.Combine(obj.Type);
}
