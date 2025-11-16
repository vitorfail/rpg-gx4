using System.Collections.Generic;

namespace TipagemClasses
{
    public interface IClassData
    {
        Dictionary<string, ClassDetails> Classes { get; set; }
    }

    public class ClassDetails
    {
        public string Foco { get; set; } = string.Empty;
        public string Descri { get; set; } =string.Empty;
        public Dictionary<string, Archetype> Arquetipo { get; set; } = new();
        public List<Level> Level { get; set; } = new();
    }

    public class Archetype
    {
        public string Nome { get; set; } = string.Empty;
        public object Text { get; set; } = new object();
    }

    public class Level
    {
        public int Lv { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Bp { get; set; }
        public int F { get; set; }
        public int Df { get; set; }
        public bool I { get; set; }
        public List<int> H { get; set; } = new();
        public List<int> Magias { get; set; } = new();
        public int Invo { get; set; }
        public int Mc { get; set; }
        public int Pf { get; set; }
        public List<object> Af { get; set; } = new(){0,""};
        public List<object> Am { get; set; } = new(){0,""};
        public int Chi { get; set; }
    }

    public class DndClassesData : IClassData
    {
        public Dictionary<string, ClassDetails> Classes { get; set; }

        public DndClassesData()
        {
            Classes = new Dictionary<string, ClassDetails>
            {
                { "barbaro", new ClassDetails() },
                { "bardo", new ClassDetails() },
                { "bruxo", new ClassDetails() },
                { "clerigo", new ClassDetails() },
                { "druida", new ClassDetails() },
                { "feiticeiro", new ClassDetails() },
                { "guerreiro", new ClassDetails() },
                { "ladino", new ClassDetails() },
                { "monge", new ClassDetails() },
                { "mago", new ClassDetails() },
                { "paladino", new ClassDetails() },
                { "ranger", new ClassDetails() }
            };
        }
    }
}
