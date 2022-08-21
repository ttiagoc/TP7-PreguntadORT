using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP7_PreguntadORT.Models
{
    public static class EnumerableExtension
    {
        

    public static Preguntas PickRandom<Preguntas>(this IEnumerable<Preguntas> source)
    {
        return source.PickRandom(1).Single();
    }

    public static IEnumerable<Preguntas> PickRandom<Preguntas>(this IEnumerable<Preguntas> source, int count)
    {
        return source.Shuffle().Take(count);
    }

    public static IEnumerable<Preguntas> Shuffle<Preguntas>(this IEnumerable<Preguntas> source)
    {
        return source.OrderBy(x => Guid.NewGuid());
    }
}
    
}