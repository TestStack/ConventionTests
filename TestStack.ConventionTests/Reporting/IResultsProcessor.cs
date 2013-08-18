﻿namespace TestStack.ConventionTests.Reporting
{
    using TestStack.ConventionTests.Internal;

    public interface IResultsProcessor
    {
        void Process(IConventionFormatContext context, params ConventionResult[] results);
    }
}