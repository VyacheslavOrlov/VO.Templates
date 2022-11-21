using System.Diagnostics.CodeAnalysis;

namespace RestApiClientTemplate.Implementation.Decorators.ErrorHandling.ProblemDetails.Comparers;

internal class StatusTypeEqulityComparer : EqualityComparer<Refit.ProblemDetails>
{
    public StatusTypeEqulityComparer()
    {
    }

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
        return x.Status == y.Status && x.Type == y.Type;
    }

    public override int GetHashCode([DisallowNull] Refit.ProblemDetails obj)
        => HashCode.Combine(obj.Status, obj.Type);
}
