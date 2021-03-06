﻿using DbShell.All;
using DbShell.Core;
using DbShell.Driver.Common.AbstractDb;
using System;

namespace ConsoleSamples.Samples
{
    public class AnalyseTables : SampleBase
    {
        public override void Run()
        {
            // build service containing all supported database egnines and file formats, with default logging
            var serviceProvider = DbShellUtility.BuildDefaultServiceProvider();

            // create connection provider from provider string
            var connectionProvider = ConnectionProvider.FromString(serviceProvider, ProviderString);

            using (var conn = connectionProvider.Connect())
            {
                // create analyser - object which analyses database structure
                var analyser = connectionProvider.Factory.CreateAnalyser();

                // assign DbConnection to analyse
                analyser.Connection = conn;

                // analyse only tables. If this line is omited, all database objects (eg. views, stored procedures...) will be analysed
                analyser.Phase = DatabaseAnalysePhase.Tables;

                // perform full analysis (other option is IncrementalAnalysis, when changes are detected)
                analyser.FullAnalysis();

                // get result structure
                var analysedStructure = analyser.Structure;

                // print table and column names
                foreach (var table in analysedStructure.Tables)
                {
                    Console.WriteLine(table.Name);
                    foreach (var column in table.Columns)
                    {
                        Console.WriteLine("    " + column.Name + " " + column.DataType);
                    }
                }
            }
        }
    }
}
