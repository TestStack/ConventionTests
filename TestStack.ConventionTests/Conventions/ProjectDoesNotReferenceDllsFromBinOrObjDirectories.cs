﻿namespace TestStack.ConventionTests.Conventions
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using TestStack.ConventionTests.ConventionData;

    public class ProjectDoesNotReferenceDllsFromBinOrObjDirectories : IConvention<ProjectReferences>
    {
        const string AssemblyReferencingObjRegex = @"^(?<assembly>.*?(obj|bin).*?)$";

        public string ConventionTitle
        {
            get { return "Project must not reference dlls from bin or obj directories"; }
        }

        public void Execute(ProjectReferences data, IConventionResult result)
        {
            result.Is(data.References.Where(IsBinOrObjReference));
        }

        static bool IsBinOrObjReference(ProjectReference reference)
        {
            return Regex.IsMatch(reference.ReferencedPath, AssemblyReferencingObjRegex, RegexOptions.IgnoreCase);
        }
    }
}