using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class GeneratorConcreteBuilder : IBuilderGenerator
    {
        private Generator _generator;

        public GeneratorConcreteBuilder()
        {
            Reset();
        }
        public void Reset() => _generator = new Generator();

        public void SetCharacter(TypeCharacter character) => _generator.Character = character;

        public void SetContent(List<string> content) => _generator.Content = content;

        public void SetFormat(TypeFormat format) => _generator.Format = format;
        
        public Generator GetGenerator() => _generator;

        public void SetPath(string path) => _generator.Path = path;
    }
}
