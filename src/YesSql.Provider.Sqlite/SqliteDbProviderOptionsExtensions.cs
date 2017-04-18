﻿using Microsoft.Data.Sqlite;
using System;
using System.Data;
using YesSql.Services;
using YesSql.Storage.Sql;

namespace YesSql.Provider.Sqlite
{
    public static class SqliteDbProviderOptionsExtensions
    {
        public static IConfiguration UseSqLite(
            this IConfiguration configuration,
            string connectionString)
        {
            return UseSqLite(configuration, connectionString, IsolationLevel.Serializable);
        }

        public static IConfiguration UseSqLite(
            this IConfiguration configuration,
            string connectionString,
            IsolationLevel isolationLevel)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            configuration.ConnectionFactory = new DbConnectionFactory<SqliteConnection>(connectionString);
            configuration.DocumentStorageFactory = new SqlDocumentStorageFactory();
            configuration.IsolationLevel = isolationLevel;

            return configuration;
        }
    }
}