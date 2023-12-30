﻿using Microsoft.CodeAnalysis;
using System.IO;
using System.Threading;

namespace SourceGenerator
{
    [Generator]
    internal class ConstGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var textFiles = context.AdditionalTextsProvider.Where(file => file.Path.EndsWith(".txt"));
            var outputNamespace = context.CompilationProvider.Select((compilation, cancellationToken) => compilation.GetEntryPoint(cancellationToken).ContainingNamespace);
            var namesAndContents = textFiles.Select(NameContentPair.Create).Combine(outputNamespace);

            context.RegisterSourceOutput(namesAndContents, (spc, namesAndContent) =>
            {
                spc.AddSource($"ConstStrings.{namesAndContent.Left.Name}.g.cs", $@"// <auto-generated/>
namespace {namesAndContent.Right.ToDisplayString()}
{{
    internal static partial class ConstStrings
    {{
        public const string {namesAndContent.Left.Name} = ""{namesAndContent.Left.Content}"";
    }}
}}");
            });
        }
    }

    internal class NameContentPair
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public NameContentPair(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public static NameContentPair Create(AdditionalText text, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileNameWithoutExtension(text.Path);
            var content = text.GetText(cancellationToken).ToString();
            return new NameContentPair(fileName, content);
        }
    }

    internal class GenerationContext
    {
        public IncrementalValueProvider<INamespaceSymbol> Namespace { get; set; }
        public IncrementalValuesProvider<NameContentPair> NamesAndContents { get; set; }
    }
}
