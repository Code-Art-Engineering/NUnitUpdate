using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace NUnitUpdate
{
    /// <summary>
    /// Upgrade NUnit test from V3 to V4
    /// </summary>
    internal static class NUnitV3Upgrade
    {
        public static Dictionary<string, string> assertionMap;

        static NUnitV3Upgrade()
        {
            // Dictionary mapping V3 assertion methods to V4 equivalents
            assertionMap =
                new Dictionary<string, string>
                {
                    {"AreEqual", "That"},
                    {"AreNotEqual", "That"},
                    {"IsTrue", "That"},
                    {"IsFalse", "That"},
                    {"IsNull", "That"},
                    {"IsNotNull", "That"},
                    {"IsEmpty","That" },
                    // Add more mappings as needed
                };
        }

        public static void UpgradeFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Any(n => n.StartsWith("using NUnit.Framework;")))
            {
                Trace.WriteLine($"Processing File: {fileName} ...");

                //NUnit file, process contents.
                for (int x = 0; x < lines.Length; x++)
                {
                    string l = lines[x];
                    if (l.Contains("Assert.")) lines[x] = ConvertNUnitV3ToV4(l);
                }
                File.WriteAllLines(fileName, lines);
                Trace.WriteLine($"File Updated: {fileName} ...");
            }
        }

        public static void UpgradeFolder(string folderName)
        {
            if (!Directory.Exists(folderName)) throw new DirectoryNotFoundException($"Folder not found: {folderName}!");
            foreach (string f in Directory.GetFiles(folderName, "*.cs", SearchOption.AllDirectories))
            {
                UpgradeFile(f);
            }
        }

        private static string ConvertNUnitV3ToV4(string code)
        {
            string leadingSpace = code.Substring(0, code.Length - code.TrimStart().Length);

            // Parse the input code into a syntax tree
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

            // Create a new root with transformed nodes
            var newRoot = root.ReplaceNodes(
                root.DescendantNodes().OfType<InvocationExpressionSyntax>(),
                (node, _) => TransformAssertionIfNeeded(node));

            // Return the transformed code as a string
            return leadingSpace + newRoot.ToFullString();
        }

        private static SyntaxNode TransformAssertionIfNeeded(InvocationExpressionSyntax node)
        {
            if (!(node.Expression is MemberAccessExpressionSyntax memberAccess))
                return node;

            if (memberAccess.Expression.ToString() != "Assert")
                return node;

            switch (memberAccess.Name.Identifier.Text)
            {
                case "AreEqual":
                case "AreNotEqual":
                    node = TransformTwoArgumentAssertion(node, memberAccess.Name.Identifier.Text);
                    break;
                case "IsTrue":
                case "IsFalse":
                case "IsNull":
                case "IsNotNull":
                case "IsEmpty":
                    node = TransformOneArgumentAssertion(node, memberAccess.Name.Identifier.Text);
                    break;
                default:
                    return node;
            }
            return node;
        }

        private static InvocationExpressionSyntax TransformTwoArgumentAssertion(InvocationExpressionSyntax node, string assertionMethod)
        {
            var arguments = node.ArgumentList.Arguments;
            if (arguments.Count != 2)
                return node;

            return SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("Assert"),
                    SyntaxFactory.IdentifierName("That")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                            arguments[1],
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            SyntaxFactory.Argument(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName("Is"),
                                        SyntaxFactory.IdentifierName(assertionMethod.Replace("Are", "") + "To")))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SingletonSeparatedList(arguments[0]))))
                            })));
        }

        private static InvocationExpressionSyntax TransformOneArgumentAssertion(InvocationExpressionSyntax node, string assertionMethod)
        {
            var arguments = node.ArgumentList.Arguments;
            if (arguments.Count != 1)
                return node;

            return SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("Assert"),
                    SyntaxFactory.IdentifierName("That")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                            arguments[0],
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            SyntaxFactory.Argument(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.IdentifierName("Is"),
                                    SyntaxFactory.IdentifierName(assertionMethod.Replace("Is", ""))))
                            })));
        }

    }
}
