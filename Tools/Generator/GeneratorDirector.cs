using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class GeneratorDirector
    {

        private IBuilderGenerator _generatorBuilder;

        GeneratorDirector(IBuilderGenerator generatorBuilder)
        {
            SetBuilder(generatorBuilder);
        }

        public void SetBuilder(IBuilderGenerator generatorBuilder) => _generatorBuilder = generatorBuilder;

        public void CreateSimpleJsonGenerator(List<string> content, string path)
        {
            _generatorBuilder.Reset();
            _generatorBuilder.SetContent(content);
            _generatorBuilder.SetPath(path);
            _generatorBuilder.SetFormat(TypeFormat.Json);
        }

        public void CreateSimplePipeGenerator(List<string> content, string path)
        {
            _generatorBuilder.Reset();
            _generatorBuilder.SetContent(content);
            _generatorBuilder.SetPath(path);
            _generatorBuilder.SetFormat(TypeFormat.Pipes);
            _generatorBuilder.SetCharacter(TypeCharacter.Uppercase);
        }

    }
}
