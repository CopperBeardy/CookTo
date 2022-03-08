using System.Collections.Immutable;

namespace CookTo.Shared.Consts;

public static class Temperature
{
    public static ImmutableList<string> GetTemperatures() => ImmutableList<string>.Empty
        .AddRange(
            new[]
            {
                "Gas 1/275F/135C/125CFan",
                "Gas 2/300F/150C/140CFan",
                "Gas 3/325F/165C/150CFan",
                "Gas 4/350F/180C/160CFan",
                "Gas 5/375F/190C/170CFan",
                "Gas 6/400F/205C/185CFan",
                "Gas 7/425F/220C/200CFan",
                "Gas 8/450F/230C/210CFan",
                "Gas 9/475F/245C/225CFan",
                "Gas 10/500F/260C/240CFan"
            });
}
